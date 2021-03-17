using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
    public class DoorStateEventArgs : EventArgs
    {
        public bool DoorState { set; get; }
    }

    public interface IDoor
    {
        event EventHandler<DoorStateEventArgs> DoorStateEvent;

        bool CurrentDoorState { get; }

        void LockDoor();

        void UnlockDoor();

    }

}
