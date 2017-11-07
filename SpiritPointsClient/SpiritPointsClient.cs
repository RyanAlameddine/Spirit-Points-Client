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

            SheetsManager.AddPoints((float) SpiritPointValue.Value, dataHandler.grades[currentSubmission.grade], currentSubmission.date);
            dataHandler.ReadCount++;

            NextSubmission();
        }

        private void Deny_Click(object sender, EventArgs e)
        {
            if (currentSubmission == null) return;
            dataHandler.ReadCount++;

            NextSubmission();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            dataHandler.LoadData();
            NextSubmission();
        }

        void NextSubmission()
        {
            Submission submission = dataHandler.NextPicture(Remaining);
            if(submission == null)
            {
                PictureBox.Image = null;
                return;
            }
            PictureBox.Image = Image.FromFile(submission.path);
            name .Text = "Name: "  + submission.name;
            Grade.Text = "Grade: " + submission.grade;
            Date .Text = "Date: "  + submission.date;
            currentSubmission = submission;
        }
    }
}
