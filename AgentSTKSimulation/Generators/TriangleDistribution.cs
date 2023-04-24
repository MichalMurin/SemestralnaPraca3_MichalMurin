using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.Generators
{
    /// <summary>
    /// Trieda pre spravu generatora trojuholnkoveho rozdelenia
    /// </summary>
    internal class TriangleDistribution
    {
        private double _min;
        private double _max;
        private double _modus;
        private Random _generator;
        /// <summary>
        /// konstruktor generatora trojuholnikoveho rozdelenia
        /// </summary>
        /// <param name="min">minimum</param>
        /// <param name="max">maximum</param>
        /// <param name="modus">modus</param>
        /// <param name="seedGenerator">generator nasad</param>
        public TriangleDistribution(double min, double max, double modus, Random seedGenerator)
        {
            _min = min;
            _max = max;
            _modus = modus;
            _generator = new Random(seedGenerator.Next());
        }

        public double GetTriangleDouble()
        {
            // https://en.wikipedia.org/wiki/Triangular_distribution

            double F = (_modus - _min) / (_max - _min);
            double U = _generator.NextDouble();

            if (U < F)
            {
                return _min + Math.Sqrt(U * (_max - _min) * (_modus - _min));
            }
            else
            {
                return _max - Math.Sqrt((1 - U) * (_max - _min) * (_max - _modus));
            }
        }
    }
}
