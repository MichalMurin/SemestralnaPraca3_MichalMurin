using OSPABA;
using simulation;
using agents;
using continualAssistants;
using DISS_S2.StkStation;
using System.Collections.Generic;
using AgentSim.StkStation.Models;
using DISS_S2.SimulationCore.Statistics;
using System;

namespace managers
{
    //meta! id="4"
    public class TechniciansManager : Manager
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
        public TechniciansManager(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
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
            ResetReplicationStats();
            ClearAllQueues();
            InitializeTechnicians(MyAgent.TechniciansNumber);
            if (PetriNet != null)
            {
                PetriNet.Clear();
            }
        }
        /// <summary>
        /// Inicializovanie pracovnikov
        /// </summary>
        /// <param name="numberOfMechanics"></param>
        /// <param name="numberOfTechnicians"></param>
        private void InitializeTechnicians(int numberOfTechnicians)
        {
            FreeTechnicians.Clear();
            Technician tech;
            for (int i = 0; i < numberOfTechnicians; i++)
            {
                tech = new Technician(i);
                FreeTechnicians.Enqueue(tech);
            }
            AvergaeNumberOfFreeTechnicians.Add(numberOfTechnicians, MySim.CurrentTime);
        }
        /// <summary>
        /// Vycistenie struktur pouzitych v simulacii
        /// </summary>
        private void ClearAllQueues()
        {
            CustomerQueueForAcceptance.Clear();
            CustomerQueueForPayment.Clear();
            FreeTechnicians.Clear();
        }

        private void FindWorkForTechnician(Worker worker)
        {
            if (CustomerQueueForPayment.Count > 0)
            {
                var cus = CustomerQueueForPayment.Dequeue();
                cus.Worker = worker;
                StartPaymentProcess(worker, cus);
            }
            else if (CustomerQueueForAcceptance.Count > 0 && ((StkMessage)CustomerQueueForAcceptance.Peek()).HasParkingReserved)
            {
                AverageNumberOfCustomersInQueueForAcceptance.Add(-1, MySim.CurrentTime);
                var cus = CustomerQueueForAcceptance.Dequeue();
                cus.Worker = worker;
                TimeWaitingForAcceptanceStatistics.AddValue(MySim.CurrentTime - ((StkMessage)cus).Customer.StartWaitingTime);
                StartAcceptanceProcess(worker, cus);
            }
            else
            {
                SetWorkerFree(worker);
            }
        }

        //meta! sender="STKAgent", id="23", type="Request"
        public void ProcessCustomerPayment(MessageForm message)
        {
            CustomerQueueForPayment.Enqueue((StkMessage)message);
            if (FreeTechnicians.Count > 0)
            {
                var worker = FreeTechnicians.Dequeue();
                AvergaeNumberOfFreeTechnicians.Add(-1, MySim.CurrentTime);
                FindWorkForTechnician(worker);
            }
        }

        //meta! sender="CustomerPaymentProcess", id="28", type="Finish"
        public void ProcessFinishCustomerPaymentProcess(MessageForm message)
        {

            var worker = ((StkMessage)message).Worker;
            ((StkMessage)message).Worker = null;
            if (worker == null)
            {
                //
            }
            FindWorkForTechnician(worker);

            message.Addressee = MySim.FindAgent(SimId.STKAgent);
            message.Code = Mc.CustomerPayment;
            Response(message);
        }

        private void StartAcceptanceProcess(Worker worker, StkMessage mess)
        {
            mess.Worker = worker;
            mess.Customer.Situation = CustomerSituation.BEEING_ACCEPTED;
            mess.Addressee = MyAgent.FindAssistant(SimId.CustomerAcceptanceProcess);
            StartContinualAssistant(mess);
        }

        private void StartPaymentProcess(Worker worker, StkMessage mess)
        {
            mess.Worker = worker;
            mess.Customer.Situation = CustomerSituation.IS_PAYING;
            mess.Addressee = MyAgent.FindAssistant(SimId.CustomerPaymentProcess);
            StartContinualAssistant(mess);
        }

        //meta! sender="TechniciansLunchBreakScheduler", id="35", type="Finish"
        public void ProcessFinishTechniciansLunchBreakScheduler(MessageForm message)
        {
        }

        //meta! sender="CustomerAcceptanceProcess", id="26", type="Finish"
        public void ProcessFinishCustomerAcceptanceProcess(MessageForm message)
        {
            var worker = ((StkMessage)message).Worker;
            ((StkMessage)message).Worker = null;
            if (worker == null)
            {
                //
            }
            FindWorkForTechnician(worker);
            message.Addressee = MySim.FindAgent(SimId.STKAgent);
            message.Code = Mc.CustomerAcceptance;
            Response(message);
        }

        //meta! sender="STKAgent", id="20", type="Notice"
        public void ProcessCustomerServiceNotice(MessageForm message)
        {
            AverageNumberOfCustomersInQueueForAcceptance.Add(1, MySim.CurrentTime);
            //CustomerQueueForAcceptance.Enqueue((StkMessage)message);
        }

        //meta! sender="STKAgent", id="47", type="Notice"
        public void ProcessLunchBreakStart(MessageForm message)
        {
        }

        //meta! sender="STKAgent", id="21", type="Request"
        public void ProcessCustomerAcceptance(MessageForm message)
        {
            //((StkMessage)message).HasParkingReserved = true;
            CustomerQueueForAcceptance.Enqueue((StkMessage)message);
            ((StkMessage)message).Customer.Situation = CustomerSituation.WAITING_FOR_ACCEPTANCE;
            if (FreeTechnicians.Count > 0)
            {
                var worker = FreeTechnicians.Dequeue();
                AvergaeNumberOfFreeTechnicians.Add(-1, MySim.CurrentTime);
                FindWorkForTechnician(worker);
            }
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
                case Mc.Finish:
                    switch (message.Sender.Id)
                    {
                        case SimId.CustomerPaymentProcess:
                            ProcessFinishCustomerPaymentProcess(message);
                            break;

                        case SimId.TechniciansLunchBreakScheduler:
                            ProcessFinishTechniciansLunchBreakScheduler(message);
                            break;

                        case SimId.CustomerAcceptanceProcess:
                            ProcessFinishCustomerAcceptanceProcess(message);
                            break;
                    }
                    break;

                case Mc.LunchBreakStart:
                    ProcessLunchBreakStart(message);
                    break;

                case Mc.CustomerPayment:
                    ProcessCustomerPayment(message);
                    break;

                case Mc.CustomerAcceptance:
                    ProcessCustomerAcceptance(message);
                    break;

                case Mc.CustomerServiceNotice:
                    ProcessCustomerServiceNotice(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new TechniciansAgent MyAgent
        {
            get
            {
                return (TechniciansAgent)base.MyAgent;
            }
        }

        /// <summary>
        /// Resetovanie replikacnych statistik
        /// </summary>
        private void ResetReplicationStats()
        {
            TimeWaitingForAcceptanceStatistics.Reset();
            AvergaeNumberOfFreeTechnicians.Reset();
            AverageNumberOfCustomersInQueueForAcceptance.Reset();
        }
        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker"></param>
        public void SetWorkerFree(Worker worker)
        {
            worker.IsWorking = false;
            worker.Work = AgentSTKSimulation.StkStation.Models.Work.UNKNOWN;
            if (worker.GetType() == typeof(Technician))
            {
                FreeTechnicians.Enqueue((Technician)worker);
                AvergaeNumberOfFreeTechnicians.Add(1, MySim.CurrentTime);
            }
            else
            {
                throw new ArgumentException("Nemozem uvolnit mechanika v agentovi technikov!!");
            }
        }
    }
}
