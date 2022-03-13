using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Images
{
    public interface IFile
    {
        string Upload(IFormFile file, string path);
        void Delete(string path);
        string Update(IFormFile file, string path,string newPath);
    }
}
