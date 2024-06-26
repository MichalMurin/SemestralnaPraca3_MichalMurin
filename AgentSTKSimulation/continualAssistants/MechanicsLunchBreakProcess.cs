using OSPABA;
using simulation;
using agents;
namespace continualAssistants
{
	/// <summary>
	/// Planovac obednej prestavky mechanikov
	/// </summary>
	//meta! id="60"
	public class MechanicsLunchBreakProcess : Process
	{
		public MechanicsLunchBreakProcess(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="MechanicsAgent", id="61", type="Start"
		public void ProcessStart(MessageForm message)
        {
            message.Code = Mc.Finish;
            Hold(30 * 60, message);
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
		public new MechanicsAgent MyAgent
		{
			get
			{
				return (MechanicsAgent)base.MyAgent;
			}
		}
	}
}