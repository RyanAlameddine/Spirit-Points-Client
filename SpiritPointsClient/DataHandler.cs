using Renci.SshNet;
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
        //string dataPath       = File.ReadAllLines("DataPath.txt")[0];
        List<string> Middle   = new List<string>();
        List<string> Freshman = new List<string>();
        List<string> Softmore = new List<string>();
        List<string> Junior   = new List<string>();
        List<string> Senior   = new List<string>();

        Queue<Submission> sortedData = new Queue<Submission>();

        int readCount = 0;
        public int ReadCount
        {
            get
            { 
                return readCount;
            }
            set
            {
                readCount = value;
                string[] lines = { readCount + "" };
                File.WriteAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data", "readCount.txt"), lines);
                FTPManager.WriteLines("/home/DataPath/readCount.txt", lines);
            }
        }

        public void LoadData()
        {
            readCount = int.Parse(File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data", "readCount.txt"))[0]);
            Middle    =          Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pictures", "Middle")).ToList();
            Freshman  =          Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pictures", "Freshman")).ToList();
            Softmore  =          Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pictures", "Softmore")).ToList();
            Junior    =          Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pictures", "Junior")).ToList();
            Senior    =          Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Data", "Pictures", "Senior")).ToList();
            sortedData.Clear();
            analyzeSubmissions(Middle, Freshman, Softmore, Junior, Senior);
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

            //cull values below current
            for (int i = 0; i < submissions.Count(); i++)
            {
                if (submissions[i].fileNumber < ReadCount)
                {
                    submissions.Remove(submissions[i]);
                    i--;
                }
            }

            //Sort Submissions
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
            remaining.Text = "Pictures Remaining: " + (sortedData.Count);
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
    public string eventName;

    public Submission(string path)
    {
        this.path = path;
        string fileName = Path.GetFileName(path);

        eventName = Regex.Match(fileName, @"\.([^)]*)\.").Groups[1].Value;
        string subExtension = Regex.Match(fileName, @"\.([^)]*)\.").Groups[2].Value;
        fileNumber = int.Parse(subExtension);

        grade = Path.GetFileName(Path.GetDirectoryName(path));

        string noExtension = Path.GetFileNameWithoutExtension(path);

        name = noExtension.Remove(noExtension.Count() - 1 - subExtension.Count());

        date = File.GetCreationTime(path).ToString("M/d/yyyy");
    }
}