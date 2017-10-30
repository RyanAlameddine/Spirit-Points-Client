using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritPointsClient
{
    public class DataHandler
    {
        string dataPath = File.ReadAllLines("DataPath.txt")[0];
        List<string> Seventh  = new List<string>();
        List<string> Eighth   = new List<string>();
        List<string> Ninth    = new List<string>();
        List<string> Tenth    = new List<string>();
        List<string> Eleventh = new List<string>();
        List<string> Twelfth  = new List<string>();
        int start = 0;

        public void LoadData()
        {
            Seventh  = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2023")).ToList();
            Eighth   = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2022")).ToList();
            Ninth    = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2021")).ToList();
            Tenth    = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2020")).ToList();
            Eleventh = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2019")).ToList();
            Twelfth  = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2018")).ToList();

            foreach(string name in Seventh)
            {
                
            }
        }

        public string NextPicture()
        {
            string path;



            return path;
        }
    }
}
