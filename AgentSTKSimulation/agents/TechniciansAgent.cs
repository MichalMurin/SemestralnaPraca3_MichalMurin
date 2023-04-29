using OSPABA;
using simulation;
using managers;
using continualAssistants;
using AgentSim.StkStation.Models;
using DISS_S2.SimulationCore.Statistics;
using System.Collections.Generic;
using AgentSTKSimulation.simulation;
using static AgentSim.StkStation.StkGenerator;
using AgentSim.StkStation;

namespace agents
{
	//meta! id="4"
	public class TechniciansAgent : Agent, IPrepareSimulation
    {
        public Queue<Technician> FreeTechnicians { get; set; }
        public Queue<StkMessage> CustomerQueueForAcceptance { get; set; }
        public Queue<StkMessage> CustomerQueueForPayment { get; set; }
        public StandartStaticstic TimeWaitingForAcceptanceStatistics { get; set; }
        public WeightedAritmeticAverage AverageNumberOfCustomersInQueueForAcceptance { get; set; }
        public WeightedAritmeticAverage AvergaeNumberOfFreeTechnicians { get; set; }
        public StandartStaticstic SIMULATIONTimeWaitingForAcceptanceStatistics { get; set; }
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInQueueForAcceptance { get; set; }
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeTechnicians { get; set; }
        public int TechniciansNumber { get; set; }
        public StkGenerator.AcceptanceCarGenerator AcceptanceCarGenerator { get; set; }
        public StkGenerator.PaymentTimeGenerator PaymentTimeGenerator { get; set; }
        public TechniciansAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
        {
            TechniciansNumber = 5;
            CustomerQueueForAcceptance = new Queue<StkMessage>();
            CustomerQueueForPayment = new Queue<StkMessage>();
            FreeTechnicians = new Queue<Technician>();
            TimeWaitingForAcceptanceStatistics = new StandartStaticstic();
            AvergaeNumberOfFreeTechnicians = new WeightedAritmeticAverage();
            AverageNumberOfCustomersInQueueForAcceptance = new WeightedAritmeticAverage();
            SIMULATIONTimeWaitingForAcceptanceStatistics = new StandartStaticstic();
            SIMULATIONAvergaeNumberOfFreeTechnicians = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance = new StandartStaticstic();
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

        public void AddGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.AddValue(AverageNumberOfCustomersInQueueForAcceptance.GetAverage());
            SIMULATIONAvergaeNumberOfFreeTechnicians.AddValue(AvergaeNumberOfFreeTechnicians.GetAverage());
            SIMULATIONTimeWaitingForAcceptanceStatistics.AddValue(TimeWaitingForAcceptanceStatistics.GetAverage());
        }

        public void ResetGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.Reset();
            SIMULATIONAvergaeNumberOfFreeTechnicians.Reset();
            SIMULATIONTimeWaitingForAcceptanceStatistics.Reset();
        }
        public void CreateGenerator()
        {
            AcceptanceCarGenerator = ((STKAgentSimulation)MySim).StkGenerators.CreateAcceptanceTimeGen();
            PaymentTimeGenerator = ((STKAgentSimulation)MySim).StkGenerators.CreatePaymentTimeGen();
        }
    }
}
