using HealthCare.Service.IService;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class FileManager : IFileManager
    {
        public static string BaseFolderPath { get; } = @"D:\My_2nd_Summer\Training\Work\Images\";
        public static string BaseFolderPathHr { get; } = @"D:\My_2nd_Summer\Training\Work\Images\";

        public void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string file = Path.GetTempPath() + Path.GetRandomFileName() + Path.GetExtension(fileName);

            File.Copy(filePath, file);
            if (File.Exists(file))
            {
                var pi = new ProcessStartInfo(file)
                {
                    Arguments = Path.GetFileName(file),
                    UseShellExecute = true,
                    WorkingDirectory = Path.GetTempPath(),
                    FileName = Path.GetFileName(file),
                    Verb = "OPEN"
                };
                Process.Start(pi);
            }
        }
        public string GetServerFolderPath()
        {
            return BaseFolderPath;
        }
        public string GetServerFolderPathHr()
        {
            return BaseFolderPathHr;
        }
        public bool CopyFile(string source, string target)
        {
            try
            {
                if (!File.Exists(source))
                {
                    throw new FileNotFoundException(string.Format(@"Source file was not found. FileName: {0}", source));
                }
                if (!File.Exists(target))
                {
                    File.Copy(source, target);
                }
                else
                {
                    File.Copy(source, target, true);
                }
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException(string.Format(@"Exception: {0}", ex.Message));
            }
            return true;
        }

        //Copies the file from the source into the users temp folder. Returns the temp folder path to the file so we know where to look when the user submits.
        public string CopyFileToTemp(string source)
        {
            //string revExt = Path.GetExtension(source);
            string fileName = Path.GetFileName(source);
            string tempPath = Path.GetTempPath() + Path.GetRandomFileName() + Path.GetExtension(fileName);
            if (File.Exists(source))
            {
                //string tempPath = Path.GetTempFileName() + revExt;
                CopyFile(source, tempPath);
                return tempPath;
            }

            return null;
        }
        //Convert Image Path To Base 64 Format
        public string ConvertPathToBase64(string path)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);
            byte[] arr;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            var base64 = Convert.ToBase64String(arr);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            return imgSrc;
        }
    }
}