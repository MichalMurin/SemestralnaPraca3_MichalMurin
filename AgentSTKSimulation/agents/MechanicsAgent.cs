using OSPABA;
using simulation;
using managers;
using continualAssistants;
using AgentSim.StkStation.Models;
using DISS_S2.SimulationCore.Statistics;
using System.Collections.Generic;
using AgentSTKSimulation.simulation;
using AgentSim.StkStation;
using static AgentSim.StkStation.StkGenerator;
using System.Collections.ObjectModel;
using AgentSTKSimulation.StkStation.Services;

namespace agents
{
	//meta! id="5"
	public class MechanicsAgent : Agent, IStatsDelegate
    {
        public WorkerAgentService MechanicsService { get; set; }
        public GarageParking ParkingInGarage { get; set; }
        public StkGenerator.InspectionTimeGenerator InspectionTimeGenerator { get; set; }
        public MechanicsAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
        {
            ParkingInGarage = new GarageParking();
            MechanicsService = new WorkerAgentService(this);
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
			new MechanicsManager(SimId.MechanicsManager, MySim, this);
			new CarInspectionProcess(SimId.CarInspectionProcess, MySim, this);
			new MechanicsLunchBreakProcess(SimId.MechanicsLunchBreakProcess, MySim, this);
			AddOwnMessage(Mc.CarInspection);
			AddOwnMessage(Mc.ReserveParking);
			AddOwnMessage(Mc.LunchBreakStart);
		}
		//meta! tag="end"

		public void AddGlobalStats()
		{
            MechanicsService.SIMULATIONAvergaeNumberOfFreeWorkers.AddValue(MechanicsService.AvergaeNumberOfFreeWorkers.GetAverage());
		}

        public void ResetGlobalStats()
        {
            MechanicsService.SIMULATIONAvergaeNumberOfFreeWorkers.Reset();
        }
        public void CreateGenerator()
        {
            InspectionTimeGenerator = ((STKAgentSimulation)MySim).StkGenerators.CreateInspectionTimeGen();
        }

        public void FinishStatsAfterReplication()
        {
            MechanicsService.AvergaeNumberOfFreeWorkers.Add(0, STKAgentSimulation.MAX_TIME);
        }
    }
}