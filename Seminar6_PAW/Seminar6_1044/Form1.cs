using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar6_1044
{
    public partial class Form1 : Form
    {
        ArrayList lista = new ArrayList();

        float procentDobanda = 0.15f;
        float grad_indatorare = 0.7f;
        public Form1()
        {
            InitializeComponent();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tbPerioada.Text = vScrollBar1.Value.ToString();
        }

        private void tbPerioada_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vScrollBar1.Value = Convert.ToInt32(tbPerioada.Text);
            }
            catch
            {
                vScrollBar1.Value = 0;
            }
        }

        private void procentDobandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                procentDobanda = 0.12f;
            } else
            {
                procentDobanda = 0.15f;
            }
            MessageBox.Show("Dobanda este: " + procentDobanda);
        }

        private void gradIndatoarareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked == false) && (radioButton2.Checked == false)) {
                MessageBox.Show("Va rugam selectati starea civila!");
            } else
            {
                if (radioButton1.Checked)
                {
                    grad_indatorare = 0.5f;
                }
                else if (radioButton2.Checked)
                {
                    grad_indatorare = 0.7f;
                }
                MessageBox.Show("Gradul de indatoarare este: " + grad_indatorare);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbSuma.Text == "") errorProvider1.SetError(tbSuma, "Introduceti suma creditului!");
            else
               if (tbVenit.Text == "") errorProvider1.SetError(tbVenit, "Introduceti venitul net!");
            else
                   if (tbPerioada.Text == "") errorProvider1.SetError(tbPerioada, "Selectati perioada in ani!");
            else
            {
                double creditMaxim;
                try
                {
                    creditMaxim = Convert.ToDouble(tbVenit.Text) * grad_indatorare * Convert.ToInt32(tbPerioada.Text) * 12 * (1 + procentDobanda);
                    if (creditMaxim < Convert.ToInt32(tbSuma.Text))
                    {
                        MessageBox.Show("Suma ceruta este prea mare!", creditMaxim.ToString());
                    } else
                    {
                        tbRata.Text = Convert.ToString((Convert.ToInt32(tbSuma.Text) / Convert.ToInt32(tbPerioada.Text) / 12) * (1 + procentDobanda));


                        Credit cr = new Credit();
                        cr.Dobanda = (float)procentDobanda;
                        cr.Suma = Convert.ToInt32(tbSuma.Text);
                        cr.Perioada = Convert.ToInt32(tbPerioada.Text);
                        cr.Rata = (float)Convert.ToDouble(tbRata.Text);
                        lista.Add(cr);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void calculeazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(lista);
            frm.ShowDialog();
        }

        private void salveazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("fisier.txt");
            foreach(Credit cr in lista)
            {
                sw.WriteLine(cr.ToString());
            }
            sw.Close();
        }
    }
}
