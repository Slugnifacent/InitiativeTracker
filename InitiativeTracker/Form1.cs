using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InitiativeTracker.WindowUI;

namespace InitiativeTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            WindowManager.Instance();
            PlayerWindow window = WindowManager.Instance().PLAYER;
            window.CreateEntry("10", "friend", "Sorealius", "50", "500", "500");
            window.CreateEntry("flame", "friend", "Cool", "Booky", "Waterbug", "Signosis");
            
            NPCWindow npc = WindowManager.Instance().NPC;
            npc.CreateEntry("11", "enemy", "50", "500", "500");
            npc.CreateEntry("12", "enemy", "Booky", "Waterbug", "Signosis");
            npc.CreateEntry("13", "enemy", "50", "500", "500");
            npc.CreateEntry("flame", "enemy", "Booky", "Waterbug", "Signosis");
            WindowManager.Instance().UpdateTurnWindow();


            WindowManager.Instance().TurnWindow.Enter();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowManager.Instance().TurnWindow.RollForInitiative();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WindowManager.Instance().TurnWindow.NextTurn(null);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            CSVFile csv;
            OpenFileDialog file = new OpenFileDialog();

            // Set filter options and filter index.
            file.Filter = "CSV Files (.csv)|*.csv|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            file.FilterIndex = 1;
            file.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            DialogResult userClickedOK = file.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                // Open the selected file to read.
                csv = new CSVFile(file.FileName);
                WindowManager.Instance().Reset();
                WindowManager.Instance().OpenCSVFile(csv);
                WindowManager.Instance().UpdateTurnWindow();
            }

        }
    }
}
