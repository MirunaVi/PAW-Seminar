using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Seminar10_1044
{
    public partial class Form1 : Form
    {

        string provider;

        public Form1()
        {
            InitializeComponent();
            provider = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = student.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(provider);
            OleDbCommand comanda = new OleDbCommand("SELECT * FROM student", conn);
            listView1.Items.Clear();

            try
            {
                conn.Open();
                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem itm = new ListViewItem(reader["Cod"].ToString());
                    itm.SubItems.Add(reader["Nume"].ToString());
                    itm.SubItems.Add(reader["Varsta"].ToString());
                    itm.SubItems.Add(reader["Inaltime"].ToString());
                    itm.SubItems.Add(reader["CNP"].ToString());
                    itm.SubItems.Add(reader["Sex"].ToString());
                    itm.SubItems.Add(reader["Forma"].ToString());
                    listView1.Items.Add(itm);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(provider);
            OleDbCommand comanda = new OleDbCommand();

            foreach (ListViewItem itm in listView1.Items)
                if (itm.Checked == true)
                {
                    try
                    {
                        conexiune.Open();
                        int cod = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "DELETE FROM student WHERE cod=" + cod + "";
                        comanda.Connection = conexiune;
                        comanda.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conexiune.Close();
                    }
                }
            listView1.Items.Clear();
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(provider);
            OleDbCommand comanda = new OleDbCommand();

            foreach (ListViewItem itm in listView1.Items)
                if (itm.Selected == true)
                {
                    try
                    {
                        conexiune.Open();
                        int cod = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "UPDATE student SET forma='FF' WHERE cod=" + cod + "";
                        comanda.Connection = conexiune;
                        comanda.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conexiune.Close();
                    }
                }
            listView1.Items.Clear();
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

    }
}
