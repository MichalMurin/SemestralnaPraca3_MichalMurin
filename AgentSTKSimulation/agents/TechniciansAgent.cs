using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	//meta! id="4"
	public class TechniciansAgent : Agent
    {
        public int TechniciansNumber { get; set; }
        public TechniciansAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
        {
            TechniciansNumber = 5;
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
			new TechniciansManager(SimId.TechniciansManager, MySim, this);
			new CustomerAcceptanceProcess(SimId.CustomerAcceptanceProcess, MySim, this);
			new TechniciansLunchBreakScheduler(SimId.TechniciansLunchBreakScheduler, MySim, this);
			new CustomerPaymentProcess(SimId.CustomerPaymentProcess, MySim, this);
			AddOwnMessage(Mc.CustomerPayment);
			AddOwnMessage(Mc.CustomerServiceNotice);
			AddOwnMessage(Mc.LunchBreakStart);
			AddOwnMessage(Mc.CustomerAcceptance);
		}
		//meta! tag="end"
	}
}
