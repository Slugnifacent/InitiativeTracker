using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.WindowUI
{
    class WindowManager
    {
        private static WindowManager windowManager;
        NPCWindow npcWindow;
        PlayerWindow playerWindow;
        MoreInfo moreInfoWindow;
   
        TurnWindow turnWindow;

        private WindowManager()
        {
            npcWindow = new NPCWindow();
            playerWindow = new PlayerWindow();
            moreInfoWindow = new MoreInfo();
            turnWindow = new TurnWindow(playerWindow,npcWindow);
        }

        public static WindowManager Instance()
        {
            if (windowManager == null)
            {
                return windowManager = new WindowManager();
            }
            return windowManager;
        }


        public void Reset()
        {
            npcWindow.ClearPanel();
            playerWindow.ClearPanel();
            turnWindow.CreateTurnWindow(playerWindow, npcWindow);
        }

        public void OpenCSVFile(CSVFile file)
        {
            int index = 0;
            string line = "";
            while ((line = file.GetLine(index)) != null)
            {
                string[] values = line.Split('\t');
                if (values.Length > 0)
                {
                    if (values[0].CompareTo("Player") == 0)
                    {
                        playerWindow.CreateEntry(values);
                    }
                    else {
                        npcWindow.CreateEntry(values);
                    }
                }
                index++;
            }
        }

        public NPCWindow NPC
        {
            get { return npcWindow; }
        }

        public PlayerWindow PLAYER
        {
            get { return playerWindow; }
        }

        public MoreInfo MoreInfo
        {
            get { return moreInfoWindow; }
        }

        public TurnWindow TurnWindow
        {
            get { return turnWindow; }
        }

        public void UpdateTurnWindow()
        {
            turnWindow.CreateTurnWindow(playerWindow, npcWindow);
        }

        public void ShowMoreInfo(string Information)
        {
            moreInfoWindow.CreateMoreInfo(Information);
            moreInfoWindow.Enter();
        }
    }
}
