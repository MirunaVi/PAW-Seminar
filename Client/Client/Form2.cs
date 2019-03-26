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

namespace Client
{
    public partial class Form2 : Form
    {
        ArrayList lista = new ArrayList();
        public Form2(ArrayList client)
        {
            InitializeComponent();
            lista = client;
            foreach(ClientRauPlatnic c in client)
            {
                tbAfiseaza.Text += c.ToString() + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter sw = new StreamWriter(path + @"\export.txt"))
            {
                foreach (ClientRauPlatnic cli in lista)
                {
                    sw.WriteLine(cli.cod);
                    sw.WriteLine(cli.nume);
                    sw.WriteLine(cli.adresa);
                    sw.WriteLine(cli.tipClient);
                    sw.WriteLine(cli.sumaPlata);
                    for (int i = 0; i < cli.vectorPlatiLunare.Length; i++)
                        sw.WriteLine(cli.vectorPlatiLunare[i]);
                }
                MessageBox.Show("Succes!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(lista);
            frm.ShowDialog();
        }
    }
}
