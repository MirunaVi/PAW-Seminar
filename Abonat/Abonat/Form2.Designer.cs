namespace Abonat
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
            this.tbInregistrari = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbInregistrari
            // 
            this.tbInregistrari.Location = new System.Drawing.Point(13, 13);
            this.tbInregistrari.Multiline = true;
            this.tbInregistrari.Name = "tbInregistrari";
            this.tbInregistrari.Size = new System.Drawing.Size(775, 377);
            this.tbInregistrari.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(380, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Salveaza in TXT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbInregistrari);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInregistrari;
        private System.Windows.Forms.Button button1;
    }
}