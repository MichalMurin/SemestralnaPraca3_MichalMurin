﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralnaPraca3_MichalMurin
{
    internal interface ISimulationStoppable
    {
        void StopSimulation();
        void SetControlVisible(bool visible);
    }
}
