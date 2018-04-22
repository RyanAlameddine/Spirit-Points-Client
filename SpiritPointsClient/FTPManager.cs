using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritPointsClient
{
    public static class FTPManager
    {
        public static int Port = 22;
        public static String Host = "138.68.30.187";
        public static String Username = "root";
        public static String Password = "";
            
        public static bool Connected()
        {
            var sftp = new SftpClient(Host, Port, Username, Password);
            try
            {
                sftp.Connect();
                sftp.Disconnect();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public static void WriteLines(string path, params string[] content)
        {
            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();

                sftp.WriteAllLines(path, content);

                sftp.Disconnect();
            }
        }

        public static void DeleteFile(string path)
        {
            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();
                sftp.DeleteFile(path);

                sftp.Disconnect();
            }
        }

        public static void DownloadAll()
        {
            if(SpiritPointsClient.submissionPictureBox.Image != null)
                SpiritPointsClient.submissionPictureBox.Image.Dispose();
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Data")))
            {
                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Data"), true);
            };

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Data"));


            DownloadAll("");
        }

        static void DownloadAll(string path)
        {
            string remoteDirectory;
            string localDirectory;
            if (path != "")
            {
                remoteDirectory = "/home/DataPath/" + path + "/";
                localDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"Data\", path + @"\");
            }
            else
            {
                remoteDirectory = "/home/DataPath/";
                localDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"Data\");
            }

            if (!Directory.Exists(localDirectory))
            {
                Directory.CreateDirectory(localDirectory);
            }

            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();
                var files = sftp.ListDirectory(remoteDirectory);

                foreach (var file in files)
                {
                    string remoteFileName = file.Name;
                    if ((!file.Name.StartsWith(".")))
                    {
                        if (file.IsDirectory)
                        {
                            if(path != "")
                            {
                                DownloadAll(path + "/" + file.Name);
                            }
                            else
                            {
                                DownloadAll(file.Name);
                            }
                            continue;
                        }
                        using (Stream file1 = File.OpenWrite(localDirectory + remoteFileName))
                        {
                            sftp.DownloadFile(remoteDirectory + remoteFileName, file1);
                        }
                    }
                }

                sftp.Disconnect();
            }
        }
    }
}
