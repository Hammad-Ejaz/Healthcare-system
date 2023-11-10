using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IFileManager
    {
        //Task<string> UploadAsync(IFileListEntry file);
        void OpenFile(string fileName);
        string CopyFileToTemp(string source);
        string GetServerFolderPath();
        bool CopyFile(string source, string target);
        string ConvertPathToBase64(string path);
        string GetServerFolderPathHr();

    }
}
