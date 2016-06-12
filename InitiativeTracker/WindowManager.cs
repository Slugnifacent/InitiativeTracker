using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class WindowManager
    {
        private static WindowManager windowManager;

        public TurnWindow table { get; private set; }
        private WindowManager()
        {
           
        }

        public static WindowManager Instance()
        {
            if (windowManager == null)
            {
                return windowManager = new WindowManager();
            }
            return windowManager;
        }

        // Throw unable to init Exception
        public void Init(string[] Headers)
        {
            int count = Headers.Length - 2;
            if (count > 0)
            { 
                string[] array = new string[count];
                Array.Copy(Headers, array, count);
                table = new TurnWindow(array);
            }
        }

        public void Conditions(string Condition, ListViewItem Itm)
        {
            Conditions temp = new Conditions(Condition,Itm);
            temp.Enter();
        }
        


        public void MoreInfo(string[] Items)
        {
            MoreInfo("More Info", Items);
        }

        public void MoreInfo(string Name, string[] Items)
        {
            MoreInfo temp = new MoreInfo(Items, Name);
            temp.Enter();
        }

        
        public List<string>[] Request( string[] Items)
        {
            return Request(Items, "Request", true);
        }

        public List<string>[] Request( string[] Items, string Name)
        {
            return Request(Items, Name, true);
        }

        public List<string>[] Request( string[] Items, string Name, bool AutoAdd)
        {
            Request temp = new Request(AutoAdd, Items, Name);
            temp.Enter();
            return temp.Results();
        }
    }
}
