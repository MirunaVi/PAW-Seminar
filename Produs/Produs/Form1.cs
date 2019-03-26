using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Produs
{
    public partial class Form1 : Form
    {

        List<ProdusAlimentar> lista = new List<ProdusAlimentar>();

        public Form1()
        {
            InitializeComponent();

            float[] v = { 15, 20, 17, 16 };
            ProdusAlimentar p1 = new ProdusAlimentar(1, "Mozzarela", 20, "Almond", "01/01/2019", v);
            ProdusAlimentar p2 = new ProdusAlimentar(2, "Banane", 100, "Martinica", "01/06/2018", v);
            ProdusAlimentar p3 = new ProdusAlimentar(3, "Nelutu", 1, "Andrei", "niciodata", v);
            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(tbCod.Text);
            string d = tbDenumire.Text;
            int ct = Convert.ToInt32(tbCantitate.Text);
            string p = tbProducator.Text;
            string data = tbExpirare.Text;

            string[] vector = tbVector.Text.Trim().Split(',');
            float[] vP = new float[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                vP[i] = (float)Convert.ToDouble(vector[i]);
            }

            ProdusAlimentar pa = new ProdusAlimentar(c, d, ct, p, data, vP);
            lista.Add(pa);
            lista.Sort();
            tbCantitate.Clear();
            tbCod.Clear();
            tbDenumire.Clear();
            tbExpirare.Clear();
            tbProducator.Clear();
            tbVector.Clear();

            MessageBox.Show(pa.ToString() + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(lista);
            frm.ShowDialog();
        }

        private void golireCampToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.SourceControl.Text = string.Empty;
        }
    }
}
