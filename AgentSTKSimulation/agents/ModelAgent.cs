using OSPABA;
using simulation;
using managers;
using continualAssistants;
namespace agents
{
	/// <summary>
	/// Agent modelu
	/// </summary>
	//meta! id="1"
	public class ModelAgent : Agent
	{
		public ModelAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
		{
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			var mess = new StkMessage(MySim, null, null)
			{
				// posleme spravu agenotvi okolia ze moze zacat simulaciu
				Addressee = MySim.FindAgent(SimId.SurroundingAgent),
				Code = Mc.Initialize
            };
            MyManager.Notice(mess);

			var messForStkAgent = mess.CreateCopy();
			messForStkAgent.Addressee = MySim.FindAgent(SimId.STKAgent);
			MyManager.Notice(messForStkAgent);
            // Setup component for the next replication
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		private void Init()
		{
			new ModelManager(SimId.ModelManager, MySim, this);
			AddOwnMessage(Mc.CustomerService);
			AddOwnMessage(Mc.CustomerCame);
		}
		//meta! tag="end"
	}
}