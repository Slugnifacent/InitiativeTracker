using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitiativeTracker.WindowUI
{
    class MoreInfo : Window
    {
        public MoreInfo() : base()
        {
            window.FormClosing += Window_FormClosing;
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form window = (Form)sender;
            e.Cancel = true;
            window.Hide();
        }

        public void CreateMoreInfo(string Information)
        {
            panel.Clear();
            Entry entry = new Entry();
            entry.Add(new EntryComponent(Information, Information,EntryComponent.GuiType.LABEL, onClick));
            base.CreateRow(entry);
            base.RefreshPanel();
        }
        
        
    }
}
