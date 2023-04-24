using AgentSim.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISS_S2.SimulationCore.Statistics
{
    /// <summary>
    /// Trieda na udrziavanie vazenej statistiky
    /// </summary>
    public class WeightedAritmeticAverage: StatisticsCore
    {
        private double _lastTimeChangeX;
        private double _currentNumberY;

        /// y ^
        ///   |
        ///   |
        ///   |         __    __
        ///   |      __|  |__|
        ///   |_____|__________________________________> x
        public WeightedAritmeticAverage(): base()
        {
            _lastTimeChangeX = 0; //CountOfWeights
            _currentNumberY = 0;
        }

        public void Add(int number, double when)
        {
            if (when < _lastTimeChangeX)
            {
                throw new ArgumentOutOfRangeException("When time is smaller than latest changed time!");
            }
            double value = (when - _lastTimeChangeX) * _currentNumberY;
            Sum += value;
            _lastTimeChangeX = when;
            //
            CountOfWeigths = _lastTimeChangeX;
            //
            _currentNumberY += number;
            SumOfSquaredValues += Math.Pow(value, 2);

        }
        public override void Reset()
        {
            base.Reset();
            _lastTimeChangeX = 0;
            _currentNumberY = 0;
        }
    }
}
