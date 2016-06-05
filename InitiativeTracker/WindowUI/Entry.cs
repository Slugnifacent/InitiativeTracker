using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitiativeTracker.WindowUI
{
    public class Entry : IComparable<Entry>
    {

        List<EntryComponent> components;

        public Entry() : this(null) { }
        public Entry(List<EntryComponent> Components)
        {
            components = new List<EntryComponent>();
            if (Components != null)
            {
                foreach (EntryComponent component in Components)
                {
                    Add(component);
                }
            }
        }
        
        public void Add(EntryComponent Component)
        {
            Component.SetEntryParent(this); 
            components.Add(Component);
        }

        public List<EntryComponent> Components
        {
            get { return components; }
        }

        public string toString()
        {
            string result = "";
            foreach (EntryComponent component in components)
            {
                result += component.toString();
            }
            return result;
        }

        public int CompareTo(Entry other)
        {
            // 1 Greater Than
            // 0 Same
            // -1 Less Than
            int value = 0;
            int otherValue = 0;
            isComparable(this, out value);
            isComparable(other, out value);
            return value.CompareTo(otherValue);
        }

        private bool isComparable(Entry entry, out int value)
        {
            value = 0;
            if (entry == null) return false;
            if (entry.components.Count <= 0) return false;
            bool result = Int32.TryParse(entry.components[0].Value, out value);
            return result;
        }
        
    }
}
