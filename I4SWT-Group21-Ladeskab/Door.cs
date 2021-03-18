using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Door : IDoor
    {
        private bool DoorState;

        public event EventHandler<DoorStateEventArgs> DoorStateEvent;

        public bool CurrentDoorState { get; private set; }


        public void LockDoor()
        {
            if (CurrentDoorState)
                DoorState = true;
        }

        public void UnlockDoor()
        {
            if (!CurrentDoorState)
                DoorState = false;
        }
    }
}
