using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class MultipleChoice
    {
        protected Form window;
        Label description;

        List<RadioButton> buttons;

        public MultipleChoice(params string[] Choices)
        {
            buttons = new List<RadioButton>();
            foreach (string choice in Choices)
            {
                RadioButton button = new RadioButton();
            }

        }


        ContextMenuStrip mnu;
        private void CreateContextMenu()
        {
            mnu = new ContextMenuStrip();
            ToolStripMenuItem Add = new ToolStripMenuItem("Submit");
            window.ContextMenuStrip = mnu;
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
    }
}
