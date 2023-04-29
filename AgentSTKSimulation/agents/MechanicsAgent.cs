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

namespace agents
{
	//meta! id="5"
	public class MechanicsAgent : Agent, IStatsDelegate
    {
        public WeightedAritmeticAverage AvergaeNumberOfFreeMechanics { get; set; }
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeMechanics { get; set; }
        public GarageParking ParkingInGarage { get; set; }
        public Queue<Mechanic> FreeMechanics { get; set; }
        public int MechanicsNumber { get; set; }
        public StkGenerator.InspectionTimeGenerator InspectionTimeGenerator { get; set; }
        public MechanicsAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
        {
            MechanicsNumber = 5;
            AvergaeNumberOfFreeMechanics = new WeightedAritmeticAverage();
            SIMULATIONAvergaeNumberOfFreeMechanics = new StandartStaticstic();
            ParkingInGarage = new GarageParking();
            FreeMechanics = new Queue<Mechanic>();
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
			new MechanicsLunchBreakScheduler(SimId.MechanicsLunchBreakScheduler, MySim, this);
			AddOwnMessage(Mc.CarInspection);
			AddOwnMessage(Mc.ReserveParking);
			AddOwnMessage(Mc.LunchBreakStart);
		}
		//meta! tag="end"

		public void AddGlobalStats()
		{
			SIMULATIONAvergaeNumberOfFreeMechanics.AddValue(AvergaeNumberOfFreeMechanics.GetAverage());
		}

        public void ResetGlobalStats()
        {
			SIMULATIONAvergaeNumberOfFreeMechanics.Reset();
        }
        public void CreateGenerator()
        {
            InspectionTimeGenerator = ((STKAgentSimulation)MySim).StkGenerators.CreateInspectionTimeGen();
        }

        public void FinishStatsAfterReplication()
        {
            AvergaeNumberOfFreeMechanics.Add(0, STKAgentSimulation.MAX_TIME);
        }
    }
}
