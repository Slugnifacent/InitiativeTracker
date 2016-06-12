using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Table
{
    class Request : IWindow
    {
        // Fields
        protected Form window;
        EditableTable table;
        List<string>[] results;
        
        public Request(params string[] Values)
        {
            table = new EditableTable(Result,Values);
            window = new Form();
            window.Controls.Add(table.CONTROL);
        }

        public Request(bool AutoAdd, params string[] Values)
        {
            table = new EditableTable(Result, Values);
            table.DisableAutoRow(true);
            table.AddRow();
            window = new Form();
            window.Controls.Add(table.CONTROL);
        }

        public Request(bool AutoAdd, string[] Values, string Name = "Request")
        {
            table = new EditableTable(Result, Values);
            table.DisableAutoRow(true);
            table.AddRow();
            window = new Form();
            window.Controls.Add(table.CONTROL);
            window.Text = Name;
        }

        // Called when we enter the window
        public virtual void Enter()
        {
            window.ShowDialog();
        }
        
        // Called when we exit the window
        public virtual void Exit()
        {
            window.Close();
        }

        public List<string>[] Results()
        {
            return results;
        }

        private void Result(EditableTable tab)
        {
            results = tab.GetRows();
            window.Close();
        }
    }
}
