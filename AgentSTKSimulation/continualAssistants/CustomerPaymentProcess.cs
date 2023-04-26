using OSPABA;
using simulation;
using agents;
using AgentSim.StkStation;

namespace continualAssistants
{
	//meta! id="27"
	public class CustomerPaymentProcess : Process
	{
		StkGenerator.PaymentTimeGenerator PaymentTimeGenerator { get; set; }
		public CustomerPaymentProcess(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
			PaymentTimeGenerator = ((STKAgentSimulation)mySim).StkGenerators.CreatePaymentTimeGen();
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="TechniciansAgent", id="28", type="Start"
		public void ProcessStart(MessageForm message)
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
		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.Start:
				ProcessStart(message);
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
