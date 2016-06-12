using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    class BattleInformation
    {
        string[] filelines;
        private static BattleInformation battleInfo;
        private BattleInformation()
        {
            
        }

        public static BattleInformation Instance()
        {
            if (battleInfo == null)
            {
                battleInfo = new BattleInformation();
            }
            return battleInfo;
        }

        public void ReadFile(string Path)
        {
            filelines = File.ReadAllLines(Path);
        }
        
        public string GetLine(int Line)
        {
            if (filelines == null) return null;
            if (filelines.Length > Line) return filelines[Line];
            return null;
        }
        
        // Access to the Header information should be handle gracefully
        public string[] GetHeaderInformation()
        {
            if (filelines == null) return null;
            // Remove More info and Conditions
            if (0 < filelines.Length) return filelines[0].Split('\t');
            return null;
        }

        // Access to the Header information should be handle gracefully
        public string[] GetPlayerInformation(int Index)
        {
            if (filelines == null) return null;
            if (Index < filelines.Length ) return filelines[Index].Split('\t');
            return null;
        }



    }
}
