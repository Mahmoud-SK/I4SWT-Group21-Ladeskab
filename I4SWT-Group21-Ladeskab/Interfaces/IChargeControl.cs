using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
    public interface IChargeControl
    {
        public bool isConnected();
        public void startCharge();
        public void stopCharge();

    }
}
