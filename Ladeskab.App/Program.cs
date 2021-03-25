using Ladeskab;
using System;
using Ladeskab.Class.Library.Interfaces;
using Ladeskab.Interfaces;

namespace Ladeskab.App
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleWriter writer = new ConsoleWriter();
            Display display = new Display(writer);
            LogFile logfile = new LogFile();
            RfidReader rfid = new RfidReader();
            Door door = new Door();
            UsbChargerSimulator usbCharger = new UsbChargerSimulator();
            ChargeControl chargeControl = new ChargeControl(display, usbCharger);
            StationControl station = new StationControl(chargeControl, door, rfid, display, logfile);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpen();
                        break;

                    case 'C':
                        door.OnDoorClose();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfid.OnRfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
