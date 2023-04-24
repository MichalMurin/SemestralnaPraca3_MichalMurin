using OSPABA;
using agents;
using AgentSim.StkStation.Models;
using AgentSim.StkStation;
using DISS_S2.SimulationCore.Statistics;
using DISS_S2.StkStation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace simulation
{
	public class STKAgentSimulation : Simulation
	{
        public SimulationMode Mode { get; set; }
        public int ReplicationCounter { get; private set; }
        // cas v sekundach
        public const int CUSTOMER_STOP_COMMING_TIME = ((15 - 9) * 60 + 45) * 60;
        private DateTime _startTime;
        public int Seed { get; set; }
        public StkGenerator StkGenerators { get; private set; }
        private Random _seedGenerator;
        //public Queue<Customer> CustomerQueueForAcceptance { get; set; }
        //public Queue<Customer> CustomerQueueForPayment { get; set; }
        //public GarageParking ParkingInGarage { get; set; }
        //public Queue<Mechanic> FreeMechanics { get; set; }
        //public Queue<Technician> FreeTechnicians { get; set; }
        //public ObservableCollection<Worker> AllWorkers { get; set; }
        //public ObservableCollection<Customer> AllCustomers { get; set; }
        //public int TechniciansNumber { get; set; }
        //public int MechanicsNumber { get; set; }
        //public int NumberOfCustomersInTheSystemAtAll { get; set; }
        //public int CurrentNumberOfCustomersInTheSystem { get; set; }
        /// Standartne Statistiky
        public StandartStaticstic TimeInTheSystemStatistics { get; set; }
        public StandartStaticstic TimeWaitingForAcceptanceStatistics { get; set; }
        public StandartStaticstic SIMULATIONNumberOfCustomersAtTHeEndOfDay { get; set; }
        public StandartStaticstic SIMULATIONTimeInTheSystemStatistics { get; set; }
        public StandartStaticstic SIMULATIONTimeWaitingForAcceptanceStatistics { get; set; }
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeTechnicians { get; set; }
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeMechanics { get; set; }
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInQueueForAcceptance { get; set; }
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInSystem { get; set; }
        /// Vazene statistiky
        public WeightedAritmeticAverage AvergaeNumberOfFreeTechnicians { get; set; }
        public WeightedAritmeticAverage AvergaeNumberOfFreeMechanics { get; set; }
        public WeightedAritmeticAverage AverageNumberOfCustomersInQueueForAcceptance { get; set; }
        public WeightedAritmeticAverage AverageNumberOfCustomersInSystem { get; set; }
        public STKAgentSimulation()
		{
			Init();

            Seed = -1;
            _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(9);

            TimeInTheSystemStatistics = new StandartStaticstic();
            TimeWaitingForAcceptanceStatistics = new StandartStaticstic();
            AvergaeNumberOfFreeTechnicians = new WeightedAritmeticAverage();
            AvergaeNumberOfFreeMechanics = new WeightedAritmeticAverage();
            AverageNumberOfCustomersInQueueForAcceptance = new WeightedAritmeticAverage();
            AverageNumberOfCustomersInSystem = new WeightedAritmeticAverage();

            // Ststistiky pre viac replikacii
            SIMULATIONNumberOfCustomersAtTHeEndOfDay = new StandartStaticstic();
            SIMULATIONTimeInTheSystemStatistics = new StandartStaticstic();
            SIMULATIONTimeWaitingForAcceptanceStatistics = new StandartStaticstic();
            SIMULATIONAvergaeNumberOfFreeTechnicians = new StandartStaticstic();
            SIMULATIONAvergaeNumberOfFreeMechanics = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInSystem = new StandartStaticstic();
        }

		override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
            ResetSimulationStats();
			// Create global statistcis
		}

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
            ResetReplicationStats();
			// Reset entities, queues, local statistics, etc...
		}

		override protected void ReplicationFinished()
		{
			// Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();
		}

		override protected void SimulationFinished()
		{
			// Dysplay simulation results
			base.SimulationFinished();
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			ModelAgent = new ModelAgent(SimId.ModelAgent, this, null);
			SurroundingAgent = new SurroundingAgent(SimId.SurroundingAgent, this, ModelAgent);
			STKAgent = new STKAgent(SimId.STKAgent, this, ModelAgent);
			TechniciansAgent = new TechniciansAgent(SimId.TechniciansAgent, this, STKAgent);
			MechanicsAgent = new MechanicsAgent(SimId.MechanicsAgent, this, STKAgent);
		}
		public ModelAgent ModelAgent
		{ get; set; }
		public SurroundingAgent SurroundingAgent
		{ get; set; }
		public STKAgent STKAgent
		{ get; set; }
		public TechniciansAgent TechniciansAgent
		{ get; set; }
		public MechanicsAgent MechanicsAgent
		{ get; set; }
        //meta! tag="end"

        /// <summary>
        /// Resetovanie replikacnych statistik
        /// </summary>
        private void ResetReplicationStats()
        {
            TimeInTheSystemStatistics.Reset();
            TimeWaitingForAcceptanceStatistics.Reset();
            AvergaeNumberOfFreeMechanics.Reset();
            AvergaeNumberOfFreeTechnicians.Reset();
            AverageNumberOfCustomersInQueueForAcceptance.Reset();
            AverageNumberOfCustomersInSystem.Reset();
        }
        /// <summary>
        /// Resetovanie simulacnych statistik
        /// </summary>
        private void ResetSimulationStats()
        {
            SIMULATIONNumberOfCustomersAtTHeEndOfDay.Reset();
            SIMULATIONTimeInTheSystemStatistics.Reset();
            SIMULATIONTimeWaitingForAcceptanceStatistics.Reset();
            SIMULATIONAvergaeNumberOfFreeMechanics.Reset();
            SIMULATIONAvergaeNumberOfFreeTechnicians.Reset();
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.Reset();
            SIMULATIONAverageNumberOfCustomersInSystem.Reset();
        }

        /// <summary>
        /// Ziskanie simulacneho casu v DateTime formate
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurentTimeInDatFormat()
        {
            return _startTime.AddSeconds(CurrentTime);
        }
    }
}

