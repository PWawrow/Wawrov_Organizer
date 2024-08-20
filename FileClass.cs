using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Wawrov__Organizer
{
    internal class FileClass
    {
        private String CurrDir { get; set; }
        private int fMode;

        public FileClass(String _currDirStr, String fModeStr)
        {
            if (!Directory.Exists(_currDirStr)) throw new ArgumentException("Directory does not exist!");
            this.CurrDir = _currDirStr;
        }

        public List<String> GetFilesInDir()
        {
            List<String> files = new List<String> { };

            return files;
        }
    }
}
