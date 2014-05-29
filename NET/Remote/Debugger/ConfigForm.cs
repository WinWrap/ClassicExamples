using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.Win32;

namespace samp
{
	/// <summary>
	/// Summary description for ConfigForm.
	/// </summary>
	public class ConfigForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Form1 m_form1;

		public ConfigForm(Form1 form1)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\Remote\Debugger"))
			{
				txtIPAddress.Text = (string)rk.GetValue("IPAddress", "?.?.?.?");
				txtPort.Text = (string)rk.GetValue("Port", "1000");
			}

			m_form1 = form1;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Address";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(80, 16);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(80, 20);
			this.txtIPAddress.TabIndex = 1;
			this.txtIPAddress.Text = "";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(80, 48);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(80, 20);
			this.txtPort.TabIndex = 3;
			this.txtPort.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(200, 16);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(200, 48);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ConfigForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 86);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtIPAddress);
			this.Controls.Add(this.label1);
			this.Name = "ConfigForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configure Remote Connection";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			int port = 0;
			try
			{
				port = int.Parse(txtPort.Text);
			}
			catch
			{
			}

			if (port <= 0 || port > 65000)
				MessageBox.Show(this, "Invalid port number.");
			else if (m_form1.Initialize(txtIPAddress.Text, port))
			{
				using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\Remote\Debugger"))
				{
					rk.SetValue("IPAddress", txtIPAddress.Text);
					rk.SetValue("Port", txtPort.Text);
				}

				Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
