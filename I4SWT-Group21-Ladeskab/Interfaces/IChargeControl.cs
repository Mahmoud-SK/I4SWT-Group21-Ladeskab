﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
    public interface IChargeControl
    {
        public bool Connected();
        public void StartCharge();
        public void StopCharge();

    }
}
