using AgentSim.StkStation.Models;
using OSPABA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSTKSimulation.StkStation.Services
{
    public class MechanicAgentService : WorkerAgentService
    {
        public Queue<Worker> FreeNonCertificatedWorkers { get; set; }
        public int NonCertificatedNumber { get; set; }
        public MechanicAgentService(Agent myAgent) : base(myAgent)
        {
            FreeNonCertificatedWorkers = new Queue<Worker>();
            NonCertificatedNumber = 5;
        }


        /// <summary>
        /// Inicializovanie pracovnikov
        /// </summary>
        /// <param name="numberOfMechanics"></param>
        /// <param name="numberOfTechnicians"></param>
        public override void InitializeWorkers(Type type)
        {
            base.InitializeWorkers(type);
            FreeNonCertificatedWorkers.Clear();
            Worker worker;
            for (int i = 0; i < NonCertificatedNumber; i++)
            {
                worker = new Mechanic(i + WorkersNumber, false);

                FreeNonCertificatedWorkers.Enqueue(worker);
                AllWorkers.Add(worker);
            }
            AvergaeNumberOfFreeWorkers.Add(NonCertificatedNumber, _myAgent.MySim.CurrentTime);
        }

        public override void ClearQueues()
        {
            base.ClearQueues();
            FreeNonCertificatedWorkers.Clear();
        }

        public override void LunchBreakStart()
        {
            base.LunchBreakStart();
            int freeWorkers = FreeNonCertificatedWorkers.Count;
            for (int i = 0; i < freeWorkers; i++)
            {
                AvergaeNumberOfFreeWorkers.Add(-1, _myAgent.MySim.CurrentTime);
                SendWorkerToLunch(FreeNonCertificatedWorkers.Dequeue());
            }
        }
        public bool IsFreeNonCertificatedWorker()
        {
            if (FreeNonCertificatedWorkers.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker"></param>
        public override void SetWorkerFree(Worker worker)
        {
            worker.CustomerId = -1;
            worker.IsBusy = false;
            worker.Work = Models.Work.UNKNOWN;
            if (((Mechanic)worker).Certificated)
            {
                FreeWorkers.Enqueue(worker);
            }
            else
            {
                FreeNonCertificatedWorkers.Enqueue(worker);
            }
            AvergaeNumberOfFreeWorkers.Add(1, _myAgent.MySim.CurrentTime);
        }
        public Worker GetWorker(bool certificated = true)
        {
            Worker worker;
            if (certificated && FreeWorkers.Count > 0)
            {
                worker = FreeWorkers.Dequeue();
            }
            else if (!certificated && FreeNonCertificatedWorkers.Count > 0)
            {
                worker = FreeNonCertificatedWorkers.Dequeue();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Nie je mozne vratit pracovnika!");
            }
            worker.IsBusy = true;
            worker.Work = Models.Work.UNKNOWN;
            AvergaeNumberOfFreeWorkers.Add(-1, _myAgent.MySim.CurrentTime);
            return worker;
        }
    }
}
