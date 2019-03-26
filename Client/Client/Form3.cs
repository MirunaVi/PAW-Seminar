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
    public partial class Form3 : Form
    {
        ArrayList lista2 = new ArrayList();
        public Form3(ArrayList lista)
        {
            InitializeComponent();
            foreach (ClientRauPlatnic c in lista)
            {
                ListViewItem itm = new ListViewItem(c.cod.ToString());
                itm.SubItems.Add(c.nume);
                itm.SubItems.Add(c.adresa);
                itm.SubItems.Add(c.tipClient);
                itm.SubItems.Add(Convert.ToString(c.sumaPlata));
                itm.SubItems.Add(Convert.ToString(c.vectorPlatiLunare));
                listView1.Items.Add(itm);
            }
        }
    }
}
