using OSPABA;
using simulation;
using agents;
using continualAssistants;
using DISS_S2.SimulationCore.Statistics;
using AgentSim.StkStation.Models;
using System.Collections.Generic;
using System;
using AgentSTKSimulation.StkStation.Services;
using AgentSTKSimulation.StkStation.Models;

namespace managers
{
	//meta! id="5"
	public class MechanicsManager : Manager
	{
		public MechanicsManager(int id, Simulation mySim, Agent myAgent) :
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
			MyAgent.MechanicsService.IsTimeForLunch = false;
            MyAgent.MechanicsService.InitializeWorkers(typeof(Mechanic));
            if (PetriNet != null)
			{
				PetriNet.Clear();
			}
        }
        /// <summary>
        /// Resetovanie replikacnych statistik
        /// </summary>
        private void ResetReplicationStats()
        {
            MyAgent.MechanicsService.ResetLocalStats();
        }
        /// <summary>
        /// Vycistenie struktur pouzitych v simulacii
        /// </summary>
        private void ClearAllQueues()
        {
            MyAgent.MechanicsService.ClearQueues();
			MyAgent.ParkingInGarage.ResetGarage();
        }
		/// <summary>
		/// Spustenie procesu obsluhy vozidla
		/// </summary>
		/// <param name="mess"></param>
		/// <param name="worker"></param>
        private void StartCarService(StkMessage mess, Worker worker)
        {
            HandleParkingReservation();
            ((StkMessage)mess).Customer.Situation = CustomerSituation.SERVED_BY_MECHANIC;
            worker.CustomerId = ((StkMessage)mess).Customer.Id;
            worker.Work = AgentSTKSimulation.StkStation.Models.Work.SERVICE;
            mess.Worker = worker;
            mess.Addressee = MyAgent.FindAssistant(SimId.CarInspectionProcess);
            StartContinualAssistant(mess);
        }
		/// <summary>
		/// Priradenie prace mechanikovi, ak je niektory volny
		/// </summary>
		private void FindWorkForMechanic()
		{
			if (MyAgent.ParkingInGarage.IsWaitingTruck())
			{
				if (MyAgent.MechanicsService.IsFreeWorker())
				{
                    // caka kamion a je volny certifikovany pracovnik -> davam mu do roboty kamion
                    var worker = MyAgent.MechanicsService.GetWorker(true);
                    var mess = MyAgent.ParkingInGarage.GetTruckFromParking();
                    StartCarService(mess, worker);
                }
				else
                {
                    // je na rade kamion, ale nie je volny certifikovany pracovnik, preparkujem kamion (alebo kamiony) na vedlajsie parkovisko a pokracujem na dalsi if
                    MyAgent.ParkingInGarage.ReparkTrucksFromPeekToTruckQueue();
				}
			}
			if (MyAgent.ParkingInGarage.IsWaitingStandartCarInParking())
			{
                if (MyAgent.MechanicsService.IsFreeNonCertificatedWorker())
                {
                    // caka normalne auto a je volny necertifikovany pracovnik -> davam mu do roboty auto
                    var worker = MyAgent.MechanicsService.GetWorker(false);
                    var mess = MyAgent.ParkingInGarage.GetStandartCarFromParking();
                    StartCarService(mess, worker);
                }
                else if (MyAgent.MechanicsService.IsFreeWorker())
                {
                    // je na rade normalne auto, ale nie je volny necertifikovany pracovnik, preto dam podradnu pracu aj certifikovanemu pracovnikovi
                    var worker = MyAgent.MechanicsService.GetWorker(true);
                    var mess = MyAgent.ParkingInGarage.GetStandartCarFromParking();
                    StartCarService(mess, worker);
                }
            }
		}

		//meta! sender="STKAgent", id="22", type="Request"
		public void ProcessCarInspection(MessageForm message)
		{
            // zapni process na kontrolu
            MyAgent.ParkingInGarage.ParkCustomersCarInGrage((StkMessage)message);
            if (MyAgent.MechanicsService.IsFreeWorker() || MyAgent.MechanicsService.IsFreeNonCertificatedWorker())
            {
                FindWorkForMechanic();
                return;
            }
        }
		/// <summary>
		/// Sprava rezervacie parkoviska v dielni
		/// </summary>
		private void HandleParkingReservation()
		{
            if (MyAgent.ParkingInGarage.IsFreeSpot() && MyAgent.ParkingInGarage.IsWaitingForParkingPlace())
            {
                var mess = MyAgent.ParkingInGarage.GetWaitingForParkingPlace();
                MyAgent.ParkingInGarage.ReservePlaceForCar();
                mess.Customer.HasParkingReserved = true;
                mess.Addressee = MySim.FindAgent(SimId.STKAgent);
                Response(mess);
            }
        }

		//meta! sender="STKAgent", id="19", type="Request"
		public void ProcessReserveParking(MessageForm message)
		{
            // zareservuj parkovisko , ak nie je tak cakaj kym sa neuvolni .. tzn dat do radu
            MyAgent.ParkingInGarage.AddWaitingForParkingPlace((StkMessage)message);
            ((StkMessage)message).Customer.Situation = CustomerSituation.WAITING_FOR_ACCEPTANCE;
            HandleParkingReservation();
		}

		//meta! sender="CarInspectionProcess", id="31", type="Finish"
		public void ProcessFinishCarInspectionProcess(MessageForm message)
		{
            // posli zakaznika hore na platenie
            var worker = ((StkMessage)message).Worker;
            ((StkMessage)message).Worker = null;
            // ak nie je validacia a je cas na obed posielame pracovnikov, ktori nemali obed na obed
            MyAgent.MechanicsService.HandleFinishedWork(worker, FindWorkForMechanic);
            message.Addressee = MySim.FindAgent(SimId.STKAgent);
            message.Code = Mc.CarInspection;
            Response(message);
        }

		//meta! sender="STKAgent", id="48", type="Notice"
		public void ProcessLunchBreakStart(MessageForm message)
		{
			// nastav bool na obedy a posli volnych na obed
			MyAgent.MechanicsService.LunchBreakStart();
        }

		//meta! userInfo="Process messages defined in code", id="0"
		public void ProcessDefault(MessageForm message)
		{
			switch (message.Code)
			{
			}
		}

		//meta! sender="MechanicsLunchBreakProcess", id="61", type="Finish"
		public void ProcessFinishMechanicsLunchBreakProcess(MessageForm message)
        {
			if (MySim.CurrentTime > (13-9) * 3600)
			{
				throw new ArgumentOutOfRangeException("neskor skoncil obed");
			}
            // uvolni pracovnika, daj mu robotku
            var worker = ((StkMessage)message).Worker;
            worker.HadLunch = true;
            MyAgent.MechanicsService.SetWorkerFree(worker);
            FindWorkForMechanic();
        }

		//meta! userInfo="Generated code: do not modify", tag="begin"
		public void Init()
		{
		}

		override public void ProcessMessage(MessageForm message)
		{
			switch (message.Code)
			{
			case Mc.ReserveParking:
				ProcessReserveParking(message);
			break;

			case Mc.Finish:
				switch (message.Sender.Id)
				{
				case SimId.MechanicsLunchBreakProcess:
					ProcessFinishMechanicsLunchBreakProcess(message);
				break;

				case SimId.CarInspectionProcess:
					ProcessFinishCarInspectionProcess(message);
				break;
				}
			break;

			case Mc.LunchBreakStart:
				ProcessLunchBreakStart(message);
			break;

			case Mc.CarInspection:
				ProcessCarInspection(message);
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