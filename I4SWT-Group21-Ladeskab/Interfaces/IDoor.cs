using System;
using System.Collections.Generic;
using System.Text;

namespace I4SWT_Group21_Ladeskab
{
    public class DoorStateEventArgs : EventArgs
    {
        public bool DoorState { get;}
        private bool doorState;
    }

    
    public interface IDoor
    {
        event EventHandler<DoorStateEventArgs> doorStateEvent;

        bool currentDoorState { get; }

        void lockDoor();

        void unlockDoor();

    }

}
