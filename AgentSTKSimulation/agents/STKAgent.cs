using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="3"
	public class STKAgent : Agent
	{
		public STKAgent(int id, Simulation mySim, Agent parent) :
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
			new STKManager(SimId.STKManager, MySim, this);
			new StartLunchBreakScheduler(SimId.StartLunchBreakScheduler, MySim, this);
			AddOwnMessage(Mc.CustomerService);
			AddOwnMessage(Mc.CarInspection);
			AddOwnMessage(Mc.CustomerPayment);
			AddOwnMessage(Mc.ReserveParking);
			AddOwnMessage(Mc.Initialize);
			AddOwnMessage(Mc.CustomerAcceptance);
		}
		//meta! tag="end"
	}
}
