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
    public partial class LocationViewer : Form
    {
        public static string location;
        public LocationViewer()
        {
            InitializeComponent();
        }

        private void LocationViewer_Load(object sender, EventArgs e)
        {
            LocationBrowser.Url = new System.Uri(location);
        }
    }
}
