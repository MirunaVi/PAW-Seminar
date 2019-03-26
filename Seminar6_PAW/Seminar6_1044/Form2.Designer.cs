namespace Seminar6_1044
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_afisare = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_afisare
            // 
            this.tb_afisare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_afisare.Location = new System.Drawing.Point(0, 0);
            this.tb_afisare.Multiline = true;
            this.tb_afisare.Name = "tb_afisare";
            this.tb_afisare.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_afisare.Size = new System.Drawing.Size(284, 261);
            this.tb_afisare.TabIndex = 0;
            this.tb_afisare.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tb_afisare);
            this.Name = "Form2";
            this.Text = "Afisare Credite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_afisare;
    }
}