using AgentSim.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISS_S2.SimulationCore.Statistics
{
    /// <summary>
    /// Trieda na udrziavanie standartnej statistiky
    /// </summary>
    public class StandartStaticstic: StatisticsCore
    {

        public StandartStaticstic(): base()
        {
        }
        public void AddValue(double value)
        {
            Sum += value;
            CountOfWeigths++;
            SumOfSquaredValues += Math.Pow(value, 2);
        }        
    }
}
