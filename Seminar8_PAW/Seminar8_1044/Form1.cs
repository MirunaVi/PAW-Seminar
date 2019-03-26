
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminar8_1044
{
    public partial class Form1 : Form
    {

        int nrElem = 0;
        double[] vector = new double[100];
        bool vb = false;
        const int marg = 10;
        Font font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        Color culoare = Color.Blue;


        public Form1()
        {
            InitializeComponent();
        }

        private void construiesteGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("date.txt");
            string linie = null;
            while ((linie = sr.ReadLine()) != null) {
                vector[nrElem] = Convert.ToDouble(linie);
                nrElem++;
                vb = true;
            }
            sr.Close();

            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (vb == true)
            {
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Red, 3);
                Rectangle rec = new Rectangle(panel1.Location.X + marg,
                        panel1.Location.Y + 4 * marg,
                        panel1.Width - 2 * marg,
                        panel1.Height - 5 * marg);

                g.DrawRectangle(pen, rec);

                Rectangle[] dreptunghiuri = new Rectangle[nrElem];
                g.DrawRectangles(pen, dreptunghiuri);

                double latime = rec.Width / nrElem / 3;
                double distanta = (rec.Width - latime * nrElem) / (nrElem + 1);
                double vmax = vector.Max();

                Brush br = new SolidBrush(culoare);

                for (int i = 0; i <nrElem; i++)
                {
                    dreptunghiuri[i] = new Rectangle(
                        (int)(rec.Left + (i + 1) * distanta + i * latime),
                        (int)(rec.Bottom - vector[i] / vmax * rec.Height),
                        (int)latime,
                        (int)(vector[i] / vmax * (rec.Bottom - rec.Top)));

                    g.DrawString(Convert.ToString(vector[i]),
                        font, 
                        br, 
                        (int)(rec.Left + (i+1)*distanta + i*latime + latime/2), 
                        (int)(rec.Bottom - vector[i] / vmax * (rec.Bottom - rec.Top) - font.Height - 5));
                }
                for (int i = 0; i < nrElem - 1; i++)
                    g.DrawLine(pen, dreptunghiuri[i].Location,
                        dreptunghiuri[i + 1].Location);

                g.FillRectangles(br, dreptunghiuri);
            }
            Invalidate();
        }

        void pd_print(object sender, PrintPageEventArgs e)
        {
            if (vb == true)
            {
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Red, 3);
                Rectangle rec = new Rectangle(e.PageBounds.X + marg,
                        e.PageBounds.Y + 4 * marg,
                        e.PageBounds.Width - 2 * marg,
                        e.PageBounds.Height - 5 * marg);

                g.DrawRectangle(pen, rec);

                Rectangle[] dreptunghiuri = new Rectangle[nrElem];
                g.DrawRectangles(pen, dreptunghiuri);

                double latime = rec.Width / nrElem / 3;
                double distanta = (rec.Width - latime * nrElem) / (nrElem + 1);
                double vmax = vector.Max();

                Brush br = new SolidBrush(culoare);

                for (int i = 0; i < nrElem; i++)
                {
                    dreptunghiuri[i] = new Rectangle(
                        (int)(rec.Left + (i + 1) * distanta + i * latime),
                        (int)(rec.Bottom - vector[i] / vmax * rec.Height),
                        (int)latime,
                        (int)(vector[i] / vmax * (rec.Bottom - rec.Top)));

                    g.DrawString(Convert.ToString(vector[i]),
                        font,
                        br,
                        (int)(rec.Left + (i + 1) * distanta + i * latime + latime / 2),
                        (int)(rec.Bottom - vector[i] / vmax * (rec.Bottom - rec.Top) - font.Height - 5));
                }
                for (int i = 0; i < nrElem - 1; i++)
                    g.DrawLine(pen, dreptunghiuri[i].Location,
                        dreptunghiuri[i + 1].Location);

                g.FillRectangles(br, dreptunghiuri);
            }
            Invalidate();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_print);
            PrintPreviewDialog pdlg = new PrintPreviewDialog();
            pdlg.Document = pd;
            pdlg.ShowDialog();
        }

        public void save(Control control, string fisier)
        {
            Graphics gr = control.CreateGraphics();
            Bitmap bmp = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bmp, new
                Rectangle(0, 0, control.Width, control.Height));
            bmp.Save(fisier);
            bmp.Dispose();
        }

        private void salvareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(panel1, "poza.bmp");
            MessageBox.Show("Imagine salvata cu succes!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void construiesteSpecificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);
                vb = true;
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    vector[nrElem] = Convert.ToDouble(linie);
                    nrElem++;
                }
            }
            panel1.Invalidate();
        }

        private void schimbaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                font = dlg.Font;
            panel1.Invalidate();
        }

        private void schimbaCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                culoare = dlg.Color;
            panel1.Invalidate();
        }
    }
}

