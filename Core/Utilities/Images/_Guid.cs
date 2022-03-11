using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Images
{
    public class _Guid
    {
        // guid fonksiyonu ile sınıf ismi cakıstıgı icin '_' eklendi.
        public static string GuidGet()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
