using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table
{
    public partial class Action : Form
    {
        public Action()
        {
            InitializeComponent();
            BattleInformation.Instance();
            WindowManager.Instance();
        }

        private void NextTurn_Click(object sender, EventArgs e)
        {
            WindowManager.Instance().table.NextTurn();
        }

        private void Roll_Click(object sender, EventArgs e)
        {
            WindowManager.Instance().table.RequestInitiative();
        }

        private void CSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            // Set filter options and filter index.
            file.Filter = "TSV Files (.tsv)|*.tsv|CSV Files (.csv)|*.csv|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            file.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            DialogResult userClickedOK = file.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                // Open the selected file to read.
                BattleInformation.Instance().ReadFile(file.FileName);
                WindowManager.Instance().Init(BattleInformation.Instance().GetHeaderInformation());

                int index = 1;
                while (true) {
                    string[] combatant = BattleInformation.Instance().GetPlayerInformation(index);
                    if (combatant == null) break;
                    WindowManager.Instance().table.AddCombatant(combatant);
                    index++;
                }
                WindowManager.Instance().table.Enter();
                Roll.Enabled = true;
                NextTurn.Enabled = true;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        


    }
}
