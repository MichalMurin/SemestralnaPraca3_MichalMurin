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
        public double CustomersFlow { get; set; }
        public class CustomerTimeGenerator
        {
            private ExponentialDistribution _customerTimeGapGenerator;
            public CustomerTimeGenerator(Random seedGenerator, double customersFlow)
            {
                // mi = 3600/23 .... 23x za hodinu 
                _customerTimeGapGenerator = new ExponentialDistribution(3600.0 / customersFlow, seedGenerator);
            }
            public double GetCustomerGapTime()
            {
                return _customerTimeGapGenerator.GetExponencialDouble();
            }
        }

        public class AcceptanceCarGenerator
        {
            private TriangleDistribution _acceptanceTimeGenerator;
            public AcceptanceCarGenerator(Random seedGenerator)
            {
                _acceptanceTimeGenerator = new TriangleDistribution(180, 695, 431, seedGenerator);
            }

            public double GetAcceptanceTime()
            {
                return _acceptanceTimeGenerator.GetTriangleDouble();
            }
        }

        public class PaymentTimeGenerator
        {

            private Random _paymentTimeGenerator;
            public PaymentTimeGenerator(Random seedGenerator)
            {
                _paymentTimeGenerator = new Random(seedGenerator.Next());
            }
            public double GetPaymentTime()
            {
                return _paymentTimeGenerator.NextDouble() * (177 - 65) + 65;
            }
        }

        public class InspectionTimeGenerator
        {
            private Random _normalCarServiceTimegenerator;
            private DiscretEmpiricGenerator _vanServiceTimeGenerator;
            private DiscretEmpiricGenerator _truckServiceTimeGenerator;
            public InspectionTimeGenerator(Random seedGenerator)
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
        }

        public class CarTypeGenerator
        {
            private DiscretEmpiricGenerator _carTypeGenerator;
            public CarTypeGenerator(Random seedGenerator)
            {
                _carTypeGenerator = new DiscretEmpiricGenerator
                (
                    new List<(double, int, int, Random)>
                    {
                        (0.65,2,2,new Random(seedGenerator.Next())),
                        (0.21,2,2,new Random(seedGenerator.Next())),
                        (0.14,2,2,new Random(seedGenerator.Next()))
                    },
                    seedGenerator
                    );
            }
            public CarType GetCarType()
            {
                return (CarType)_carTypeGenerator.GetRandomNumber();
            }
        }


        private Random _seedGen;
        public StkGenerator(Random seedGenerator)
        {
            _seedGen = seedGenerator;
            CustomersFlow = 23;
        }

        public CustomerTimeGenerator CreateCustomerTimeGenerator()
        {
            return new CustomerTimeGenerator(_seedGen, CustomersFlow);
        }

        public AcceptanceCarGenerator CreateAcceptanceTimeGen()
        {
            return new AcceptanceCarGenerator(_seedGen);
        }

        public InspectionTimeGenerator CreateInspectionTimeGen()
        {
            return new InspectionTimeGenerator(_seedGen);
        }
        public PaymentTimeGenerator CreatePaymentTimeGen()
        {
            return new PaymentTimeGenerator(_seedGen);
        }

        public CarTypeGenerator CreateCarTypeGenerator()
        {
            return new CarTypeGenerator(_seedGen);
        }





    }
}
