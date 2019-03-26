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

namespace Seminar5_1044
{
    public partial class Form1 : Form
    {

        ArrayList listaTextBoxes = new ArrayList();
        ArrayList listaProduse = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            listaTextBoxes.Add(tb_denumire);
            listaTextBoxes.Add(tb_pret);
            listaTextBoxes.Add(tb_cantitate);
            listaTextBoxes.Add(tb_valoare);
            tb_cantitate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pret_KeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = ((TextBox)listaTextBoxes[0]).Location.X;
            int y = ((TextBox)listaTextBoxes[listaTextBoxes.Count - 1]).Location.Y;
            int dist = ((TextBox)listaTextBoxes[1]).Location.X - ((TextBox)listaTextBoxes[0]).Location.X;

            for (int i = 0; i < 4; i++)
            {
                TextBox tb_nou = new TextBox();
                tb_nou.Location = new Point(x, y + 30);
                x += dist;
                if ((i == 1) || (i==2))
                {
                    tb_nou.KeyPress += new KeyPressEventHandler(tb_pret_KeyPress);
                }
                if (i == 3) tb_nou.ReadOnly = true;
                Controls.Add(tb_nou);
                listaTextBoxes.Add(tb_nou);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            float total = 0;
            for (int i = 0; i < listaTextBoxes.Count; i += 4)
            {
                if (((TextBox)listaTextBoxes[i]).Text == "")
                {
                    errorProvider1.SetError((TextBox)listaTextBoxes[i], "Introduceti Denumirea");
                } else if (((TextBox)listaTextBoxes[i + 1]).Text == "")
                {
                    errorProvider1.SetError((TextBox)listaTextBoxes[i + 1], "Introduceti Cantitate");
                } else if (((TextBox)listaTextBoxes[i + 2]).Text == "")
                {
                    errorProvider1.SetError((TextBox)listaTextBoxes[i + 2], "Introduce3ti Suma");
                } else {
                    errorProvider1.Clear();
                    string denumire = ((TextBox)listaTextBoxes[i]).Text;
                    int pret = Convert.ToInt32(((TextBox)listaTextBoxes[i + 1]).Text);
                    int cantitate = Convert.ToInt32(((TextBox)listaTextBoxes[i + 2]).Text);

                    Produs p = new Produs(denumire, pret, cantitate);
                    listaProduse.Add(p);

                    int valoare = pret * cantitate;
                    total += valoare;
                    ((TextBox)listaTextBoxes[i + 3]).Text = valoare.ToString();
                }
            }
            tb_total.Text = total.ToString();


        }

        private void tb_pret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8)
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
