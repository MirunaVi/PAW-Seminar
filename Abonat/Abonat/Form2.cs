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

namespace Abonat
{
    public partial class Form2 : Form
    {
        ArrayList listaNoua = new ArrayList();
        public Form2(ArrayList lista)
        {
            InitializeComponent();
            listaNoua = lista;
            foreach(AbonatTelefonic at in listaNoua)
            {
                tbInregistrari.Text += at.ToString() + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter sw = new StreamWriter(path + @"\export.txt"))
            {
                foreach(AbonatTelefonic at in listaNoua)
                {
                    sw.WriteLine(tbInregistrari.Text);
                }
                MessageBox.Show("Export realizat cu succes!");
            }
        }
    }
}
