using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="5"
	public class MechanicsAgent : Agent
	{
		public MechanicsAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
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
	}
}
