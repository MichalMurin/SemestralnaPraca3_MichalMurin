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
using AgentSTKSimulation.StkStation.Services;

namespace agents
{
	//meta! id="4"
	public class TechniciansAgent : Agent, IStatsDelegate
    {
        public WorkerAgentService TechniciansService { get; set; }
        public Queue<StkMessage> CustomerQueueForAcceptance { get; set; }
        public Queue<StkMessage> CustomerQueueForPayment { get; set; }
        public StandartStaticstic TimeWaitingForAcceptanceStatistics { get; set; }
        public WeightedAritmeticAverage AverageNumberOfCustomersInQueueForAcceptance { get; set; }
        public StandartStaticstic SIMULATIONTimeWaitingForAcceptanceStatistics { get; set; }
        public StandartStaticstic SIMULATIONAverageNumberOfCustomersInQueueForAcceptance { get; set; }
        public StkGenerator.AcceptanceCarGenerator AcceptanceCarGenerator { get; set; }
        public StkGenerator.PaymentTimeGenerator PaymentTimeGenerator { get; set; }
        public bool IgnoreReaminingCustomers { get; set; }
        public TechniciansAgent(int id, Simulation mySim, Agent parent) :
			base(id, mySim, parent)
        {
            TechniciansService = new WorkerAgentService(this);
            CustomerQueueForAcceptance = new Queue<StkMessage>();
            CustomerQueueForPayment = new Queue<StkMessage>();
            TimeWaitingForAcceptanceStatistics = new StandartStaticstic();
            AverageNumberOfCustomersInQueueForAcceptance = new WeightedAritmeticAverage();
            SIMULATIONTimeWaitingForAcceptanceStatistics = new StandartStaticstic();
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance = new StandartStaticstic();
            IgnoreReaminingCustomers = false;
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
			new CustomerPaymentProcess(SimId.CustomerPaymentProcess, MySim, this);
			new TechniciansLunchBreakProcess(SimId.TechniciansLunchBreakProcess, MySim, this);
			AddOwnMessage(Mc.CustomerPayment);
			AddOwnMessage(Mc.CustomerServiceNotice);
			AddOwnMessage(Mc.CustomerAcceptance);
			AddOwnMessage(Mc.LunchBreakStart);
		}
		//meta! tag="end"

        public void AddGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.AddValue(AverageNumberOfCustomersInQueueForAcceptance.GetAverage());
            TechniciansService.SIMULATIONAvergaeNumberOfFreeWorkers.AddValue(TechniciansService.AvergaeNumberOfFreeWorkers.GetAverage());
            SIMULATIONTimeWaitingForAcceptanceStatistics.AddValue(TimeWaitingForAcceptanceStatistics.GetAverage());
        }

        public void ResetGlobalStats()
        {
            SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.Reset();
            TechniciansService.SIMULATIONAvergaeNumberOfFreeWorkers.Reset();
            SIMULATIONTimeWaitingForAcceptanceStatistics.Reset();
        }
        public void CreateGenerator(StkGenerator generators)
        {
            AcceptanceCarGenerator = generators.CreateAcceptanceTimeGen();
            PaymentTimeGenerator = generators.CreatePaymentTimeGen();
        }

        public void FinishStatsAfterReplication()
        {
            if (!IgnoreReaminingCustomers)
            {
                foreach (var mess in CustomerQueueForAcceptance)
                {
                    TimeWaitingForAcceptanceStatistics.AddValue(STKAgentSimulation.MAX_TIME - mess.Customer.StartWaitingTime);
                }
            }            
            AverageNumberOfCustomersInQueueForAcceptance.Add(0, STKAgentSimulation.MAX_TIME);
            TechniciansService.AvergaeNumberOfFreeWorkers.Add(0, STKAgentSimulation.MAX_TIME);
        }
    }
}