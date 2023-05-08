using OSPABA;
using simulation;
using agents;
using AgentSim.StkStation;

namespace continualAssistants
{
	/// <summary>
	/// Process pre simulovanie platenia
	/// </summary>
	//meta! id="27"
	public class CustomerPaymentProcess : Process
	{
		public CustomerPaymentProcess(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="TechniciansAgent", id="28", type="Start"
		public void ProcessStart(MessageForm message)
        {
            message.Code = Mc.Finish;
            Hold(MyAgent.PaymentTimeGenerator.GetPaymentTime(), message);
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
            {
                case Mc.Finish:
                    AssistantFinished(message); break;
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