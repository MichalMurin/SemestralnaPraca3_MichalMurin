using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISS_S2
{
    /// <summary>
    /// Trieda pre spravu generatora exponencialneho rozdelenia
    /// </summary>
    internal class ExponentialDistribution
    {
        private double _lambda;
        private Random _generator;
        /// <summary>
        /// Konstruktor generatora pre exponencialne rozdelenie
        /// </summary>
        /// <param name="mi">stredna hodnota</param>
        /// <param name="seedGenerator">generator nasad</param>
        public ExponentialDistribution(double mi, Random seedGenerator)
        {
            _generator = new Random(seedGenerator.Next());
            _lambda = 1.0 / mi;
        }

        public double GetExponencialDouble()
        {
            double u = _generator.NextDouble();
            return -Math.Log(1-u) / _lambda; 
        }
    }
}
