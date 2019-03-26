using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Produs
{
    [Serializable]
    public partial class Form2 : Form
    {
        
        public Form2(List<ProdusAlimentar> lista)
        {
            InitializeComponent();

            foreach (ProdusAlimentar pa in lista)
            { 
                tbProduse.Text += pa.ToString() + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, tbProduse.Text);
                fs.Close();
                MessageBox.Show("Fisier salvat cu succes!");
            }
        }
    }
}
