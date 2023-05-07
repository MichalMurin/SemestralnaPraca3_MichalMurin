using AgentSim.StkStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSTKSimulation.simulation
{
    public interface IStatsDelegate
    {
        void AddGlobalStats();
        void ResetGlobalStats();
        void CreateGenerator(StkGenerator generators);
        void FinishStatsAfterReplication();
    }
}
