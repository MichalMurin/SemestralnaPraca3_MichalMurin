using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="3"
	public class STKManager : Manager
	{
		public STKManager(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="ModelAgent", id="16", type="Request"
		public void ProcessCustomerService(MessageForm message)
		{
		}

		//meta! sender="MechanicsAgent", id="22", type="Response"
		public void ProcessCarInspection(MessageForm message)
		{
		}

		//meta! sender="TechniciansAgent", id="23", type="Response"
		public void ProcessCustomerPayment(MessageForm message)
		{
		}

		//meta! sender="MechanicsAgent", id="19", type="Response"
		public void ProcessReserveParking(MessageForm message)
		{
		}

		//meta! sender="StartLunchBreakScheduler", id="43", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
		}

		//meta! sender="ModelAgent", id="40", type="Notice"
		public void ProcessInitialize(MessageForm message)
		{
		}

		//meta! sender="TechniciansAgent", id="21", type="Response"
		public void ProcessCustomerAcceptance(MessageForm message)
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
				ProcessFinish(message);
			break;

			case Mc.CustomerService:
				ProcessCustomerService(message);
			break;

			case Mc.Initialize:
				ProcessInitialize(message);
			break;

			case Mc.CarInspection:
				ProcessCarInspection(message);
			break;

			case Mc.CustomerPayment:
				ProcessCustomerPayment(message);
			break;

			case Mc.ReserveParking:
				ProcessReserveParking(message);
			break;

			case Mc.CustomerAcceptance:
				ProcessCustomerAcceptance(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new STKAgent MyAgent
		{
			get
			{
				return (STKAgent)base.MyAgent;
			}
		}
	}
}
