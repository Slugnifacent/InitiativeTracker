using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitiativeTracker.WindowUI
{
    class RollInitiativeDialogue : Window
    {

        public RollInitiativeDialogue(List<Entry> Players):base()
        {
            // Create Window
            window = new Form();
            foreach (Entry entry in Players)
            {
                CreateEntry(
                    entry.Components[0].Value,
                    entry.Components[1].Value,
                    entry.Components[2].Value);
            }
            RefreshPanel();
        }

        private void CreateEntry(
            string Initiative,
            string HumanName,
            string CharacterName)
        {
            List<EntryComponent> componentsBoxes = new List<EntryComponent>();
            componentsBoxes.Add(new EntryComponent(Initiative, Initiative, EntryComponent.GuiType.TEXTBOX, onClick));
            componentsBoxes.Add(new EntryComponent(HumanName, HumanName, EntryComponent.GuiType.LABEL, onClick));
            componentsBoxes.Add(new EntryComponent(CharacterName, CharacterName, EntryComponent.GuiType.LABEL, onClick));
            Entry EntryBoxes = new Entry(componentsBoxes);
            base.CreateRow(EntryBoxes);
            base.RefreshPanel();
        }
        
        protected override void onClick(EntryComponent Component)
        {

        }

        public override void Enter()
        {
            window.Controls.Add(panel.Panel);
            window.BringToFront();
            window.ShowDialog();
        }

        public List<string> Results()
        {
            List<string> result = new List<string>();
            foreach (Entry entry in panel.GetEntries())
            {
                result.Add(entry.Components[0].Control.Text);
            }
            return result;
        }
        
        
    }
}
