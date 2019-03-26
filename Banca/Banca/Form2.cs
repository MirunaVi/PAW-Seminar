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

namespace Banca
{
    [Serializable]
    public partial class Form2 : Form
    {
        public Form2(List<BancaComerciala> lista)
        {
            InitializeComponent();
            foreach(BancaComerciala bc in lista)
            {
                tbInregistrari.Text += bc.ToString() + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, tbInregistrari.Text);
                fs.Close();
                MessageBox.Show("Succes!");
            }
        }
    }
}
1