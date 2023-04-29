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
        public StandartStaticstic SIMULATIONTimeInTheSystemStatistics { get; set; }
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInSystem { get; set; }
        public ObservableCollection<Customer> AllCustomers { get; set; }
		public int CurrentNumberOfCustomersInTheSystem { get; set; }
		public WeightedAritmeticAverage AverageNumberOfCustomersInSystem { get; set; }
        public StandartStaticstic TimeInTheSystemStatistics { get; set; }
        public StkGenerator.CarTypeGenerator CarTypeGenerator { get; set; }
        public int NumberOfCustomersInTheSystemAtAll { get; set; }
        // cas v sekundach
        public const int CUSTOMER_STOP_COMMING_TIME = ((15 - 9) * 60 + 45) * 60;
        public SurroundingManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{

            TimeInTheSystemStatistics = new StandartStaticstic();
            AverageNumberOfCustomersInSystem = new WeightedAritmeticAverage();

            // Ststistiky pre viac replikacii
            SIMULATIONTimeInTheSystemStatistics = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInSystem = new StandartStaticstic();

			AllCustomers = new ObservableCollection<Customer>();
			CurrentNumberOfCustomersInTheSystem = 0;
			CarTypeGenerator = ((STKAgentSimulation)mySim).StkGenerators.CreateCarTypeGenerator();
			NumberOfCustomersInTheSystemAtAll = 0;
            Init();
        }

        /// <summary>
        /// Resetovanie replikacnych statistik
        /// </summary>
        private void ResetReplicationStats()
        {
            TimeInTheSystemStatistics.Reset();
            AverageNumberOfCustomersInSystem.Reset();
        }
        /// <summary>
        /// Resetovanie simulacnych statistik
        /// </summary>
        private void ResetSimulationStats()
        {
            SIMULATIONTimeInTheSystemStatistics.Reset();
            SIMULATIONAverageNumberOfCustomersInSystem.Reset();
        }

        override public void PrepareReplication()
		{
			base.PrepareReplication();
			ResetReplicationStats();
			CurrentNumberOfCustomersInTheSystem = 0;
            NumberOfCustomersInTheSystemAtAll = 0;
            AllCustomers.Clear();
			// Setup component for the next replication

			if (PetriNet != null)
			{
				PetriNet.Clear();
			}
		}

		//meta! sender="ModelAgent", id="15", type="Notice"
		public void ProcessCustomerLeft(MessageForm message)
		{
			CurrentNumberOfCustomersInTheSystem--;
			var cus = ((StkMessage)message).Customer;
            cus.Situation = CustomerSituation.LEFT;
            TimeInTheSystemStatistics.AddValue(MySim.CurrentTime - cus.StartWaitingTime);
            AverageNumberOfCustomersInSystem.Add(-1, MySim.CurrentTime);
            AllCustomers.Remove(cus);
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
            NumberOfCustomersInTheSystemAtAll++;
			CurrentNumberOfCustomersInTheSystem++;
            Customer customer = new Customer(startTime, CarTypeGenerator.GetCarType(), NumberOfCustomersInTheSystemAtAll);
			AllCustomers.Add(customer);
			AverageNumberOfCustomersInSystem.Add(1, MySim.CurrentTime);
            return customer;
        }
    }
}
