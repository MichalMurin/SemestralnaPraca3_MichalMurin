using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="2"
	public class SurroundingAgent : Agent
	{
		public SurroundingAgent(int id, Simulation mySim, Agent parent) :
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
			new SurroundingManager(SimId.SurroundingManager, MySim, this);
			new CustomerCameScheduler(SimId.CustomerCameScheduler, MySim, this);
			AddOwnMessage(Mc.CustomerLeft);
			AddOwnMessage(Mc.Initialize);
		}
		//meta! tag="end"
	}
}
