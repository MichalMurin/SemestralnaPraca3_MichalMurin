using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.Statistics
{
    /// <summary>
    /// Abstraktny predok statistik
    /// </summary>
    public abstract class StatisticsCore
    {
        public double Sum { get; set; }
        public double CountOfWeigths { get; set; }
        public double SumOfSquaredValues { get; set; }

        public StatisticsCore()
        {
            Sum = 0;
            CountOfWeigths = 0;
            SumOfSquaredValues = 0;
        }
        public double GetAverage()
        {
            if (CountOfWeigths > 0)
            {
                return Sum / CountOfWeigths;
            }
            else
            {
                return 0;
            }
        }

        public double GetStandartDeviation()
        {
            var a = ((1 / (CountOfWeigths - 1)) * SumOfSquaredValues);
            var b = (1/(CountOfWeigths-1))*(Math.Pow(Sum,2)/CountOfWeigths );
            var c = Math.Sqrt(a - b);
            return c;
        }

        public (double, double) GetConfidenceInterval(double probability)
        {
            double tAlfa;
            switch (probability)
            {
                case 0.95:
                    tAlfa = 1.96;
                    break;
                case 0.9:
                    tAlfa = 1.645;
                    break;
                default:
                    throw new ArgumentException("Not Defined probability for confidencial interval! Please define t_alfa!");
            }
            double left = GetAverage() - ((GetStandartDeviation() * tAlfa) / Math.Sqrt(CountOfWeigths));
            double right = GetAverage() + ((GetStandartDeviation() * tAlfa) / Math.Sqrt(CountOfWeigths));
            return (left, right);
        }

        public virtual void Reset()
        {
            Sum = 0;
            CountOfWeigths = 0;
            SumOfSquaredValues = 0;
        }
    }
}
