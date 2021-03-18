using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door : IDoor
    {
        private bool DoorLock;


        public event EventHandler<DoorStateEventArgs> DoorStateEvent;


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
