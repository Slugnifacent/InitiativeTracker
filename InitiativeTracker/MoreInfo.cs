using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class MoreInfo
    {
        // Fields
        protected Form window;
        Label description;

        public MoreInfo( string[] Values, string Name = "More Info")
        {
            description = new Label();
            foreach (string val in Values)
            {
                description.Text += string.Format("{0}\n",val);
            }
            description.Dock = DockStyle.Fill;
            window = new Form();
            window.Controls.Add(description);
            window.Text = Name;
        }
        
        // Called when we enter the window
        public virtual void Enter()
        {
            window.Show();
        }

        // Called when we exit the window
        public virtual void Exit()
        {
            window.Close();
        }
    }
}
