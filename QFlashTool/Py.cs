using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QFlashTool
{
	public class Py : Form
	{
		private string Url = "";

		private string file = "";

		private IContainer components = null;

		private StatusStrip statusStrip1;

		private ToolStripProgressBar pBar;

		private RichTextBox richTextBox1;

		public Py()
		{
			InitializeComponent();
		}

		private async void Py_Load(object sender, EventArgs e)
		{
			richTextBox1.AppendText(" Detecting system :\t\t");
			if (Environment.Is64BitOperatingSystem)
			{
				richTextBox1.AppendText("x64\n");
				await Task.Delay(500);
				richTextBox1.AppendText(" Checking Network state :\t");
				await Task.Delay(500);
				if (!CheckForInternetConnection())
				{
					richTextBox1.AppendText("No Internet Access");
					await Task.Delay(10000);
					Close();
					return;
				}
				richTextBox1.AppendText("OK\n");
				file = "python-2.7.13.amd64.msi";
				richTextBox1.AppendText(" SaveAs :\t\t" + file + "\n");
				Url = "https://www.python.org/ftp/python/2.7.13/python-2.7.13.amd64.msi";
				richTextBox1.AppendText(" Url :\t\t" + Url + "\n");
				richTextBox1.AppendText(" Downloading :\t");
				DownloadMe(file, Url);
			}
			else
			{
				richTextBox1.AppendText("x86\n");
				await Task.Delay(500);
				richTextBox1.AppendText(" Checking Network state :\t");
				await Task.Delay(500);
				if (!CheckForInternetConnection())
				{
					richTextBox1.AppendText("No Internet Access");
					return;
				}
				richTextBox1.AppendText("OK\n");
				file = "python-2.7.13.msi";
				richTextBox1.AppendText(" SaveAs :\t\t" + file + "\n");
				Url = "https://www.python.org/ftp/python/2.7.13/python-2.7.13.msi";
				richTextBox1.AppendText(" Url :\t\t" + Url + "\n");
				richTextBox1.AppendText("Downloading :\t");
				DownloadMe(file, Url);
			}
		}

		public static bool CheckForInternetConnection()
		{
			try
			{
				using WebClient webClient = new WebClient();
				using (webClient.OpenRead("http://www.google.com"))
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		private void DownloadMe(string string_0, string string_1)
		{
			using WebClient webClient = new WebClient();
			webClient.DownloadProgressChanged += wc_DownloadProgressChanged;
			webClient.DownloadFileCompleted += DownloadFileCallback2;
			try
			{
				webClient.DownloadFileAsync(new Uri(string_1), string_0);
			}
			catch
			{
			}
		}

		private async void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.UserState.ToString());
			}
			else if (!e.Cancelled)
			{
				richTextBox1.AppendText("OK\n");
				await Task.Delay(1000);
				richTextBox1.AppendText("Launch python Installer\n");
				Process.Start(file);
				await Task.Delay(1000);
				Close();
			}
		}

		private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			try
			{
				pBar.Value = e.ProgressPercentage;
			}
			catch
			{
			}
		}

		private void Py_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QFlashTool.Py));
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			pBar = new System.Windows.Forms.ToolStripProgressBar();
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { pBar });
			statusStrip1.Location = new System.Drawing.Point(0, 132);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(471, 22);
			statusStrip1.TabIndex = 0;
			statusStrip1.Text = "statusStrip1";
			pBar.Name = "pBar";
			pBar.Size = new System.Drawing.Size(100, 16);
			richTextBox1.BackColor = System.Drawing.Color.Black;
			richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			richTextBox1.ForeColor = System.Drawing.Color.Lime;
			richTextBox1.Location = new System.Drawing.Point(0, 0);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new System.Drawing.Size(471, 132);
			richTextBox1.TabIndex = 7;
			richTextBox1.Text = "";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(471, 154);
			base.Controls.Add(richTextBox1);
			base.Controls.Add(statusStrip1);
			ForeColor = System.Drawing.Color.Black;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Py";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Python Download";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Py_FormClosing);
			base.Load += new System.EventHandler(Py_Load);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
