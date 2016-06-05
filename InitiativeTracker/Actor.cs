using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    class Actor
    {
        Byte initiative;
        string hName; // Human Name
        string cName; // Character Name
        Byte ac;  // Armor Class
        Byte mhp; // Max Health
        Byte chp; // Current Health
        List<Condition> conditions; // conditions

        private Actor() : this(0, "", "", 0, 0, 0, null) { }

        public Actor(
            byte Initiative) : this(Initiative, "", "", 0, 0, 0, null)
        { }

        public Actor(
            byte Initiative,
            string HumanName,
            string CharacterName):this(Initiative,HumanName,CharacterName,0,0,0,null)
        { }

        public Actor(
            byte Initiative, 
            string HumanName, 
            string CharacterName, 
            byte ArmorClass,
            byte MaxHealth,
            byte CurrentHealth,
            List<Condition> Conditions)
        {
            initiative = Initiative;
            hName = HumanName;
            cName = CharacterName;
            ac  = ArmorClass;
            mhp = MaxHealth;
            chp = CurrentHealth;
            if (Conditions != null)
            {
                conditions = Conditions;
            }
            else conditions = new List<Condition>();
        }

        public Byte Initiative
        {
            get { return initiative;  }
            set { initiative = value; }
        }

        public string HumanName
        {
            get { return hName; }
            set { hName = value; }
        }


        public string CharacterName
        {
            get { return cName; }
            set { cName = value; }
        }

        public Byte ArmorClass
        {
            get { return ac; }
            set { ac = value; }
        }

        public Byte MaxHealth
        {
            get { return chp; }
            set { chp = value; }
        }

        public Byte CurrentHealth
        {
            get { return chp; }
            set { chp = value; }
        }

        public List<Condition> Conditions
        {
            get { return conditions; }
            set { conditions = value; }
        }
        
    }
}
