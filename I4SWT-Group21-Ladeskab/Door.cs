using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door : IDoor
    {
        private bool DoorState;
        public bool CurrentDoorState { get; }

        public event EventHandler<DoorStateEventArgs> DoorStateEvent;

        public void LockDoor()
        {
            DoorState = true;
        }

        public void UnlockDoor()
        {
            DoorState = false;
        }
    }
}
