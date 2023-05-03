using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
	//meta! id="42"
	public class StartLunchBreakScheduler : Scheduler
	{
		public StartLunchBreakScheduler(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="STKAgent", id="43", type="Start"
		public void ProcessStart(MessageForm message)
		{
            message.Code = Mc.Finish;
            Hold((11-9) * 3600, message);
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
		public new STKAgent MyAgent
		{
			get
			{
				return (STKAgent)base.MyAgent;
			}
		}
	}
}