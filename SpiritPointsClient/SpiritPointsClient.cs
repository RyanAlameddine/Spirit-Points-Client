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

        public SpiritPointsClient()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            /*
                Ninth = "B",
                Tenth = "C",
                Eleventh = "D",
                Twelfth = "E",
                Middle = "F"
            */
            //SheetsManager.AddPoints(10, 'B', "10/31/2017");
        }

        private void Deny_Click(object sender, EventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            dataHandler.LoadData();
        }
    }
}
