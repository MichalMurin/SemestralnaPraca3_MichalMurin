using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="5"
	public class MechanicsManager : Manager
	{
		public MechanicsManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! sender="STKAgent", id="22", type="Request"
		public void ProcessCarInspection(MessageForm message)
		{
		}

		//meta! sender="STKAgent", id="19", type="Request"
		public void ProcessReserveParking(MessageForm message)
		{
		}

		//meta! sender="MechanicsLunchBreakScheduler", id="33", type="Finish"
		public void ProcessFinishMechanicsLunchBreakScheduler(MessageForm message)
		{
		}

		//meta! sender="CarInspectionProcess", id="31", type="Finish"
		public void ProcessFinishCarInspectionProcess(MessageForm message)
		{
		}

		//meta! sender="STKAgent", id="48", type="Notice"
		public void ProcessLunchBreakStart(MessageForm message)
		{
		}

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.Finish:
				switch (message.Sender.Id)
				{
				case SimId.MechanicsLunchBreakScheduler:
					ProcessFinishMechanicsLunchBreakScheduler(message);
				break;

				case SimId.CarInspectionProcess:
					ProcessFinishCarInspectionProcess(message);
				break;
				}
			break;

			case Mc.LunchBreakStart:
				ProcessLunchBreakStart(message);
			break;

			case Mc.ReserveParking:
				ProcessReserveParking(message);
			break;

			case Mc.CarInspection:
				ProcessCarInspection(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new MechanicsAgent MyAgent
		{
			get
			{
				return (MechanicsAgent)base.MyAgent;
			}
		}
	}
}
