namespace samp
{
    partial class Form1
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
            this.basicIdeCtl1 = new WinWrap.Basic.BasicIdeCtl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // basicIdeCtl1
            // 
            this.basicIdeCtl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.basicIdeCtl1.BackColor = System.Drawing.Color.White;
            this.basicIdeCtl1.ForeColor = System.Drawing.Color.Black;
            this.basicIdeCtl1.Location = new System.Drawing.Point(0, 26);
            this.basicIdeCtl1.Name = "basicIdeCtl1";
            this.basicIdeCtl1.SelBackColor = System.Drawing.Color.Aqua;
            this.basicIdeCtl1.SelForeColor = System.Drawing.Color.White;
            this.basicIdeCtl1.Size = new System.Drawing.Size(552, 300);
            this.basicIdeCtl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(552, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 326);
            this.Controls.Add(this.basicIdeCtl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinWrap.Basic.BasicIdeCtl basicIdeCtl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

