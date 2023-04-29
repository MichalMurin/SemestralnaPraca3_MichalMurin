using OSPABA;
using simulation;
using agents;
using continualAssistants;
using AgentSim.StkStation;
using DISS_S2.StkStation;
using DISS_S2.SimulationCore.Statistics;
using System.Collections.ObjectModel;
using AgentSim.StkStation.Models;

namespace managers
{
	//meta! id="2"
	public class SurroundingManager : Manager
    {
        // cas v sekundach
        public const int CUSTOMER_STOP_COMMING_TIME = ((15 - 9) * 60 + 45) * 60;
        public SurroundingManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
            Init();
        }

        /// <summary>
        /// Resetovanie replikacnych statistik
        /// </summary>
        private void ResetReplicationStats()
        {
            MyAgent.TimeInTheSystemStatistics.Reset();
            MyAgent.AverageNumberOfCustomersInSystem.Reset();
        }
        /// <summary>
        /// Resetovanie simulacnych statistik
        /// </summary>
        private void ResetSimulationStats()
        {
            MyAgent.SIMULATIONTimeInTheSystemStatistics.Reset();
            MyAgent.SIMULATIONAverageNumberOfCustomersInSystem.Reset();
        }

        override public void PrepareReplication()
		{
			base.PrepareReplication();
			ResetReplicationStats();
            MyAgent.CurrentNumberOfCustomersInTheSystem = 0;
            MyAgent.NumberOfCustomersInTheSystemAtAll = 0;
            MyAgent.AllCustomers.Clear();
			// Setup component for the next replication

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! sender="ModelAgent", id="15", type="Notice"
		public void ProcessCustomerLeft(MessageForm message)
		{
            MyAgent.CurrentNumberOfCustomersInTheSystem--;
			var cus = ((StkMessage)message).Customer;
            cus.Situation = CustomerSituation.LEFT;
            MyAgent.TimeInTheSystemStatistics.AddValue(MySim.CurrentTime - cus.StartWaitingTime);
            MyAgent.AverageNumberOfCustomersInSystem.Add(-1, MySim.CurrentTime);
            MyAgent.AllCustomers.Remove(cus);
        }

		//meta! sender="CustomerCameScheduler", id="13", type="Finish"
		public void ProcessFinish(MessageForm message)
		{
			// proces skoncil, vytvorime noveho zakaznika
			if (CUSTOMER_STOP_COMMING_TIME > MySim.CurrentTime)
			{
                ((StkMessage)message).Customer = CreateCustomer(MySim.CurrentTime);
                message.Addressee = MySim.FindAgent(SimId.ModelAgent);
                message.Code = Mc.CustomerCame;
                Notice(message);
                // posielame dalsiu message asistentovi
                var messageForAssistnent = new StkMessage(MySim, null, null);
                messageForAssistnent.Addressee = MyAgent.FindAssistant(SimId.CustomerCameScheduler);
                StartContinualAssistant(messageForAssistnent);
            }			
        }

		//meta! sender="ModelAgent", id="39", type="Notice"
		public void ProcessInitialize(MessageForm message)
		{
			// urobit prichod zakaznika v case 0?
			((StkMessage)message).Customer = CreateCustomer(0);
            message.Addressee = MySim.FindAgent(SimId.ModelAgent);
            message.Code = Mc.CustomerCame;
            Notice(message);
			////
			var messageForAssistnent = new StkMessage(MySim, null, null);
			messageForAssistnent.Code = Mc.Start;
            messageForAssistnent.Addressee = MyAgent.FindAssistant(SimId.CustomerCameScheduler);
            StartContinualAssistant(messageForAssistnent);
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
			case Mc.CustomerLeft:
				ProcessCustomerLeft(message);
			break;

			case Mc.Initialize:
				ProcessInitialize(message);
			break;

			case Mc.Finish:
				ProcessFinish(message);
			break;

			default:
				ProcessDefault(message);
			break;
			}
		}
		//meta! tag="end"
		public new SurroundingAgent MyAgent
		{
			get
			{
				return (SurroundingAgent)base.MyAgent;
			}
		}


        public Customer CreateCustomer(double startTime)
        {
            MyAgent.NumberOfCustomersInTheSystemAtAll++;
            MyAgent.CurrentNumberOfCustomersInTheSystem++;
            Customer customer = new Customer(startTime, MyAgent.CarTypeGenerator.GetCarType(), MyAgent.NumberOfCustomersInTheSystemAtAll);
            MyAgent.AllCustomers.Add(customer);
            MyAgent.AverageNumberOfCustomersInSystem.Add(1, MySim.CurrentTime);
            return customer;
        }
    }
}
