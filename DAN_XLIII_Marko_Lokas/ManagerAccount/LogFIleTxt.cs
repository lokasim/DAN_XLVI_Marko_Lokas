using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagerAccount
{
    class LogFIleTxt
    {
            readonly static object locker = new object();

        public static List<string> Title = new List<string>();
        public static void AddLogFile(string message)
        {
            lock (locker)
            {
                Thread.Sleep(2500);
                if (!File.Exists(@"..\..\LogFile.txt"))
                {
                    FileInfo log = new FileInfo(@"..\..\LogFile.txt");

                    StreamWriter sw = log.AppendText();
                    sw.WriteLine($"[{DateTime.Now.Date.ToShortDateString()} {DateTime.Now.ToShortTimeString()}] {message}");
                    sw.Close();
                }
                else
                {
                    FileInfo log = new FileInfo(@"..\..\LogFile.txt");
                    StreamWriter sw = log.AppendText();
                    sw.WriteLine($"[{DateTime.Now.Date.ToShortDateString()} {DateTime.Now.ToShortTimeString()}] {message}");
                    sw.Close();
                }
                //Title.Clear();
                Title.Add(File.ReadAllLines(@"..\..\LogFile.txt").ToString());
            }
        }
    }
}
