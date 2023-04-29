using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSTKSimulation.simulation
{
    public interface IPrepareSimulation
    {
        void AddGlobalStats();
        void ResetGlobalStats();
        void CreateGenerator();
    }
}
