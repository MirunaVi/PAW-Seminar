using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar10_1044
{
    public partial class Form2 : Form
    {
        string provider;
        public Form2()
        {
            InitializeComponent();
            provider = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = student.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(provider);
            OleDbCommand comanda = new OleDbCommand();

            try
            {
                conexiune.Open();
                comanda.CommandText = "SELECT MAX(cod) FROM student";
                comanda.Connection = conexiune;
                int cod = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO student VALUES(?,?,?,?,?,?,?)";
                //comanda.CommandText = "INSERT INTO student VALUES(@cod,@nume,@varsta,@inaltime,@CNP,@sex,@forma)";
                comanda.Parameters.Add("cod", OleDbType.Integer).Value = cod + 1;
                //comanda.Parameters.Add("@cod", SqlDbType.Int).Value = cod + 1;
                comanda.Parameters.Add("nume", OleDbType.Char, 10).Value = tbNume.Text;
                //comanda.Parameters.Add("@nume", SqlDbType.Char, 10).Value = tbNume.Text;
                comanda.Parameters.Add("varsta", OleDbType.Integer).Value = Convert.ToInt32(tbVarsta.Text);
                //comanda.Parameters.Add("@varsta", SqlDbType.Int).Value = Convert.ToInt32(tbVarsta.Text);
                comanda.Parameters.Add("inaltime", OleDbType.Integer).Value = Convert.ToInt32(tbInaltime.Text);
                //comanda.Parameters.Add("@inaltime", SqlDbType.Int).Value = Convert.ToInt32(tbInaltime.Text);
                comanda.Parameters.Add("CNP", OleDbType.Char, 13).Value = tbCNP.Text;
                //comanda.Parameters.Add("@CNP", SqlDbType.Char, 13).Value = tbCNP.Text;
                comanda.Parameters.Add("sex", OleDbType.Char, 2).Value = cbSex.Text;
                //comanda.Parameters.Add("@sex", SqlDbType.Char, 2).Value = cbSex.Text;
                comanda.Parameters.Add("forma", OleDbType.Char, 10).Value = cbForma.Text;
                //comanda.Parameters.Add("@forma", SqlDbType.Char, 10).Value = cbForma.Text;
                comanda.ExecuteNonQuery();
                MessageBox.Show("Student adaugat!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNume.Clear();
                tbVarsta.Clear();
                tbInaltime.Clear();
                tbCNP.Clear();
                cbSex.Text = "";
                cbForma.Text = "";
            }
        }
    }
}
