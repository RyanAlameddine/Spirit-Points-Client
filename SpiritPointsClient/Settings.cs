using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritPointsClient
{
    public partial class Settings : Form
    {
        public string Middle;
        public string Freshman;
        public string Softmore;
        public string Junior;
        public string Senior;

        public string SpreadSheetID;

        /*
         * 0 - Nothing
         * 1 - Creating Doc
         * 2 - Middle
         * 3 - Freshman
         * 4 - Softmore
         * 5 - Junior
         * 6 - Senior
         */
        
        int state = 0;

        public Settings()
        {
            InitializeComponent();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset.Hide();

            var confirmResult = MessageBox.Show("Are you sure to reset?? This process will start a new record of points", "Confirm Reset!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Info.Show();
                MainBox.Show();
                NextButton.Show();
                Info.Text = "View instructions at \nhttps://goo.gl/ius9Ta\nthen click next";
                RequestNext();
            }
            else
            {
                reset.Show();
            }
        }

        private void RequestNext()
        {
            if (MainBox.Text == "") return;

            if(state == 0)
            {
                //Connect to sheet and create template
                SpreadSheetID = MainBox.Text;
                Program.SpreadSheetId = SpreadSheetID;


                    MainBox.Text = "";
                    Info.Text = "Please enter the name of every student IN MIDDLESCHOOL\nseparated by a line\nI.e. Ryan Alameddine\nJohn Macleod";
                    state++;
            }
            else if (state == 1)
            {
                Middle = MainBox.Text;
                Info.Text = "Please enter the name of every FRESHMAN\nseparated by a line\nI.e. Ryan Alameddine\nJohn Macleod";
                MainBox.Text = "";
                state++;
            }
            else if (state == 2)
            {
                Freshman = MainBox.Text;
                Info.Text = "Please enter the name of every SOFTMORE\nseparated by a line\nI.e. Ryan Alameddine\nJohn Macleod";
                MainBox.Text = "";
                state++;
            }
            else if (state == 3)
            {
                Softmore = MainBox.Text;
                Info.Text = "Please enter the name of every JUNIOR\nseparated by a line\nI.e. Ryan Alameddine\nJohn Macleod";
                MainBox.Text = "";
                state++;
            }
            else if (state == 4)
            {
                Junior = MainBox.Text;
                Info.Text = "Please enter the name of every SENIOR\nseparated by a line\nI.e. Ryan Alameddine\nJohn Macleod";
                MainBox.Text = "";
                state++;
            }
            else if (state == 5)
            {
                Senior = MainBox.Text;
                Info.Text = "Generating google sheets. Please wait.";
                SheetsManager.CreateSheet("Middle"  , Middle  );
                SheetsManager.CreateSheet("Freshman", Freshman);
                SheetsManager.CreateSheet("Softmore", Softmore);
                SheetsManager.CreateSheet("Junior"  , Junior  );
                SheetsManager.CreateSheet("Senior"  , Senior  );
                Info.Text = "";
                MainBox.Text = "Successfully created sheets. You may close this window and continue using the program normally.";
                state++;
            }
            else if(state == 6)
            {

            }
        }

        private void RequestNext(object sender, EventArgs e)
        {
            RequestNext();
        }

        private void RequestStudents(int grade)
        {
            
        }
    }
}
