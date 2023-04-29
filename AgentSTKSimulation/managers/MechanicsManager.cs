using OSPABA;
using simulation;
using agents;
using continualAssistants;
using DISS_S2.SimulationCore.Statistics;
using AgentSim.StkStation.Models;
using System.Collections.Generic;
using System;

namespace managers
{
	//meta! id="5"
	public class MechanicsManager : Manager
	{
        public Queue<StkMessage> WaitingForParkingPlace { get; set; }
        public WeightedAritmeticAverage AvergaeNumberOfFreeMechanics { get; set; }
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeMechanics { get; set; }
		public GarageParking ParkingInGarage { get; set; }
		public Queue<Mechanic> FreeMechanics { get; set; }
		public MechanicsManager(int id, Simulation mySim, Agent myAgent) :
			base(id, mySim, myAgent)
		{
			AvergaeNumberOfFreeMechanics = new WeightedAritmeticAverage();
			SIMULATIONAvergaeNumberOfFreeMechanics = new StandartStaticstic();
			ParkingInGarage = new GarageParking();
			FreeMechanics = new Queue<Mechanic>();
			WaitingForParkingPlace = new Queue<StkMessage>();
			Init();
		}

		override public void PrepareReplication()
		{
			base.PrepareReplication();
			ParkingInGarage.ResetGarage();
            // Setup component for the next replication
            ResetReplicationStats();
            ClearAllQueues();
            InitializeMechanics(MyAgent.MechanicsNumber);
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
		private void InitializeMechanics(int numberOfMechanic)
		{
			FreeMechanics.Clear();
			Mechanic mech;
			for (int i = 0; i < numberOfMechanic; i++)
			{
				mech = new Mechanic(i);
				FreeMechanics.Enqueue(mech);
			}
			AvergaeNumberOfFreeMechanics.Add(numberOfMechanic, MySim.CurrentTime);
		}
        /// <summary>
        /// Resetovanie replikacnych statistik
        /// </summary>
        private void ResetReplicationStats()
        {
            AvergaeNumberOfFreeMechanics.Reset();
        }
        /// <summary>
        /// Vycistenie struktur pouzitych v simulacii
        /// </summary>
        private void ClearAllQueues()
        {
            FreeMechanics.Clear();
			WaitingForParkingPlace.Clear();
        }

		private void FindWorkForMechanic(Worker worker)
		{
			if (ParkingInGarage.IsWaitingCar())
			{
				var mess = ParkingInGarage.GetCustomersCarFromParking();
                ((StkMessage)mess).Customer.Situation = CustomerSituation.SERVED_BY_MECHANIC;
                mess.Worker = worker;
                mess.Addressee = MyAgent.FindAssistant(SimId.CarInspectionProcess);
                StartContinualAssistant(mess);
            }
			else
			{
				SetWorkerFree(worker);
			}
		}
        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker"></param>
        public void SetWorkerFree(Worker worker)
        {
            worker.IsWorking = false;
            worker.Work = AgentSTKSimulation.StkStation.Models.Work.UNKNOWN;
            if (worker.GetType() == typeof(Mechanic))
            {
                FreeMechanics.Enqueue((Mechanic)worker);
                AvergaeNumberOfFreeMechanics.Add(1, MySim.CurrentTime);
            }
            else
            {
                throw new ArgumentException("Nemozem uvolnit technika v agentovi mechanikov!!");
            }
        }

        //meta! sender="STKAgent", id="22", type="Request"
        public void ProcessCarInspection(MessageForm message)
		{
			// zapni process na kontrolu
			ParkingInGarage.ParkCustomersCarInGrage((StkMessage)message);
            HandleParkingReservation();
			if (FreeMechanics.Count > 0)
            {
                var worker = FreeMechanics.Dequeue();
                AvergaeNumberOfFreeMechanics.Add(-1, MySim.CurrentTime);
				FindWorkForMechanic(worker);
            }
		}

		private void HandleParkingReservation()
		{
            if (ParkingInGarage.IsFreeSpot() && WaitingForParkingPlace.Count > 0)
            {
                var mess = WaitingForParkingPlace.Dequeue();
                ParkingInGarage.ReservePlaceForCar();
                mess.HasParkingReserved = true;
                mess.Addressee = MySim.FindAgent(SimId.STKAgent);
                Response(mess);
            }
        }

		//meta! sender="STKAgent", id="19", type="Request"
		public void ProcessReserveParking(MessageForm message)
		{
			// zareservuj parkovisko , ak nie je tak cakaj kym sa neuvolni .. tzn dat do radu
			WaitingForParkingPlace.Enqueue((StkMessage)message);
            ((StkMessage)message).Customer.Situation = CustomerSituation.WAITING_FOR_ACCEPTANCE;
            HandleParkingReservation();
		}

		//meta! sender="MechanicsLunchBreakScheduler", id="33", type="Finish"
		public void ProcessFinishMechanicsLunchBreakScheduler(MessageForm message)
		{
			// uvolni pracovnika, daj mu robotku
		}

		//meta! sender="CarInspectionProcess", id="31", type="Finish"
		public void ProcessFinishCarInspectionProcess(MessageForm message)
		{
            // posli zakaznika hore na platenie
            var worker = ((StkMessage)message).Worker;
            ((StkMessage)message).Worker = null;

            FindWorkForMechanic(worker);

            message.Addressee = MySim.FindAgent(SimId.STKAgent);
            message.Code = Mc.CarInspection;
            Response(message);
        }

		//meta! sender="STKAgent", id="48", type="Notice"
		public void ProcessLunchBreakStart(MessageForm message)
		{
			// nastav bool na obedy a posli volnych na obed
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
				case SimId.MechanicsLunchBreakScheduler:
					ProcessFinishMechanicsLunchBreakScheduler(message);
				break;

				case SimId.CarInspectionProcess:
					ProcessFinishCarInspectionProcess(message);
				break;
				}
			break;

			case Mc.LunchBreakStart:
				ProcessLunchBreakStart(message);
			break;

			case Mc.ReserveParking:
				ProcessReserveParking(message);
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
