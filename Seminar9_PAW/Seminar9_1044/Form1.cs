using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar9_1044
{
    public partial class Form1 : Form
    {
        int h = 10;
        string[] student = { "Gigel", "Ionel", "Marcel" };
        Student[] vectStud = { new Student("Andrei"), new Student("Ionel"), new Student("Edy") };
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None; 
            if ((e.KeyState & 8) == 8 && 
            (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) 
                e.Effect = DragDropEffects.Copy;
            else
                if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
                e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(typeof(string)).ToString();
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            g.DrawString(text, this.Font, new SolidBrush(Color.Red), 10, h);
            h += 10;
            if (e.Effect == DragDropEffects.Move)
            {
                textBox1.Text = "";
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Binding b = new Binding("Text", student, "");
            comboBox1.DataBindings.Add(b);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.DataSource = student;
            for (int i = 0; i < student.Length; i++)
            {
                listBox1.Items.Add(student[i]);
            }
            dataGridView1.DataSource = vectStud;
            //listBox1.DataSource = student;

            DataTable dt = new DataTable();
            dt.Columns.Add("Culori");
            dt.Rows.Add("Alb");
            dt.Rows.Add("Verde");
            dt.Rows.Add("Cacaniu");
            dt.Rows.Add("EDY E FORTE PROST");

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Culori";
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
