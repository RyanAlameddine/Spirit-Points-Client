using System;
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
    public partial class SpiritPointsClient : Form
    {
        int[] scores = new int[5];
        DataHandler dataHandler = new DataHandler();

        Submission currentSubmission;

        public SpiritPointsClient()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            if (currentSubmission == null) return;

            SheetsManager.AddPoints(currentSubmission.grade, (float) SpiritPointValue.Value, currentSubmission.name, EventBox.Text);
            dataHandler.ReadCount++;
            EventBox.Text = "";

            NextSubmission();
        }

        private void Deny_Click(object sender, EventArgs e)
        {
            if (currentSubmission == null) return;
            EventBox.Clear();
            dataHandler.ReadCount++;

            NextSubmission();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            dataHandler.LoadData();
            EventBox.Clear();
            NextSubmission();
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
