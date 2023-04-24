using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="4"
	public class TechniciansManager : Manager
	{
		public TechniciansManager(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="STKAgent", id="23", type="Request"
		public void ProcessCustomerPayment(MessageForm message)
		{
		}

		//meta! sender="CustomerPaymentProcess", id="28", type="Finish"
		public void ProcessFinishCustomerPaymentProcess(MessageForm message)
		{
		}

		//meta! sender="TechniciansLunchBreakScheduler", id="35", type="Finish"
		public void ProcessFinishTechniciansLunchBreakScheduler(MessageForm message)
		{
		}

		//meta! sender="CustomerAcceptanceProcess", id="26", type="Finish"
		public void ProcessFinishCustomerAcceptanceProcess(MessageForm message)
		{
		}

		//meta! sender="STKAgent", id="20", type="Notice"
		public void ProcessCustomerServiceNotice(MessageForm message)
		{
		}

		//meta! sender="STKAgent", id="47", type="Notice"
		public void ProcessLunchBreakStart(MessageForm message)
		{
		}

		//meta! sender="STKAgent", id="21", type="Request"
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
				switch (message.Sender.Id)
				{
				case SimId.CustomerPaymentProcess:
					ProcessFinishCustomerPaymentProcess(message);
				break;

				case SimId.TechniciansLunchBreakScheduler:
					ProcessFinishTechniciansLunchBreakScheduler(message);
				break;

				case SimId.CustomerAcceptanceProcess:
					ProcessFinishCustomerAcceptanceProcess(message);
				break;
				}
			break;

			case Mc.LunchBreakStart:
				ProcessLunchBreakStart(message);
			break;

			case Mc.CustomerPayment:
				ProcessCustomerPayment(message);
			break;

			case Mc.CustomerAcceptance:
				ProcessCustomerAcceptance(message);
			break;

			case Mc.CustomerServiceNotice:
				ProcessCustomerServiceNotice(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new TechniciansAgent MyAgent
		{
			get
			{
				return (TechniciansAgent)base.MyAgent;
			}
		}
	}
}
