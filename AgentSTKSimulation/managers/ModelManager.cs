using OSPABA;
using simulation;
using agents;
using continualAssistants;
namespace managers
{
	//meta! id="1"
	public class ModelManager : Manager
	{
		public ModelManager(int id, Simulation mySim, Agent myAgent) :
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

		//meta! sender="STKAgent", id="16", type="Response"
		public void ProcessCustomerService(MessageForm message)
		{
            message.Code = Mc.CustomerLeft;
            message.Addressee = MySim.FindAgent(SimId.SurroundingAgent);
            Notice(message);
        }

		//meta! sender="SurroundingAgent", id="14", type="Notice"
		public void ProcessCustomerCame(MessageForm message)
		{
            message.Code = Mc.CustomerService;
            message.Addressee = MySim.FindAgent(SimId.STKAgent);
			Request(message);
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
			case Mc.CustomerService:
				ProcessCustomerService(message);
			break;

			case Mc.CustomerCame:
				ProcessCustomerCame(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new ModelAgent MyAgent
		{
			get
			{
				return (ModelAgent)base.MyAgent;
			}
		}
	}
}