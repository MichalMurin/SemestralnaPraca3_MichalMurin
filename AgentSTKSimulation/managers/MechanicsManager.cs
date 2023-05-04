using OSPABA;
using simulation;
using agents;
using continualAssistants;
using DISS_S2.SimulationCore.Statistics;
using AgentSim.StkStation.Models;
using System.Collections.Generic;
using System;
using AgentSTKSimulation.StkStation.Services;

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
			MyAgent.ParkingInGarage.ResetGarage();
            // Setup component for the next replication
            ResetReplicationStats();
            ClearAllQueues();
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

		private void FindWorkForMechanic()
		{
			var worker = MyAgent.MechanicsService.GetWorker();
			// ak nie je validacia a je cas na obed posielame pracovnikov, ktori nemali obed na obed
			if (!((STKAgentSimulation)MySim).IsValidation && ((STKAgentSimulation)MySim).IsTimeForLunch && !worker.HadLunch)
			{
				MyAgent.MechanicsService.SendWorkerToLunch(worker);
			}
			else if (MyAgent.ParkingInGarage.IsWaitingCar(((Mechanic)worker).Certificated)))
			{
				worker.IsBusy = true;
				var mess = MyAgent.ParkingInGarage.GetCustomersCarFromParking(((Mechanic)worker).Certificated);
				HandleParkingReservation();
                ((StkMessage)mess).Customer.Situation = CustomerSituation.SERVED_BY_MECHANIC;
                worker.CustomerId = ((StkMessage)mess).Customer.Id;
                worker.Work = AgentSTKSimulation.StkStation.Models.Work.SERVICE;
                mess.Worker = worker;
                mess.Addressee = MyAgent.FindAssistant(SimId.CarInspectionProcess);
                StartContinualAssistant(mess);
            }
			else
			{
                MyAgent.MechanicsService.SetWorkerFree(worker);
			}
		}

		//meta! sender="STKAgent", id="22", type="Request"
		public void ProcessCarInspection(MessageForm message)
		{
            // zapni process na kontrolu
            MyAgent.ParkingInGarage.ParkCustomersCarInGrage((StkMessage)message);
            //HandleParkingReservation();
			if (MyAgent.MechanicsService.IsFreeWorker())
            {
				FindWorkForMechanic();
            }
		}

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
			MyAgent.MechanicsService.SetWorkerFree(worker);
            FindWorkForMechanic();

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