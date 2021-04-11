using DLWMS.WinForms.Entiteti;
using DLWMS.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.Forme
{
    public partial class frmStudentiPotvrde : Form
    {
        public frmStudentiPotvrde()
        {
            InitializeComponent();
            dgvStudentiPotvrde.AutoGenerateColumns = false;
        }

        private void frmStudentiPotvrde_Load(object sender, EventArgs e)
        {
            UcitajStudentePotvrde();
        }

        private void UcitajStudentePotvrde(List<StudentiPotvrde> list = null)
        {
            try
            {
                dgvStudentiPotvrde.DataSource = null;
                dgvStudentiPotvrde.DataSource = list ?? DLWMSdb.Baza.StudentiPotvrde.ToList();

                lblBrPotvrda.Text = $"{(dgvStudentiPotvrde.DataSource as List<StudentiPotvrde>)?.Count}";

            }
            catch (Exception ex)
            {
                Poruke.Greska(ex);
            }
        }

        private async void btnGenerisi_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                long brPotvrda;
                var isBroj = long.TryParse(txtGenerisi.Text, out brPotvrda);

                if (isBroj)
                {
                    Action disableGenerating = new Action(() => btnGenerisi.Enabled = false);
                    BeginInvoke(disableGenerating);
                    
                    try
                    {
                        var rand = new Random();
                        var randIzdata = new Random();
                    
                        for (int i = 0; i < brPotvrda; i++)
                        {
                            var index = rand.Next(0, DLWMSdb.Baza.Studenti.Count() - 1);
                            var izdata = rand.Next(0, 2);
                            DLWMSdb.Baza.StudentiPotvrde.Add(new StudentiPotvrde()
                            {
                                Student = DLWMSdb.Baza.Studenti.ToList().ElementAt(index),
                                Datum = DateTime.Now,
                                Svrha = "Regulisanje statusa_" + DateTime.Now.Second,
                                Izdata = izdata == 0 ? false : true
                            });

                            DLWMSdb.Baza.SaveChanges();
                        }

                        Action action = new Action(() => {
                            UcitajStudentePotvrde();
                            btnGenerisi.Enabled = true;
                            });
                        BeginInvoke(action);
                    }
                    catch (Exception ex)
                    {
                        Poruke.Greska(ex);
                    }
                }
                else
                    MessageBox.Show(Poruke.VrijednostNijeValidna);

                Action clearText = new Action(() => txtGenerisi.Text = "");
                BeginInvoke(clearText);
            });

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (DLWMSdb.Baza.StudentiPotvrde.ToList()?.Count > 0 
                && MessageBox.Show(Poruke.BrisanjePotvrda,
                Poruke.Pitanje,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnObrisi.Enabled = false;
                Thread t = new Thread(ObrisiPotvrde);

                t.Start();

            }
            else
                MessageBox.Show(Poruke.PraznaLista);
        }

        private void ObrisiPotvrde()
        {
            Action action = new Action(() => { 
                UcitajStudentePotvrde();
                btnObrisi.Enabled = true;
            });

            foreach (var item in DLWMSdb.Baza.StudentiPotvrde)
            {
                DLWMSdb.Baza.StudentiPotvrde.Remove(item);
                DLWMSdb.Baza.SaveChanges();
            }
            BeginInvoke(action);
        }

        private void BtnUpisiUFajl_Click(object sender, EventArgs e)
        {
            try
            {
                using(var sw = File.AppendText("StudentiPotvrde.csv"))
                {
                    var studentiPotvrde = DLWMSdb.Baza.StudentiPotvrde.ToList();
                    
                    BtnUpisiUFajl.Enabled = false;
                    
                    if (studentiPotvrde?.Count > 0)
                    {
                        foreach (var item in studentiPotvrde)
                        {
                            var prop = item.GetType().GetProperties();

                            for (int i = 1; i < prop.Length; i++)
                            {
                                sw.Write($"{prop[i].GetValue(item)}");
                                if (i < prop.Length - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    
                    }
                    else
                        MessageBox.Show(Poruke.PraznaLista);

                    BtnUpisiUFajl.Enabled = true;

                    sw.Close();
                }
                
            }
            catch (Exception ex)
            {
                Poruke.Greska(ex);
            }
        }

    }
}
