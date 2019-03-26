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

namespace PAW_Seminar3
{

    public partial class Form1 : Form
    {

        ArrayList listaStud = new ArrayList();
        ArrayList listaMedii = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string n = tbNume.Text;
                int v = Convert.ToInt32(tbVarsta.Text);
                string[] noteS = tbNote.Text.Trim().Split(',');

                int[] note = new int[noteS.Length];
                for(int i=0;i<noteS.Length;i++)
                {
                    note[i] = Convert.ToInt32(noteS[i]);
                }

                Student s = new Student(n, v, note);
                listaStud.Add(s);
                MessageBox.Show("Student adaugat! " + s.ToString());
                //tbNume.Text"";...
                tbNote.Clear();
                tbNume.Clear();
                tbVarsta.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AfisareColectie(object sender, EventArgs e)
        {
            string result = null;
            foreach(Student s in listaStud)
            {
                result += s.ToString() + Environment.NewLine;
            }
            MessageBox.Show(result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList listaNoua = new ArrayList();
            foreach (Student s in listaStud)
            {
                Student nou = (Student)s.Clone();
                nou += 10;
                listaNoua.Add(nou);
            }
            listaStud = listaNoua;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rezultat = null;
            foreach(Student s in listaStud)
            {
                rezultat += "Media este " + (float)s + Environment.NewLine;
               // MessageBox.Show("Media este: " + (float)s);
            }
            MessageBox.Show(rezultat);
        }
    }
}
