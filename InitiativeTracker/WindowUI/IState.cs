using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.WindowUI
{
    interface IWindow
    {
        void Enter();
        void Exit();
        IWindow GetNextWindow();
    }
}
