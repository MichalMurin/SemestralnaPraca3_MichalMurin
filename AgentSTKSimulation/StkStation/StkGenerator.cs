using AgentSim.Generators;
using AgentSim.StkStation.Models;
using DISS_S2;
using SemestralnaPraca1_Michal_murin_Diss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.StkStation
{
    /// <summary>
    /// Trieda pre spravu generatorov simulacie STK
    /// </summary>
    public class StkGenerator
    {
        private Random _normalCarServiceTimegenerator;
        private DiscretEmpiricGenerator _vanServiceTimeGenerator;
        private DiscretEmpiricGenerator _truckServiceTimeGenerator;

        private ExponentialDistribution _customerTimeGapGenerator;

        private DiscretEmpiricGenerator _carTypeGenerator;

        private TriangleDistribution _acceptanceTimeGenerator;

        private Random _paymentTimeGenerator;

        public StkGenerator(Random seedGenerator)
        {
            _normalCarServiceTimegenerator = new Random(seedGenerator.Next());
            _vanServiceTimeGenerator = new DiscretEmpiricGenerator
                (
                    new List<(double, int, int, Random)>
                    {
                        (0.2,35*60,37*60,new Random(seedGenerator.Next())),
                        (0.35,38*60,40*60,new Random(seedGenerator.Next())),
                        (0.3,41*60,47*60,new Random(seedGenerator.Next())),
                        (0.15,48*60,52*60,new Random(seedGenerator.Next()))
                    },
                    seedGenerator
                );
            _truckServiceTimeGenerator = new DiscretEmpiricGenerator
                (
                    new List<(double, int, int, Random)>
                    {
                        (0.05,37*60,42*60,new Random(seedGenerator.Next())),
                        (0.1,43*60,45*60,new Random(seedGenerator.Next())),
                        (0.15,46*60,47*60,new Random(seedGenerator.Next())),
                        (0.4,48*60,51*60,new Random(seedGenerator.Next())),
                        (0.25,52*60,55*60,new Random(seedGenerator.Next())),
                        (0.05,56*60,65*60,new Random(seedGenerator.Next()))
                    },
                    seedGenerator
                );


            // mi = 3600/23 .... 23x za hodinu 
            _customerTimeGapGenerator = new ExponentialDistribution(3600.0 / 23.0, seedGenerator);


            _carTypeGenerator = new DiscretEmpiricGenerator
                (
                    new List<(double, int, int, Random)>
                    {
                        (0.65,0,0,new Random(seedGenerator.Next())),
                        (0.21,1,1,new Random(seedGenerator.Next())),
                        (0.14,2,2,new Random(seedGenerator.Next()))
                    },
                    seedGenerator
                );

            _acceptanceTimeGenerator = new TriangleDistribution(180, 695, 431, seedGenerator);
            _paymentTimeGenerator = new Random(seedGenerator.Next());
        }

        public int GetServiceTimeInSec(CarType type)
        {
            switch (type)
            {
                case CarType.PERSONAL:
                    return _normalCarServiceTimegenerator.Next((45 * 60) - (31 * 60) + 1) + (31 * 60);
                case CarType.VAN:
                    return _vanServiceTimeGenerator.GetRandomNumber();
                case CarType.TRUCK:
                    return _truckServiceTimeGenerator.GetRandomNumber();
                default:
                    throw new ArgumentException("Wrong car type!");
            }
        }

        public double GetCustomerGapTime()
        {
            return _customerTimeGapGenerator.GetExponencialDouble();
        }

        public CarType GetCarType()
        {
            return (CarType)_carTypeGenerator.GetRandomNumber();
        }

        public double GetAcceptanceTime()
        {
            return _acceptanceTimeGenerator.GetTriangleDouble();
        }

        public double GetPaymentTime()
        {
            return _paymentTimeGenerator.NextDouble() * (177 - 65) + 65;
        }
    }
}
