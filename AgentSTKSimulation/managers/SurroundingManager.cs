using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="2"
	public class SurroundingManager : Manager
	{
		public SurroundingManager(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="ModelAgent", id="15", type="Notice"
		public void ProcessCustomerLeft(MessageForm message)
		{
		}

		//meta! sender="CustomerCameScheduler", id="13", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
		}

		//meta! sender="ModelAgent", id="39", type="Notice"
		public void ProcessInitialize(MessageForm message)
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
			case Mc.CustomerLeft:
				ProcessCustomerLeft(message);
			break;

			case Mc.Initialize:
				ProcessInitialize(message);
			break;

			case Mc.Finish:
				ProcessFinish(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new SurroundingAgent MyAgent
		{
			get
			{
				return (SurroundingAgent)base.MyAgent;
			}
		}
	}
}
