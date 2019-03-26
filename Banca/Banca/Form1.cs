using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banca
{
    public partial class Form1 : Form
    {

        List<BancaComerciala> lista = new List<BancaComerciala>();

        public Form1()
        {
            InitializeComponent();
            int[] vector = { 2, 4, 5, 10, 9 };
            BancaComerciala bc1 = new BancaComerciala(100, "BCR", "Romana Square", 10999, 45, vector);
            BancaComerciala bc2 = new BancaComerciala(101, "BRD", "Romana Square", 4999, 35, vector);
            BancaComerciala bc3 = new BancaComerciala(102, "BT", "Romana Square", 5000, 30, vector);
            lista.Add(bc1);
            lista.Add(bc2);
            lista.Add(bc3);
            lista.Sort();
    }

        private void button1_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(tbCod.Text);
            string d = tbDenumire.Text;
            string a = tbAdresa.Text;
            double cs = Convert.ToDouble(tbCapital.Text);
            int na = Convert.ToInt32(tbAgentii.Text);
            string[] vector = tbClienti.Text.Split(',');
            int[] clienti = new int[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                clienti[i] = Convert.ToInt32(vector[i]);
            }

            BancaComerciala b = new BancaComerciala(c, d, a, cs, na, clienti);
            lista.Add(b);
            lista.Sort();
            MessageBox.Show("Succes!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(lista);
            frm.ShowDialog();
        }

        private void modificareCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.ForeColor = dlg.Color;
            }
        }
    }
}
