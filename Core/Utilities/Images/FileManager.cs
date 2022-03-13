using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Images
{
    public class FileManager : IFile
    {
        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string Update(IFormFile file, string path, string newPath)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return Upload(file,newPath);
        }

        public string Upload(IFormFile file, string path)
        {

                if (file.Length > 0)
                {
                    
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string extension = Path.GetExtension(file.FileName); // uzantı
                    string guid = _Guid.GuidGet();
                    string filePath =  guid + extension;
                    using (FileStream fileStream = File.Create(path + filePath))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return filePath;
                    }
                }
            return null;
        }
    }
}
