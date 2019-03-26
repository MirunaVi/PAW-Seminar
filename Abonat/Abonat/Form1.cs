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

namespace Abonat
{
    public partial class Form1 : Form
    {
        ArrayList lista = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            lista.Add(new AbonatTelefonic(1971002038704, "Andrei", "Romana Square", 0752171311, "Gold", new double[] { 22, 23.1, 0.6, 3 }));
            lista.Add(new AbonatTelefonic(1971002038703, "Edy", "Romana Square", 0752171313, "Silver", new double[] { 22, 23.1, 0.6, 3 }));
            lista.Add(new AbonatTelefonic(1971002038702, "Alex", "Unirii Square", 0752171310, "Platinum", new double[] { 22, 23.1, 0.6, 3 }));
            lista.Sort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(lista);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCNP.Text == "")
            {
                errorProvider1.SetError(tbCNP, "Introduceti CNP-ul!");
            }
            else if (tbNume.Text == "")
            {
                errorProvider1.SetError(tbNume, "Introduceti Numele!");
            }
            else if (tbAdresa.Text == "")
            {
                errorProvider1.SetError(tbAdresa, "Introduceti Adresa!");
            }
            else if (tbNumar.Text == "")
            {
                errorProvider1.SetError(tbNumar, "Introduceti Numarul");
            }
            else if (tbTip.Text == "")
            {
                errorProvider1.SetError(tbTip, "Introdcueti tipul abonatului!");
            }
            else if (tbVector.Text == "")
            {
                errorProvider1.SetError(tbVector, "Introduceti datele referitoarele la minutele vorbite!");
            }
            else
            {
                try
                {
                    errorProvider1.Clear();
                    long c = Convert.ToInt64(tbCNP.Text);
                    string n = tbNume.Text;
                    string a = tbAdresa.Text;
                    long nr = Convert.ToInt64(tbNumar.Text);
                    string tip = tbTip.Text;

                    string[] vector = tbVector.Text.Trim().Split(',');
                    double[] minute = new double[vector.Length];
                    for (int i = 0; i < vector.Length; i++)
                    {
                        minute[i] = Convert.ToDouble(vector[i]);
                    }
                    AbonatTelefonic abonat = new AbonatTelefonic(c, n, a, nr, tip, minute);
                    lista.Add(abonat);
                    lista.Sort();
                    MessageBox.Show("Abonat adaugat cu succes!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbCNP.Clear();
                    tbNumar.Clear();
                    tbNume.Clear();
                    tbAdresa.Clear();
                    tbTip.Clear();
                    tbVector.Clear();
                    errorProvider1.Clear();
                }
            }
        }

        private void tbCNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') e.Handled = false;
            else e.Handled = true;
        }

        private void tbNumar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') e.Handled = false;
            else e.Handled = true;
        }

        private void tbVector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == ',') e.Handled = false;
            else e.Handled = true;
        }

        private void golireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.SourceControl.Text = string.Empty;
        }
    }
}
