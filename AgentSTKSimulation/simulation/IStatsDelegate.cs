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
        /// <summary>
        /// Update globalnych statistik
        /// </summary>
        void AddGlobalStats();
        /// <summary>
        /// Resetovanie globalnych statistik
        /// </summary>
        void ResetGlobalStats();
        /// <summary>
        /// Vytvorenie generatora
        /// </summary>
        /// <param name="generators"></param>
        void CreateGenerator(StkGenerator generators);
        /// <summary>
        /// Ukoncenie lokalnych statistik na konci dna
        /// </summary>
        void FinishStatsAfterReplication();
    }
}
