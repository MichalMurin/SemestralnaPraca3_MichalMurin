using OSPABA;
using agents;
using AgentSim.StkStation.Models;
using AgentSim.StkStation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using AgentSTKSimulation.simulation;

namespace simulation
{
	public class STKAgentSimulation : Simulation
	{
        public static int MAX_TIME = 8 * 3600;
        public SimulationMode Mode { get; set; }
        private DateTime _startTime;
        public int Seed { get; set; }
        public double CustomersFlow { get; set; }
        public bool IsValidation { get; set; }
        public bool IsTimeForLunch { get; set; }
        public StkGenerator StkGenerators { get; private set; }
        private Random _seedGenerator;
        public List<IStatsDelegate> GlobalStatsAgents { get; set; }
        public bool CorrectReplicationRun { get; set; }

        //public ObservableCollection<Worker> AllWorkers { get; set; }
        /// Standartne Statistiky
        /// Vazene statistiky
        public STKAgentSimulation(): base()
		{
            _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(9);
            Seed = -1;
            CustomersFlow = 23;
            IsValidation = false;
            IsTimeForLunch = false;
            GlobalStatsAgents = new List<IStatsDelegate>();
            Init();
            RegisterPrepareSimAgents();
        }

        private void RegisterPrepareSimAgents()
        {
            GlobalStatsAgents.Add(SurroundingAgent);
            GlobalStatsAgents.Add(MechanicsAgent);
            GlobalStatsAgents.Add(TechniciansAgent);
        }

        override protected void PrepareSimulation()
		{
			base.PrepareSimulation();
            IsValidation = false;
            IsTimeForLunch = false;
            CorrectReplicationRun = true;
            if (Seed > 0)
            {
                _seedGenerator = new Random(Seed);
            }
            else
            {
                _seedGenerator = new Random();
            }

            StkGenerators = new StkGenerator(_seedGenerator);
            StkGenerators.CustomersFlow = CustomersFlow;
            foreach (var agent in GlobalStatsAgents)
            {
                agent.ResetGlobalStats();
                agent.CreateGenerator();
            }
            if (IsValidation)
            {
                MechanicsAgent.MechanicsService.NonCertificatedNumber = 0;
            }

            // Create global statistcis
        }

		override protected void PrepareReplication()
		{
			base.PrepareReplication();
            // Reset entities, queues, local statistics, etc...
        }

		override protected void ReplicationFinished()
		{
            // Collect local statistics into global, update UI, etc...
			base.ReplicationFinished();
            // TODO KONTROLA CI DOBEHLA REPLIKACIA KOREKTNE
            if (CorrectReplicationRun)
            {
                foreach (var agent in GlobalStatsAgents)
                {
                    agent.FinishStatsAfterReplication();
                    agent.AddGlobalStats();
                }

                ////////////////
                var mechanics = MechanicsAgent.MechanicsService.AllWorkers;
                foreach (var item in mechanics)
                {
                    if (!item.HadLunch)
                    {
                        throw new ArgumentException("Niekto nemal obed");
                    }
                }
                var technics = TechniciansAgent.TechniciansService.AllWorkers;
                foreach (var item in technics)
                {
                    if (!item.HadLunch)
                    {
                        throw new ArgumentException("Niekto nemal obed");
                    }
                }
                ///////////////////////
                
            }
            if (Mode == SimulationMode.FAST && (CurrentReplication+1) % 100 == 0)
            {
                RefreshGui();
            }

            
        }

        private void RefreshGui()
        {
            foreach (var item in Delegates)
            {
                item.Refresh(this);
            }
        }

		override protected void SimulationFinished()
		{
			// Dysplay simulation results
			base.SimulationFinished();
            RefreshGui();
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
        /// Ziskanie simulacneho casu v DateTime formate
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurentTimeInDatFormat()
        {
            return _startTime.AddSeconds(CurrentTime);
        }
    }
}

