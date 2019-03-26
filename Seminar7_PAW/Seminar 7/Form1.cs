using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Seminar_7
{
    public partial class Form1 : Form
    {

        List<Student> lista = new List<Student>();
 

        public Form1()
        {
            InitializeComponent();
            InitializareList();
            InitializareTree();
        }

        public void InitializareList()
        {
            StreamReader sr = new StreamReader("fisier.txt");
            string linie = null;
            while((linie = sr.ReadLine()) != null)
            {
                try
                {
                    int cod = Convert.ToInt32(linie.Split(',')[0]);
                    string nume = linie.Split(',')[1];
                    int nota = Convert.ToInt32(linie.Split(',')[2]);
                    Student s = new Student(cod, nume, nota);
                    lista.Add(s);
                    MessageBox.Show(s.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Avem o mica eroare si anume " + ex);
                }
            }
            sr.Close();
        }

        public void InitializareTree()
        {
            TreeNode parinte = new TreeNode("Studenti");
            treeView1.Nodes.Add(parinte);

            foreach (Student s in lista)
            {
                TreeNode copil = new TreeNode(s.cod + "-" + s.nume + "-" + s.nota);
                parinte.Nodes.Add(copil);

                TreeNode nepot = new TreeNode();
                if (s.nota > 8)
                {
                    nepot.Text = "Excelent";
                }
                else nepot.Text = "Bunicel";

                copil.Nodes.Add(nepot);
            }
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.Nodes.Count > 0 )
            {
                TreeNode nodSelectat = treeView1.SelectedNode;
                int cod;
                try
                {
                    cod = Convert.ToInt32(nodSelectat.Text.Split('-')[0]);
                    foreach (Student s in lista)
                        if (s.cod == cod) textBox1.Text += s.ToString() + Environment.NewLine;
                }
                catch
                {
                    cod = 0;
                }
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.Nodes.Count > 0 )
            {
                TreeNode nodSelectat = treeView1.SelectedNode;
                if (nodSelectat.NextNode != null)
                {
                    nodSelectat = treeView1.SelectedNode.NextNode;
                }
                else if (nodSelectat.PrevNode != null)
                {
                    nodSelectat = treeView1.SelectedNode.PrevNode;
                }
                treeView1.SelectedNode.Remove();
                treeView1.SelectedNode = nodSelectat;
            
            }
        }

        private void reincarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializareTree();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();

            foreach (TreeNode parinte in treeView1.Nodes)
            {
                writer.WriteStartElement(parinte.Text);
                foreach (TreeNode copil in parinte.Nodes)
                {
                    writer.WriteStartElement(copil.Text.Trim().Split('-')[1]);
                    writer.WriteValue(copil.Text.Split('-')[2].Trim());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            writer.WriteEndDocument();

            writer.Close();

            string xml = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            StreamWriter sw = new StreamWriter("export.xml");
            sw.WriteLine(xml);
            sw.Close();
        }

        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(lista);
            frm.ShowDialog();
        }
    }
}
