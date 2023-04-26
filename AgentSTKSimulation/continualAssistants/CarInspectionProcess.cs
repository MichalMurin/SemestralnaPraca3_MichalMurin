using OSPABA;
using simulation;
using agents;
using AgentSim.StkStation;

namespace continualAssistants
{
	//meta! id="30"
	public class CarInspectionProcess : Process
	{
		StkGenerator.InspectionTimeGenerator InspectionTimeGenerator { get; set; }
		public CarInspectionProcess(int id, Simulation mySim, CommonAgent myAgent) :
			base(id, mySim, myAgent)
		{
            InspectionTimeGenerator = ((STKAgentSimulation)mySim).StkGenerators.CreateInspectionTimeGen();

        }

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			// Setup component for the next replication
		}

		//meta! sender="MechanicsAgent", id="31", type="Start"
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
		public new MechanicsAgent MyAgent
		{
			get
			{
				return (MechanicsAgent)base.MyAgent;
			}
		}
	}
}
