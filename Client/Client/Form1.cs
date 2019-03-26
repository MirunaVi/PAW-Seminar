using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        ArrayList client = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            ClientRauPlatnic cl1 = new ClientRauPlatnic(1, "Edy", "Romana Square", "PF", 120, new int[] { 2, 3, 4 });
            client.Add(cl1);
            client.Add(new ClientRauPlatnic(2, "Andrei", "Romana Square", "PJ", 320, new int[] { 2, 3, 4 }));
            client.Add(new ClientRauPlatnic(3, "Alexandra", "Romana Square", "PF", 220, new int[] { 2, 3, 4 }));
            client.Sort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCod.Text == "")
            {
                errorProvider1.SetError(tbCod, "Introduceti Codul!");
            }
            else if (tbNume.Text == "")
            {
                errorProvider1.SetError(tbNume, "Introduceti Numele!");
            }
            else if (tbAdresa.Text == "")
            {
                errorProvider1.SetError(tbAdresa, "Introduceti Adresa!");
            }
            else if (!rbPF.Checked && !rbPJ.Checked)
            {
                errorProvider1.SetError(groupBox1, "Introduceti tipul de persoana(PF/PJ)");
            }
            else if (tbSuma.Text == "")
            {
                errorProvider1.SetError(tbSuma, "Introduceti suma!");
            }
            else if (tbPlati.Text == "")
            {
                errorProvider1.SetError(tbPlati, "Introduceti datele platilor lunare");
            }
            else
            {
                try
                {
                    int c = Convert.ToInt32(tbCod.Text);
                    string n = tbNume.Text;
                    string a = tbAdresa.Text;
                    string t = "";
                    if (rbPF.Checked) t = "PF";
                    else if (rbPJ.Checked) t = "PJ";
                    double s = Convert.ToDouble(tbSuma.Text);
                    string[] vector = tbPlati.Text.Split(',');
                    int[] plati = new int[vector.Length];
                    for (int i = 0; i < vector.Length; i++)
                    {
                        plati[i] = Convert.ToInt32(vector[i]);
                    }

                    ClientRauPlatnic cli = new ClientRauPlatnic(c, n, a, t, s, plati);
                    client.Add(cli);
                    client.Sort();
                    MessageBox.Show(cli.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbCod.Clear();
                    tbNume.Clear();
                    tbAdresa.Clear();
                    rbPF.Checked = false;
                    rbPJ.Checked = false;
                    tbSuma.Clear();
                    tbPlati.Clear();
                    errorProvider1.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(client);
            frm.ShowDialog();
        }

        private void golireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.SourceControl.Text = string.Empty;
        }

        private void tbCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') e.Handled = false;
            else e.Handled = true;
        }


    }
}
