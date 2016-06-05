using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.WindowUI
{
    class TurnWindow : Window
    {
        List<Entry> actorsList;

        List<Entry> pcs;
        List<Entry> npcs;

        RollInitiativeDialogue rollInitiative;
        
        public TurnWindow(PlayerWindow PCs, NPCWindow NPCs):base()
        {
            actorsList = new List<Entry>();
            pcs = new List<Entry>();
            npcs = new List<Entry>();
            rollInitiative = new RollInitiativeDialogue(pcs);
        }

        public void CreateTurnWindow(PlayerWindow PCs, NPCWindow NPCs)
        {

            pcs = PCs.GetEntries();
            npcs = NPCs.GetEntries();

            SortActors();

            foreach (Entry entry in actorsList)
            {
                base.CreateRow(entry);
            }


            base.RefreshPanel();
        }

        private void SortActors()
        {
            actorsList.Clear();
            actorsList.AddRange(pcs);
            actorsList.AddRange(npcs);
            actorsList.Sort();
        }

        public void RollForInitiative()
        {
            rollInitiative = new RollInitiativeDialogue(pcs);
            rollInitiative.Enter();
            List<string> results = rollInitiative.Results();
            for(int index = 0; index < pcs.Count(); index++)
            {
                Entry entry = pcs[index];
                entry.Components[0].Control.Text = results[index];
                entry.Components[0].Value = results[index];
            }

            SortActors();
        }

        public void NextTurn(EntryComponent Component)
        {
            List<Entry> entries = panel.GetEntries();
            if (entries.Count <= 1) return;
            Entry current = entries[0];
            entries.RemoveAt(0);
            entries.Add(current);
            
            base.RefreshPanel();
        }
        
        public void AddParticipant(EntryComponent Component)
        {
            List<string> list = new List<string>();
            list.Add("Name");
            list.Add("HP");
            list.Add("Str");
            list.Add("Magic");
            list.Add("Armor");
            list.Add("5");

            EntryWindow windowRequest = new EntryWindow(list);
            windowRequest.Enter();
            list.Clear();
            list = windowRequest.GetRowAsStrings(1);

            Entry Labels = new Entry(CreateComponents(list,EntryComponent.GuiType.LABEL));
            base.CreateRow(Labels);
            panel.Sort();
            base.RefreshPanel();
        }
        
        public void RemoveParticipant(Entry Component)
        {
            panel.DeleteEntry(Component);
            panel.Sort();
            panel.RefreshPanel();
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

    }
}
