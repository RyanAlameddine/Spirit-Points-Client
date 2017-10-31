using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiritPointsClient
{
    public class DataHandler
    {
        string dataPath        = File.ReadAllLines("DataPath.txt")[0];
        List<string> Seventh   = new List<string>();
        List<string> Eighth    = new List<string>();
        List<string> Ninth     = new List<string>();
        List<string> Tenth     = new List<string>();
        List<string> Eleventh  = new List<string>();
        List<string> Twelfth   = new List<string>();

        Queue<Submission> sortedData = new Queue<Submission>();

        //                grade, column
        public Dictionary<string, char> grades = new Dictionary<string, char>(); 

        public DataHandler()
        {
            /*
                Ninth    = 'B',
                Tenth    = 'C',
                Eleventh = 'D',
                Twelfth  = 'E',
                Middle   = 'F'
            */
            grades.Add("Class Of 2021", 'B');
            grades.Add("Class Of 2020", 'C');
            grades.Add("Class Of 2019", 'D');
            grades.Add("Class Of 2018", 'E');
            grades.Add("Class Of 2022", 'F');
            grades.Add("Class Of 2023", 'F');
        }

        public void LoadData()
        {
            Seventh  = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2023")).ToList();
            Eighth   = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2022")).ToList();
            Ninth    = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2021")).ToList();
            Tenth    = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2020")).ToList();
            Eleventh = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2019")).ToList();
            Twelfth  = Directory.GetFiles(Path.Combine(dataPath, "Pictures", "ClassOf2018")).ToList();
            sortedData.Clear();
            analyzeSubmissions(Seventh, Eighth, Ninth, Tenth, Eleventh, Twelfth);
        }

        void analyzeSubmissions(params List<string>[] toSort)
        {
            List<Submission> submissions = new List<Submission>();
            foreach (List<string> list in toSort)
            {
                foreach (string path in list)
                {
                    submissions.Add(new Submission(path));
                }
            }

            while(submissions.Count() > 0)
            {
                int smallest = 0;
                for(int i = 0; i < submissions.Count(); i++)
                {
                    if (submissions[i].fileNumber < submissions[smallest].fileNumber) smallest = i;
                }
                Submission smallestSubmission = submissions[smallest];
                submissions.Remove(submissions[smallest]);

                sortedData.Enqueue(smallestSubmission);
            }
        }

        public Submission NextPicture(Label remaining)
        {
            if(sortedData.Count == 0)
            {
                return null;
            }
            remaining.Text = "Pictures Remaining: " + (sortedData.Count - 1);
            return sortedData.Dequeue();
        }
    }
}

public class Submission
{
    public string path;
    public int fileNumber;
    public string name;
    public string grade;
    public string date;

    public Submission(string path)
    {
        this.path = path;
        string fileName = Path.GetFileName(path);
        string subExtension = Regex.Match(fileName, @"\.([^)]*)\.").Groups[1].Value;
        fileNumber = int.Parse(subExtension);

        grade = Path.GetFileName(Path.GetDirectoryName(path));
        grade = grade.Insert(7, " ");
        grade = grade.Insert(5, " ");

        string noExtension = Path.GetFileNameWithoutExtension(path);

        name = noExtension.Remove(noExtension.Count() - 1 - subExtension.Count());
        name = name.Replace('_', ' ');

        date = File.GetCreationTime(path).ToString("MM/dd/yyyy");
    }
}