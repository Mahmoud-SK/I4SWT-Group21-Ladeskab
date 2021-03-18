using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
    public class DoorStateEventArgs : EventArgs
    {
        public bool DoorOpen { set; get; }
    }

    public interface IDoor
    {
        event EventHandler<DoorStateEventArgs> DoorStateEvent;

        void LockDoor();

        void UnlockDoor();

    }

}
