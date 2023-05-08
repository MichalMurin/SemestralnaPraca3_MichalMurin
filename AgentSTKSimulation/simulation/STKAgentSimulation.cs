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
        public bool IsValidation { get; set; }
        private Random _seedGenerator;
        public List<IStatsDelegate> GlobalStatsAgents { get; set; }
        public bool CorrectReplicationRun { get; set; }

        public STKAgentSimulation(): base()
		{
            _startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(9);
            Seed = -1;
            IsValidation = false;
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

            var generators = new StkGenerator(_seedGenerator);
            foreach (var agent in GlobalStatsAgents)
            {
                agent.ResetGlobalStats();
                agent.CreateGenerator(generators);
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
            CorrectReplicationRun = true;
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

                //////////////////
                //var mechanics = MechanicsAgent.MechanicsService.AllWorkers;
                //foreach (var item in mechanics)
                //{
                //    if (!item.HadLunch)
                //    {
                //        throw new ArgumentException("Niekto nemal obed");
                //    }
                //}
                //var technics = TechniciansAgent.TechniciansService.AllWorkers;
                //foreach (var item in technics)
                //{
                //    if (!item.HadLunch)
                //    {
                //        throw new ArgumentException("Niekto nemal obed");
                //    }
                //}
                /////////////////////////
                
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

        public void SaveCsvResults(string path)
        {
            var list = new List<string>();
            var customersIncrease = ((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).CustomersFlowIncreaseInPercent;
            var techsNum = ((TechniciansAgent)FindAgent(SimId.TechniciansAgent)).TechniciansService.WorkersNumber;
            var certificatedMechsNum = ((MechanicsAgent)FindAgent(SimId.MechanicsAgent)).MechanicsService.WorkersNumber;
            var nonCertificatedMechsnum = ((MechanicsAgent)FindAgent(SimId.MechanicsAgent)).MechanicsService.NonCertificatedNumber;
            var replications = (this.CurrentReplication + 1).ToString();
            var avgWaitingTimet = (((TechniciansAgent)FindAgent(SimId.TechniciansAgent)).SIMULATIONTimeWaitingForAcceptanceStatistics.GetAverage() / 60).ToString();
            var avgTimeInSystem = (((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).SIMULATIONTimeInTheSystemStatistics.GetAverage() / 60).ToString();
            var avgCusAtEndOfDay = ((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).SIMULATIONNumberOfCustomersAtTHeEndOfDay.GetAverage().ToString();
            var freeTechs = ((TechniciansAgent)FindAgent(SimId.TechniciansAgent)).TechniciansService.AvergaeFreeWorkersGlobal().ToString();
            var freeMechs = ((MechanicsAgent)FindAgent(SimId.MechanicsAgent)).MechanicsService.AvergaeFreeWorkersGlobal().ToString();
            var avgCustomersInFirstQueue = ((TechniciansAgent)FindAgent(SimId.TechniciansAgent)).SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.GetAverage().ToString();
            var avgCustomersInSystemNumber = ((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).SIMULATIONAverageNumberOfCustomersInSystem.GetAverage().ToString();
            var allCustomersAtDay = ((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).SIMULATIONNumberOfCustomersAtOneDay.GetAverage().ToString();
            //interval spolahlivosti
            (double min, double max) interval = ((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).SIMULATIONTimeInTheSystemStatistics.GetConfidenceInterval(0.9);
            var confIntervalTimeInSystem = $"<{interval.min / 60} ; {interval.max / 60}>";
            interval = ((SurroundingAgent)FindAgent(SimId.SurroundingAgent)).SIMULATIONAverageNumberOfCustomersInSystem.GetConfidenceInterval(0.95);
            var confIntervaNumberOfCustomersInSystem = $"<{interval.min} ; {interval.max}>";
            int salary = certificatedMechsNum * 2000;
            salary += nonCertificatedMechsnum * 1500;
            salary += techsNum * 1100;

            list.Add($"Počet replikácií;{replications}");
            list.Add($"Počet technikov;{techsNum}");
            list.Add($"Počet certifikovaných mechanikov;{certificatedMechsNum}");
            list.Add($"Počet necertifikovaných mechanikov;{nonCertificatedMechsnum}");
            list.Add($"Priemerná doba čakania v rade na prijatie [min.];{avgWaitingTimet}");
            list.Add($"Priemerný počet ľudí v rade na prijatie;{avgCustomersInFirstQueue}");
            list.Add($"Priemerný čas strávený v systéme [min.];{avgTimeInSystem}");
            list.Add($"90% interval spoľahlivosti [min.];{confIntervalTimeInSystem}");
            list.Add($"Priemerný počet zákazníkov v systéme;{avgCustomersInSystemNumber}");
            list.Add($"95% interval spoľahlivosti;{confIntervaNumberOfCustomersInSystem}");
            list.Add($"Priemerný počet zákazníkov v prevádzke na konci dňa;{avgCusAtEndOfDay}");
            list.Add($"Priemerný počet voľných technikov;{freeTechs}");
            list.Add($"Priemerný počet voľných mechanikov;{freeMechs}");
            list.Add($"Priemerný počet zákazníkov za deň;{allCustomersAtDay}");
            list.Add($"Percentuálny nárast počtu zákazníkov;{customersIncrease}");
            list.Add($"Mzdové náklady;{salary}€");
            try
            {
                System.IO.File.WriteAllLines(path + "\\" + "RESULT.csv", list, System.Text.Encoding.Unicode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

