using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar_7
{
    public partial class Form2 : Form
    {
        public Form2(List<Student> lista)
        {
            InitializeComponent();

            foreach(Student s in lista)
            {
                ListViewItem itm = new ListViewItem(s.cod.ToString());
                itm.SubItems.Add(s.cod.ToString());
                itm.SubItems.Add(s.nume);
                itm.SubItems.Add(s.cod.ToString());
                listView1.Items.Add(itm);
            }
        }

        private void culoareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.BackColor = dlg.Color;
            }
        }
    }
}
