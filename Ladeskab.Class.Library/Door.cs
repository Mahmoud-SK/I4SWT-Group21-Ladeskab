using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door : IDoor
    {
        public bool DoorLock { get; set; }


        public event EventHandler<DoorStateEventArgs> DoorStateEvent;

        public Door()
        {
            DoorLock = false;
        }

        public void LockDoor()
        {
            DoorLock = true;
        }

        public void UnlockDoor()
        {
            DoorLock = false;
        }

        public void OnDoorOpen()
        {
            DoorStateEvent?.Invoke(this, new DoorStateEventArgs() { DoorOpen = true });
        }

        public void OnDoorClose()
        {
            DoorStateEvent?.Invoke(this, new DoorStateEventArgs() { DoorOpen = false });
        }

    }
}
