using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritPointsClient
{
    static class Program
    {
        public static string SpreadSheetId
        {
            get
            {
                return System.IO.File.ReadAllLines("SpreadSheetId.txt")[0];
            }
            set
            {
                string[] lines = { value };
                System.IO.File.WriteAllLines("SpreadSheetId.txt", lines);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpiritPointsClient());
        }
    }
}
