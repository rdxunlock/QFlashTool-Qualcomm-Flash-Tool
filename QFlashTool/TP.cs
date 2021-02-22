using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QFlashTool
{
	public class TP : Form
	{
		public static string id;

		private IContainer components = null;

		private PictureBox pictureBox1;

		public static string ID => id;

		public TP()
		{
			InitializeComponent();
		}

		private void TP_Load(object sender, EventArgs e)
		{
			string text = "data\\testpoints\\" + ID;
			if (File.Exists(text))
			{
				pictureBox1.Image = Image.FromFile(text);
			}
		}

		public static List<string> List()
		{
			List<string> list = new List<string>();
			if (!Directory.Exists("data\\testpoints"))
			{
				return list;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo("data\\testpoints");
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				list.Add(fileInfo.Name);
			}
			return list;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QFlashTool.TP));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(470, 370);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(470, 370);
			base.Controls.Add(pictureBox1);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "TP";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "9008 Testpoint";
			base.Load += new System.EventHandler(TP_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
