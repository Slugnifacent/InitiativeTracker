using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InitiativeTracker.WindowUI
{
    class Window : IWindow
    {
        // Fields
        protected Form window;
        protected IWindow nextWindow;
        protected ListLayout panel;

        public Window() : this(null) { }
        public Window(IWindow NextWindow)
        {
            nextWindow = NextWindow;
            panel = new ListLayout();
            // Create Window
            window = new Form();
            window.AutoSize = true;
        }

        public void RefreshPanel()
        {
            panel.RefreshPanel();
        }
        
        // User Interface for creating an Entry. 
        public void CreateRow(Entry entry, bool AddButton = true)
        {
            panel.CreateRow(entry, AddButton);
        }
        
        // Called when we enter the window
        public virtual void Enter()
        {
            window.Controls.Add(panel.Panel);
            window.Show();
            window.BringToFront();
        }

        // Called while we are in the window
        public virtual void Action()
        {

        }

        // Called when we exit the window
        public virtual void Exit()
        {
            window.Close();
        }

        public void ClearPanel()
        {
            panel.Clear();
        }

        // Getters
        public Control Panel
        {
            get { return panel.Panel; }
        }

        public IWindow GetNextWindow()
        {
            return nextWindow;
        }

        public List<Entry> GetEntries()
        {
            return panel.GetEntries();
        }

        public List<string> GetRowAsStrings(int Row)
        {
            return panel.GetRowAsStrings(Row);
        }



        protected virtual void onClick(EntryComponent Component)
        {
        }

    }
}
