using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Paths
            string[] paths = { "C:/Users/seeme/Desktop/Maybank/ResumeParser/input/testfile1.pdf",
                                "C:/Users/seeme/Desktop/Maybank/ResumeParser/input/testfile2.docx",
                                "C:/Users/seeme/Desktop/Maybank/ResumeParser/input/testfile3.docx" };
            JObject data;
            for (int i=0; i<paths.Length; i++)
            {
                data = getSkills(paths[i]);
                Console.WriteLine(data.GetValue("name"));
            }
        }

        static JObject getSkills(string path)
        {
            string path_parse = "C:/Users/seeme/Desktop/Maybank/ResumeParser/parse2.py"; // Path of Python Parser Script
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "python.exe",
                    Arguments = "-Wignore "+ path_parse + " \"" + path + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false
                }
            };
            proc.Start();
            string line = "";
            while (!proc.StandardOutput.EndOfStream)
            {
                line = proc.StandardOutput.ReadLine();
            }

            JArray jsonArray = JArray.Parse(line);
            JObject data = JObject.Parse(jsonArray[0].ToString());
            return data;

        }


    }
}
