using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
	public class StationControl
	{
		// Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
		private enum LadeskabState
		{
			Available,
			Locked,
			DoorOpen
		};

		private LadeskabState _state;
		private IChargeControl _charger;
		private int _oldId;
		private IDoor _door;
		private IRfidReader _rfid;
		private IDisplay _display;
		private ILogFile _logfile;


		//private string logFile = "logfile.txt"; // Navnet på systemets log-fil - Udkommenteret for nu, det her laves i LogFile istedet for.

		public StationControl(IChargeControl charger, IDoor door, IRfidReader rfid, IDisplay display, ILogFile logfile)
		{
			_charger = charger;
			_door = door;
			_rfid = rfid;
			_display = display;
			_logfile = logfile;
            _state = LadeskabState.Available;

			_rfid.RfidDetectedEvent += RfidDetected;
			_door.DoorStateEvent += DoorEventHandler;

		}

		// Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
		private void RfidDetected(object sender, RfidEventArgs e)
		{
			switch (_state)
			{
				case LadeskabState.Available:
					// Check for ladeforbindelse
					if (_charger.Connected())
					{
						_door.LockDoor();
						_charger.StartCharge();
						_oldId = e.Id;
						_logfile.LogDoorLocked(e.Id);

						
						_display.ShowInstruction("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
						_state = LadeskabState.Locked;
					}
					else
					{
						_display.ShowInstruction("Din telefon er ikke ordentlig tilsluttet. Prøv igen."); 
					}

					break;

				case LadeskabState.DoorOpen:
					// Ignore
					break;

				case LadeskabState.Locked:
					// Check for correct ID
					if (e.Id == _oldId)
					{
						_charger.StopCharge();
						_door.UnlockDoor();
						_logfile.LogDoorUnlocked(e.Id);

						_display.ShowInstruction("Tag din telefon ud af skabet og luk døren");
						_state = LadeskabState.Available;
					}
					else
					{
						_display.ShowInstruction("Forkert RFID tag");
					}

					break;
			}
		}

		private void DoorEventHandler(object sender, DoorStateEventArgs e)
		{
			switch (_state)
			{
				case LadeskabState.Available:
					if (e.DoorOpen == true)
					{
						_state = LadeskabState.DoorOpen;
						_display.ShowInstruction("Tilslut Telefon");
					}
					break;

				case LadeskabState.DoorOpen:
					if (e.DoorOpen == false)
					{
						_state = LadeskabState.Available;
						_display.ShowInstruction("Indlæs RFID");
					}
					else
					{
						_display.ShowInstruction("Luk døren");
					}
					break;

				case LadeskabState.Locked:
					
					break;
			}
		}
	}
}


