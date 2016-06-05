using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.WindowUI
{
    class PlayerWindow : Window
    {
        public void CreateEntry(string[] Values)
        {
            List<EntryComponent> components = new List<EntryComponent>();
            foreach (string str in Values)
            {
                components.Add(new EntryComponent(str, str, EntryComponent.GuiType.LABEL, onClick));
            }
            components.Add(new EntryComponent("Conditions", "Conditions", EntryComponent.GuiType.BUTTON, onClick));
            components.Add(new EntryComponent("Remove", "Remove", EntryComponent.GuiType.BUTTON, onClick));
            base.CreateRow(new Entry(components));
            base.RefreshPanel();
        }



        public void CreateEntry(
            string Initiative, 
            string HumanName, 
            string CharacterName, 
            string ArmorClass,
            string MaxHealth, 
            string CurrentHealth)
        {
            List<EntryComponent> components = new List<EntryComponent>();
            components.Add(new EntryComponent(Initiative, Initiative, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(HumanName, HumanName, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(CharacterName, CharacterName, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(ArmorClass, ArmorClass, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(MaxHealth, MaxHealth, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent(CurrentHealth, CurrentHealth, EntryComponent.GuiType.LABEL, onClick));
            components.Add(new EntryComponent("Conditions", "Conditions", EntryComponent.GuiType.BUTTON, onClick));
            components.Add(new EntryComponent("Remove", "Remove", EntryComponent.GuiType.BUTTON, onClick));
            base.CreateRow(new Entry(components));
            base.RefreshPanel();
        }

        protected override void onClick(EntryComponent Component)
        {
            base.onClick(Component);
            if (Component.Value.CompareTo("Conditions") == 0)
            {
                // Show Conditions Window
                return;
            }

            if (Component.Value.CompareTo("Remove") == 0)
            {
                // Show Conditions Window
                WindowManager.Instance().TurnWindow.RemoveParticipant(Component.Parent);
                WindowManager.Instance().TurnWindow.RefreshPanel();
                return;
            }


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
