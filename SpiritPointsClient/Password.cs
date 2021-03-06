﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritPointsClient
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Password_Load(object sender, EventArgs e)
        {

        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            FTPManager.Password = PasswordBox.Text;
            FTPManager.Host = "www.spiritpoints.org";
            if(ip.Text != "")
            {
                string[] line = new string[] { ip.Text };
                File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "SpreadSheetId.txt"), line);
            }
            if (FTPManager.Connected())
            {
                Close();
            }
            else
            {
                PasswordBox.Text = "";
                MessageBox.Show("Password or Ip Address is incorrect. Please view the Instruction docs for the information.");
            }
        }

        //private void CloseAndOpen()
        //{
        //    this.Hide();
        //    var spc = new SpiritPointsClient();
        //    spc.Closed += (s, args) => this.Close();
        //    spc.Show();
        //}
    }
}
