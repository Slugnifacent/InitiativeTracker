using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    class CSVFile
    {
        string[] filelines;
        public CSVFile(string Path)
        {
            filelines = File.ReadAllLines(Path);
        }

        public string GetLine(int Line)
        {
            if (filelines.Length > Line) return filelines[Line];
            return null;
        }


    }
}
