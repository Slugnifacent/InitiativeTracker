using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.WindowUI
{
    class NPCWindow : Window
    {

        public void CreateEntry(string[] Values)
        {
            List<EntryComponent> components = new List<EntryComponent>();
            foreach (string str in Values)
            {
                components.Add(new EntryComponent(str, str, EntryComponent.GuiType.LABEL, onClick));
            }
            components.Add(new EntryComponent("Conditions", "Conditions", EntryComponent.GuiType.BUTTON, onClick));
            base.CreateRow(new Entry(components));
            base.RefreshPanel();
        }

        public void CreateEntry(
            string Initiative, 
            string CharacterName, 
            string ArmorClass,
            string MaxHealth, 
            string CurrentHealth)
        {
            List<EntryComponent> components = new List<EntryComponent>();
            components.Add(new EntryComponent(Initiative, Initiative, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(CharacterName, CharacterName, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(ArmorClass, ArmorClass, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(MaxHealth, MaxHealth, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(CurrentHealth, CurrentHealth, EntryComponent.GuiType.LABEL, onClick));
            base.CreateRow(new Entry(components));
            base.RefreshPanel();
        }

        protected override void onClick(EntryComponent Component)
        {
            base.onClick(Component);
            if (Component != null)
            {
                if (Component.Parent != null)
                {
                    WindowManager.Instance().ShowMoreInfo(Component.Parent.toString());
                }
                else
                {
                    WindowManager.Instance().ShowMoreInfo(Component.toString());
                }
            }
        }
        
    }
}
