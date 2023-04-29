using OSPABA;
using agents;
using AgentSim.StkStation.Models;
using AgentSim.StkStation;
using DISS_S2.SimulationCore.Statistics;
using DISS_S2.StkStation;
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
        public StkGenerator StkGenerators { get; private set; }
        private Random _seedGenerator;
        public List<IStatsDelegate> GlobalStatsAgents { get; set; }

        //public ObservableCollection<Worker> AllWorkers { get; set; }
        /// Standartne Statistiky
        /// Vazene statistiky
        public STKAgentSimulation(): base()
		{
            _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(9);
            Seed = -1;
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
            if (Seed > 0)
            {
                _seedGenerator = new Random(Seed);
            }
            else
            {
                _seedGenerator = new Random();
            }

            StkGenerators = new StkGenerator(_seedGenerator);
            foreach (var agent in GlobalStatsAgents)
            {
                agent.ResetGlobalStats();
                agent.CreateGenerator();
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
            foreach (var agent in GlobalStatsAgents)
            {
                agent.FinishStatsAfterReplication();
                agent.AddGlobalStats();
            }
            if (this.CurrentReplication % 100 == 0)
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

