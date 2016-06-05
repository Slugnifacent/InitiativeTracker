using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.WindowUI
{
    class EntryWindow : Window
    {
        public EntryWindow() : this(null) { }
        public EntryWindow(List<string> Values):base()
        {
            if(Values != null) CreateEntry(Values);
        }

        public void CreateEntry(List<string> Values)
        {
            List<EntryComponent> labelComponents   = CreateComponents(Values, EntryComponent.GuiType.LABEL);
            List<EntryComponent> TextBoxComponents = CreateComponents(Values, EntryComponent.GuiType.TEXTBOX);
            Entry entrylabels = new Entry(labelComponents);
            Entry textBoxes = new Entry(TextBoxComponents);
            base.CreateRow(entrylabels);
            base.CreateRow(textBoxes);
            base.RefreshPanel();
        }

        private List<EntryComponent> CreateComponents(List<string> Values, EntryComponent.GuiType Type)
        {
            List<EntryComponent> components = new List<EntryComponent>();
            foreach (string str in Values)
            {
                components.Add(new EntryComponent(str, str, Type, onClick));
            }
            return components;
        }

        public override void Enter()
        {
            window.Controls.Add(panel.Panel);
            window.ShowDialog();
        }

    }
}
