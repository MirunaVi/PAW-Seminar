using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Seminar4_PAW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("nbrfxrates.xml");
            // Trebuie sa mentinem tot ce citim cu StreamReader din fisier intr-un string pe care il parsam cu XML-ul.
            string str = sr.ReadToEnd();
            sr.Close();

            XmlReader reader = XmlReader.Create(new StringReader(str));
            while(reader.Read()) {
                if (reader.Name == "PublishingDate" && reader.NodeType == XmlNodeType.Element)
                {
                    reader.Read();
                    tbData.Text = reader.Value;
                }
                else if (reader.Name == "Rate")
                {
                    string attribute = reader["currency"]; // Operator index de tip sir de caractere in care furnizez numele atributului.
                    if (attribute == "EUR")
                    {
                        reader.Read();
                        tbEUR.Text = reader.Value;
                    }
                    else if (attribute == "USD")
                    {
                        reader.Read();
                        tbUSD.Text = reader.Value;
                    }
                    else if (attribute == "GBP")
                    {
                        reader.Read();
                        tbGBP.Text = reader.Value;
                    }
                    else if (attribute == "XAU")
                    {
                        reader.Read();
                        tbXAU.Text = reader.Value;
                    }
                    else if (attribute == "NOK")
                    {
                        reader.Read();
                        tbNOK.Text = reader.Value;
                    }
                    else if (attribute == "AUD") {
                        reader.Read();
                        tbAUD.Text = reader.Value;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8);

            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("CursBNR");

            writer.WriteStartElement("Data_Curs");
            writer.WriteValue(tbData.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("EUR");
            writer.WriteValue(tbEUR.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("USD");
            writer.WriteValue(tbUSD.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("GBP");
            writer.WriteValue(tbGBP.Text);
            writer.WriteEndElement();

            writer.WriteStartElement("XAU");
            writer.WriteValue(tbXAU.Text);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            string xmlString = Encoding.UTF8.GetString(mem.ToArray());

            mem.Close();

            File.WriteAllText("seminar_4.xml", xmlString);
            MessageBox.Show("Succes");

             
            // Streamwriter sw = new StreamWriteR("fisier.xml);
            // s2.WriteLine(xml);
            // s2.Close() 
              
              
             
        }
    }
}
