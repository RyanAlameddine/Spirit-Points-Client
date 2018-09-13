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
        public string Seventh;
        public string Eighth;
        public string Freshman;
        public string Sophomore;
        public string Junior;
        public string Senior;

        public string SpreadSheetID;

        /*
         * 0 - Creating Doc
         * 2 - Seventh
         * 3 - Eighth
         * 4 - Freshman
         * 5 - Sophomore
         * 6 - Junior
         * 7 - Senior
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
                Info.Text = "View instructions at \r\ngoo.gl/77EZgm\r\nthen click next";
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
                    Info.Text = "Please enter the name of every student in SEVENTH GRADE\r\nseparated by a line\r\nI.e. Ryan Alameddine\r\nJohn Macleod\r\nMaya Le";
                    state++;
            }
            else if (state == 1)
            {
                Seventh = MainBox.Text;
                Info.Text = "Please enter the name of every student in EIGHTH GRADE\r\nseparated by a line\r\nI.e. Ryan Alameddine\r\nJohn Macleod\r\nMaya Le";
                MainBox.Text = "";
                state++;
            }
            else if (state == 2)
            {
                Eighth = MainBox.Text;
                Info.Text = "Please enter the name of every FRESHMAN\r\nseparated by a line\r\nI.e. Ryan Alameddine\r\nJohn Macleod\r\nMaya Le";
                MainBox.Text = "";
                state++;
            }
            else if (state == 3)
            {
                Freshman = MainBox.Text;
                Info.Text = "Please enter the name of every SOPHOMORE\r\nseparated by a line\r\nI.e. Ryan Alameddine\r\nJohn Macleod\r\nMaya Le";
                MainBox.Text = "";
                state++;
            }
            else if (state == 4)
            {
                Sophomore = MainBox.Text;
                Info.Text = "Please enter the name of every JUNIOR\r\nseparated by a line\r\nI.e. Ryan Alameddine\r\nJohn Macleod\r\nMaya Le";
                MainBox.Text = "";
                state++;
            }
            else if (state == 5)
            {
                Junior = MainBox.Text;
                Info.Text = "Please enter the name of every SENIOR\r\nseparated by a line\r\nI.e. Ryan Alameddine\r\nJohn Macleod\r\nMaya Le";
                MainBox.Text = "";
                state++;
            }
            else if (state == 6)
            {
                Senior = MainBox.Text;
                Info.Text = "Generating google sheets. Please wait.";

                List<string> seventh   = new List<string>(Seventh  .Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
                List<string> eighth    = new List<string>(Eighth   .Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
                List<string> freshman  = new List<string>(Freshman .Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
                List<string> sophomore = new List<string>(Sophomore.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
                List<string> junior    = new List<string>(Junior   .Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
                List<string> senior    = new List<string>(Senior   .Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));

                SheetsManager.CreateSheet("Seventh"  , seventh  );
                SheetsManager.CreateSheet("Eighth"   , eighth   );
                SheetsManager.CreateSheet("Freshman" , freshman );
                SheetsManager.CreateSheet("Sophomore", sophomore);
                SheetsManager.CreateSheet("Junior"   , junior   );
                SheetsManager.CreateSheet("Senior"   , senior   );
                Info.Text = "Generating xml data. Please wait.";
                MainBox.Text = SheetsManager.CreateXML(seventh, eighth, freshman, sophomore, junior, senior);
                Info.Text = "Please refer back to step 7 of goo.gl/77EZgm\r\nAfter this, the reset process is done so\r\nyou can close the window.";
                state++;
            }
            else if(state == 7)
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
