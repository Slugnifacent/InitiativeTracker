using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    class TurnWindow : IWindow
    {
        // Fields
        protected Form window;
        Table table;

        protected Form SlaveWindow;
        SlaveTable slaveTable;

        public TurnWindow(string[] Values, string Name = "Turn Window (Dungeon Master)")
        {
            
            slaveTable = new SlaveTable(Values[0], Values[1]);
            SlaveWindow = new Form();
            SlaveWindow.Size = new Size(500, 200);
            SlaveWindow.FormClosing += Window_FormClosing;
            SlaveWindow.Controls.Add(slaveTable.CONTROL);
            SlaveWindow.Text = "Turn Window (Player Window)";
            SlaveWindow.StartPosition = FormStartPosition.WindowsDefaultBounds;

            table = new Table(Values, slaveTable);
            window = new Form();
            window.Size = new Size(500, 200);
            window.FormClosing += Window_FormClosing;
            window.Controls.Add(table.CONTROL);
            window.Text = "Turn Window (Dungeon Master)";
            window.StartPosition = FormStartPosition.WindowsDefaultBounds;

        }
        
        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form window = (Form)sender;
            e.Cancel = true;
            window.Hide();
        }

        // Called when we enter the window
        public virtual void Enter()
        {
            window.Show();
            SlaveWindow.Show();
        }

        // Called when we exit the window
        public virtual void Exit()
        {
            window.Hide();
            SlaveWindow.Hide();
        }

        public virtual void RequestInitiative()
        {
            // Extract Player Names
            ListView.ListViewItemCollection collection = table.GetRows();
            string[] Players = new string[collection.Count];
            int index = 0; 
            foreach (ListViewItem item in collection)
            {
                Combatant combatant = item.Tag as Combatant;
                Players[index] = combatant.CharacterName;
                index++;
            }

            List<string>[] results = WindowManager.Instance().Request(Players,"Request Initiative",false);
            if (results == null) return;
            List<string> row = results[0];

            // Insert initiatives
            collection = table.GetRows();
            for (index = 0; index < collection.Count; index++)
            {
                int value = 0;
                bool parsed = int.TryParse(row[index],out value);
                if (!parsed) value = int.MaxValue;

                Combatant combatant = collection[index].Tag as Combatant;
                combatant.Initiative = value;

                ListViewItem itm = collection[index];
                itm.BackColor = Color.White;
                itm.SubItems[0].Text = combatant.Initiative.ToString();
            }

            // Insert initiatives
            collection = slaveTable.GetRows();
            for (index = 0; index < collection.Count; index++)
            {
                int value = 0;
                bool parsed = int.TryParse(row[index], out value);
                if (!parsed) value = int.MaxValue;

                Combatant combatant = collection[index].Tag as Combatant;
                combatant.Initiative = value;

                ListViewItem itm = collection[index];
                itm.BackColor = Color.White;
                itm.SubItems[0].Text = combatant.Initiative.ToString();
            }

            ListView view = table.CONTROL as ListView;
            view.Items[0].BackColor = Color.LightSteelBlue;

            table.Sort();
            slaveTable.Sort();
        }

        public void AddCombatant(params string[] Information)
        {
            table.AddRow(Information);
        }
        public void NextTurn()
        {
            NextTurn(table.CONTROL as ListView,false);
            NextTurn(slaveTable.CONTROL as ListView, false);
        }
        
        public void NextTurn(ListView view, bool CheckCondition = true)
        {
            if (view != null)
            {
                view.Items[0].BackColor = Color.White;

                if (CheckCondition)
                { 
                    // Check if Condition still occours
                    Combatant fighter = view.Items[0].Tag as Combatant;
                    string[] conditions = fighter.Condition.Split(',');
                    foreach (string str in conditions)
                    {
                        DialogResult result = MessageBox.Show("Is this stil occouring? \n" + str, "Condition Check", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            fighter.Condition = fighter.Condition.Replace(str, "");
                        }
                    }
                    fighter.Condition.Trim();
                }
                
                ListViewItem itm = view.Items[0];
                view.Items.RemoveAt(0);
                view.Items.Add(itm);
                view.Items[0].BackColor = Color.LightSteelBlue;
            }
            window.Refresh();
            SlaveWindow.Refresh();
        }
        
    }
}
