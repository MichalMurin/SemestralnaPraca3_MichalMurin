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
    /// <summary>
    /// Agent okolia
    /// </summary>
    //meta! id="2"
    public class SurroundingAgent : Agent, IStatsDelegate
    {
        /// <summary>
        /// Globalna statisitka casu v systeme
        /// </summary>
        public StandartStaticstic SIMULATIONTimeInTheSystemStatistics { get; set; }
        /// <summary>
        /// Globalna statistika poctu zakaznikov v systeme
        /// </summary>
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInSystem { get; set; }
        /// <summary>
        /// Globalna statistika pocet zakaznikov na konci dna
        /// </summary>
        public StandartStaticstic SIMULATIONNumberOfCustomersAtOneDay { get; set; }
        /// <summary>
        /// Globalna statistika pocet zakaznikov na konci dna
        /// </summary>
        public StandartStaticstic SIMULATIONNumberOfCustomersAtTHeEndOfDay { get; set; }
        /// <summary>
        /// Zoznam vsetkych zakaznikov v systeme
        /// </summary>
        public ObservableCollection<Customer> AllCustomers { get; set; }
        /// <summary>
        /// Aktualny pocet zakaznikov v systeme
        /// </summary>
        public int CurrentNumberOfCustomersInTheSystem { get; set; }
        /// <summary>
        /// Statistika pocet zakaznikov v systeme
        /// </summary>
        public WeightedAritmeticAverage AverageNumberOfCustomersInSystem { get; set; }
        /// <summary>
        /// Statistika cas v systeme
        /// </summary>
        public StandartStaticstic TimeInTheSystemStatistics { get; set; }
        /// <summary>
        /// Celkovy pocet zakaznikov za den
        /// </summary>
        public int NumberOfCustomersInTheSystemAtAll { get; set; }
        /// <summary>
        /// Generator typoc vozidla
        /// </summary>
        public StkGenerator.CarTypeGenerator CarTypeGenerator { get; set; }
        /// <summary>
        /// Generator prichodu zakaznika
        /// </summary>
        public StkGenerator.CustomerTimeGenerator CustomerTimeGen { get; set; }
        /// <summary>
        /// Percentualny narast prichodov zakaznikov
        /// </summary>
        public double CustomersFlowIncreaseInPercent { get; set; }
        /// <summary>
        /// Ignorovanie zostavajucich zakaznikov na konci dna
        /// </summary>
        public bool IgnoreReaminingCustomers { get; set; }
        public SurroundingAgent(int id, Simulation mySim, Agent parent) :
            base(id, mySim, parent)
        {
            TimeInTheSystemStatistics = new StandartStaticstic();
            AverageNumberOfCustomersInSystem = new WeightedAritmeticAverage();

            // Ststistiky pre viac replikacii
            SIMULATIONTimeInTheSystemStatistics = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInSystem = new StandartStaticstic();
            SIMULATIONNumberOfCustomersAtOneDay = new StandartStaticstic();
            SIMULATIONNumberOfCustomersAtTHeEndOfDay = new StandartStaticstic();

            AllCustomers = new ObservableCollection<Customer>();
            CurrentNumberOfCustomersInTheSystem = 0;
            NumberOfCustomersInTheSystemAtAll = 0;
            CustomersFlowIncreaseInPercent = 0;
            IgnoreReaminingCustomers = false;
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
            SIMULATIONNumberOfCustomersAtOneDay.AddValue(NumberOfCustomersInTheSystemAtAll);
        }

        public void ResetGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInSystem.Reset();
            SIMULATIONNumberOfCustomersAtTHeEndOfDay.Reset();
            SIMULATIONTimeInTheSystemStatistics.Reset();
            SIMULATIONNumberOfCustomersAtOneDay.Reset();
        }

        public void CreateGenerator(StkGenerator generators)
        {
            CarTypeGenerator = generators.CreateCarTypeGenerator();
            CustomerTimeGen = generators.CreateCustomerTimeGenerator(CustomersFlowIncreaseInPercent);
        }

        public void FinishStatsAfterReplication()
        {
            if (!IgnoreReaminingCustomers)
            {
                // zaratame do casu ostavajucich ludi v prevadzke
                foreach (var customer in AllCustomers)
                {
                    TimeInTheSystemStatistics.AddValue(STKAgentSimulation.MAX_TIME - customer.StartWaitingTime);
                }
            }
            AverageNumberOfCustomersInSystem.Add(0, STKAgentSimulation.MAX_TIME);
        }
    }
}