using OSPABA;
using simulation;
using agents;
using continualAssistants;
using DISS_S2.StkStation;
using System.Collections.Generic;
using AgentSim.StkStation.Models;
using DISS_S2.SimulationCore.Statistics;
using System;
using AgentSTKSimulation.StkStation.Services;

namespace managers
{
    //meta! id="4"
    public class TechniciansManager : Manager
    {
        public TechniciansManager(int id, Simulation mySim, Agent myAgent) :
            base(id, mySim, myAgent)
        {
            Init();
        }

        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            ResetReplicationStats();
            ClearAllQueues();
            MyAgent.TechniciansService.InitializeWorkers(typeof(Technician));
            if (PetriNet != null)
            {
                PetriNet.Clear();
            }
        }
        /// <summary>
        /// Vycistenie struktur pouzitych v simulacii
        /// </summary>
        private void ClearAllQueues()
        {
            MyAgent.CustomerQueueForAcceptance.Clear();
            MyAgent.CustomerQueueForPayment.Clear();
            MyAgent.TechniciansService.ClearQueues();
        }

        private void FindWorkForTechnician()
        {
            var worker = MyAgent.TechniciansService.GetWorker();
            // ak nie je validacia a je cas na obed posielame pracovnikov, ktori nemali obed na obed
            if (!((STKAgentSimulation)MySim).IsValidation && ((STKAgentSimulation)MySim).IsTimeForLunch && !worker.HadLunch)
            {
                MyAgent.TechniciansService.SendWorkerToLunch(worker);
            }
            else if (MyAgent.CustomerQueueForPayment.Count > 0)
            {
                var cus = MyAgent.CustomerQueueForPayment.Dequeue();
                cus.Worker = worker;
                StartPaymentProcess(worker, cus);
            }
            else if (MyAgent.CustomerQueueForAcceptance.Count > 0 && ((StkMessage)MyAgent.CustomerQueueForAcceptance.Peek()).Customer.HasParkingReserved)
            {
                MyAgent.AverageNumberOfCustomersInQueueForAcceptance.Add(-1, MySim.CurrentTime);
                var cus = MyAgent.CustomerQueueForAcceptance.Dequeue();
                cus.Worker = worker;
                MyAgent.TimeWaitingForAcceptanceStatistics.AddValue(MySim.CurrentTime - ((StkMessage)cus).Customer.StartWaitingTime);
                StartAcceptanceProcess(worker, cus);
            }
            else
            {
                MyAgent.TechniciansService.SetWorkerFree(worker);
            }
        }
        //private void SendWorkerToLunch(Worker worker)
        //{
        //    var message = new StkMessage(MySim, null, worker);
        //    worker.IsBusy = true;
        //    message.Addressee = MyAgent.FindAssistant(SimId.TechniciansLunchBreakScheduler);
        //    StartContinualAssistant(message);
        //}

        //meta! sender="STKAgent", id="23", type="Request"
        public void ProcessCustomerPayment(MessageForm message)
        {
            ((StkMessage)message).Customer.Situation = CustomerSituation.WAITING_FOR_PAYMENT;
            MyAgent.CustomerQueueForPayment.Enqueue((StkMessage)message);
            if (MyAgent.TechniciansService.IsFreeWorker())
            {
                FindWorkForTechnician();
            }
        }

        //meta! sender="CustomerPaymentProcess", id="28", type="Finish"
        public void ProcessFinishCustomerPaymentProcess(MessageForm message)
        {

            var worker = ((StkMessage)message).Worker;
            ((StkMessage)message).Worker = null;
            MyAgent.TechniciansService.SetWorkerFree(worker);
            FindWorkForTechnician();

            message.Addressee = MySim.FindAgent(SimId.STKAgent);
            message.Code = Mc.CustomerPayment;
            Response(message);
        }

        private void StartAcceptanceProcess(Worker worker, StkMessage mess)
        {
            worker.CustomerId = mess.Customer.Id;
            worker.Work = AgentSTKSimulation.StkStation.Models.Work.ACCEPTANCE;
            mess.Worker = worker;
            mess.Customer.Situation = CustomerSituation.BEEING_ACCEPTED;
            mess.Addressee = MyAgent.FindAssistant(SimId.CustomerAcceptanceProcess);
            StartContinualAssistant(mess);
        }

        private void StartPaymentProcess(Worker worker, StkMessage mess)
        {
            worker.CustomerId = mess.Customer.Id;
            worker.Work = AgentSTKSimulation.StkStation.Models.Work.PAYMENT;
            mess.Worker = worker;
            mess.Customer.Situation = CustomerSituation.IS_PAYING;
            mess.Addressee = MyAgent.FindAssistant(SimId.CustomerPaymentProcess);
            StartContinualAssistant(mess);
        }

        //meta! sender="TechniciansLunchBreakScheduler", id="35", type="Finish"
        public void ProcessFinishTechniciansLunchBreakScheduler(MessageForm message)
        {
            // uvolni pracovnika, daj mu robotku
            var worker = ((StkMessage)message).Worker;
            worker.HadLunch = true;
            MyAgent.TechniciansService.SetWorkerFree(worker);
            FindWorkForTechnician();
        }

        //meta! sender="CustomerAcceptanceProcess", id="26", type="Finish"
        public void ProcessFinishCustomerAcceptanceProcess(MessageForm message)
        {
            var worker = ((StkMessage)message).Worker;
            ((StkMessage)message).Worker = null;
            MyAgent.TechniciansService.SetWorkerFree(worker);
            FindWorkForTechnician();
            message.Addressee = MySim.FindAgent(SimId.STKAgent);
            message.Code = Mc.CustomerAcceptance;
            Response(message);
        }

        //meta! sender="STKAgent", id="20", type="Notice"
        public void ProcessCustomerServiceNotice(MessageForm message)
        {
            MyAgent.AverageNumberOfCustomersInQueueForAcceptance.Add(1, MySim.CurrentTime);
            MyAgent.CustomerQueueForAcceptance.Enqueue((StkMessage)message);
        }

        //meta! sender="STKAgent", id="47", type="Notice"
        public void ProcessLunchBreakStart(MessageForm message)
        {
            // nastav bool na obedy a posli volnych na obed
            MyAgent.TechniciansService.LunchBreakStart();
        }

        //meta! sender="STKAgent", id="21", type="Request"
        public void ProcessCustomerAcceptance(MessageForm message)
        {
            //((StkMessage)message).HasParkingReserved = true;
            //MyAgent.CustomerQueueForAcceptance.Enqueue((StkMessage)message);
            ((StkMessage)message).Customer.Situation = CustomerSituation.WAITING_FOR_ACCEPTANCE;
            if (MyAgent.TechniciansService.IsFreeWorker())
            {
                FindWorkForTechnician();
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
            MyAgent.TimeWaitingForAcceptanceStatistics.Reset();
            MyAgent.TechniciansService.ResetLocalStats();
            MyAgent.AverageNumberOfCustomersInQueueForAcceptance.Reset();
        }
        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker"></param>
        //public void SetWorkerFree(Worker worker)
        //{
        //    worker.IsBusy = false;
        //    worker.Work = AgentSTKSimulation.StkStation.Models.Work.UNKNOWN;
        //    if (worker.GetType() == typeof(Technician))
        //    {
        //        MyAgent.FreeTechnicians.Enqueue((Technician)worker);
        //        MyAgent.AvergaeNumberOfFreeWorkers.Add(1, MySim.CurrentTime);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Nemozem uvolnit mechanika v agentovi technikov!!");
        //    }
        //}
    }
}
