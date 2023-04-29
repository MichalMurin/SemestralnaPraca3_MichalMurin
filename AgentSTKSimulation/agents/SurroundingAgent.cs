using OSPABA;
using simulation;
using managers;
using continualAssistants;
using AgentSim.StkStation;
using DISS_S2.SimulationCore.Statistics;
using DISS_S2.StkStation;
using System.Collections.ObjectModel;
using AgentSTKSimulation.simulation;

namespace agents
{
    //meta! id="2"
    public class SurroundingAgent : Agent, IStatsDelegate
    {
        public StandartStaticstic SIMULATIONTimeInTheSystemStatistics { get; set; }
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInSystem { get; set; }
        public ObservableCollection<Customer> AllCustomers { get; set; }
        public int CurrentNumberOfCustomersInTheSystem { get; set; }
        public WeightedAritmeticAverage AverageNumberOfCustomersInSystem { get; set; }
        public StandartStaticstic TimeInTheSystemStatistics { get; set; }
        public int NumberOfCustomersInTheSystemAtAll { get; set; }
        public StandartStaticstic SIMULATIONNumberOfCustomersAtTHeEndOfDay { get; set; }
        public StkGenerator.CarTypeGenerator CarTypeGenerator { get; set; }
        public StkGenerator.CustomerTimeGenerator CustomerTimeGen { get; set; }
        public SurroundingAgent(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            TimeInTheSystemStatistics = new StandartStaticstic();
            AverageNumberOfCustomersInSystem = new WeightedAritmeticAverage();

            // Ststistiky pre viac replikacii
            SIMULATIONTimeInTheSystemStatistics = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInSystem = new StandartStaticstic();

            AllCustomers = new ObservableCollection<Customer>();
            CurrentNumberOfCustomersInTheSystem = 0;
            NumberOfCustomersInTheSystemAtAll = 0;
            // Ststistiky pre viac replikacii
            SIMULATIONNumberOfCustomersAtTHeEndOfDay = new StandartStaticstic();
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        private void Init()
        {
            new SurroundingManager(SimId.SurroundingManager, MySim, this);
            new CustomerCameScheduler(SimId.CustomerCameScheduler, MySim, this);
            AddOwnMessage(Mc.CustomerLeft);
            AddOwnMessage(Mc.Initialize);
        }
        //meta! tag="end"

        public void AddGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInSystem.AddValue(AverageNumberOfCustomersInSystem.GetAverage());
            SIMULATIONTimeInTheSystemStatistics.AddValue(TimeInTheSystemStatistics.GetAverage());
            SIMULATIONNumberOfCustomersAtTHeEndOfDay.AddValue(CurrentNumberOfCustomersInTheSystem);
        }

        public void ResetGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInSystem.Reset();
            SIMULATIONNumberOfCustomersAtTHeEndOfDay.Reset();
            SIMULATIONTimeInTheSystemStatistics.Reset();
        }

        public void CreateGenerator()
        {
            CarTypeGenerator = ((STKAgentSimulation)MySim).StkGenerators.CreateCarTypeGenerator();
            CustomerTimeGen = ((STKAgentSimulation)MySim).StkGenerators.CreateCustomerTimeGenerator();
        }

        public void FinishStatsAfterReplication()
        {
            // zaratame do casu ostavajucich ludi v prevadzke
            foreach (var customer in AllCustomers)
            {
                TimeInTheSystemStatistics.AddValue(STKAgentSimulation.MAX_TIME - customer.StartWaitingTime);
            }
            AverageNumberOfCustomersInSystem.Add(0, STKAgentSimulation.MAX_TIME);
        }
    }
}
