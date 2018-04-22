﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritPointsClient
{
    public partial class SpiritPointsClient : Form
    {
        int[] scores = new int[5];
        DataHandler dataHandler = new DataHandler();

        Submission currentSubmission;

        public static PictureBox submissionPictureBox;

        public SpiritPointsClient()
        {
            InitializeComponent();
            submissionPictureBox = PictureBox;
            new Password().ShowDialog();
            if (!FTPManager.Connected())
            {
                Enabled = false;
            }

            Version.Text = Application.ProductVersion;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (currentSubmission == null) return;
            DeleteFile();
            SheetsManager.AddPoints(currentSubmission.grade, (float) SpiritPointValue.Value, currentSubmission.name, EventBox.Text);
            dataHandler.ReadCount++;
            EventBox.Text = "";

            NextSubmission();
        }

        private void Deny_Click(object sender, EventArgs e)
        {
            if (currentSubmission == null) return;
            DeleteFile();
            EventBox.Clear();
            dataHandler.ReadCount++;

            NextSubmission();
        }

        private void DeleteFile()
        {
            string path = $"/home/DataPath/Pictures/{currentSubmission.grade}/{currentSubmission.name}.{currentSubmission.fileNumber}{Path.GetExtension(currentSubmission.path)}";
            new Task(() => FTPManager.DeleteFile(path)).Start();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press ok to start downloading and processing images. This may take a few minutes if the connection is slow due to large amounts of processing. Thanks, Ryan Alameddine (rhalameddine@gmail.com) ( (626) 493-3030 ).");
            Cursor = Cursors.WaitCursor;
            Enabled = false;
            FTPManager.DownloadAll();
            dataHandler.LoadData();
            EventBox.Clear();
            NextSubmission();
            Enabled = true;
            Cursor = Cursors.Default;
        }

        void NextSubmission()
        {
            Submission submission = dataHandler.NextPicture(Remaining);
            currentSubmission = submission;
            if (submission == null)
            {
                PictureBox.Image = null;
                name .Text = "Name:";
                Grade.Text = "Grade:";
                Date .Text = "Date:";

                Remaining.Text = "Remaining: 0";

                return;
            }
            PictureBox.Image = Image.FromFile(submission.path);
            name .Text = "Name: "  + submission.name;
            Grade.Text = "Grade: " + submission.grade;
            Date .Text = "Date: "  + submission.date;
        }

        private void SettingsAndReset_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
