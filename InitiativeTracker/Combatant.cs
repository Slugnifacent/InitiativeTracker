using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    class Combatant
    {
        public int Initiative { get; set; }
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public int ArmorClass { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string MoreInfo { get; set; }
        public string Condition { get; set; }

        public Combatant(params string[] Information)
        {
            if (Information.Length >= 8)
            {
                int value = 0;
                int.TryParse(Information[0], out value);
                Initiative = value;
                PlayerName = Information[1];
                CharacterName = Information[2];

                int.TryParse(Information[3], out value);
                ArmorClass = value;

                int.TryParse(Information[4], out value);
                MaxHealth = value;

                int.TryParse(Information[5], out value);
                CurrentHealth = value;

                MoreInfo = Information[6];
                Condition = Information[7];
            }
        }



        public string[] ToArray()
        {
            string[] array = new string[8];
           
            int index = 0;
            foreach (PropertyInfo prop in typeof(Combatant).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                object value = prop.GetValue(this, null);
                array[index] = (value == null) ? " ": value.ToString();
                index++;
                if (index >= 8) // This represents the number of properties
                {
                    break;
                }
            }
            return array;
        }
    }
}
