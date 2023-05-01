using agents;
using AgentSim.StkStation.Models;
using DISS_S2.SimulationCore.Statistics;
using OSPABA;
using simulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSTKSimulation.StkStation.Services
{
    public class WorkerAgentService
    {
        public Queue<Worker> FreeWorkers { get; set; }
        public ObservableCollection<Worker> AllWorkers { get; set; }
        public int WorkersNumber { get; set; }
        private Agent _myAgent;
        public WeightedAritmeticAverage AvergaeNumberOfFreeWorkers { get; set; }
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeWorkers { get; set; }
        public WorkerAgentService(Agent myAgent)
        {
            WorkersNumber = 5;
            _myAgent = myAgent;
            FreeWorkers = new Queue<Worker>();
            AllWorkers = new ObservableCollection<Worker>();
            AvergaeNumberOfFreeWorkers = new WeightedAritmeticAverage();
            SIMULATIONAvergaeNumberOfFreeWorkers = new StandartStaticstic();
        }

        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker"></param>
        public void SetWorkerFree(Worker worker)
        {
            worker.CustomerId = -1;
            worker.IsBusy = false;
            worker.Work = Models.Work.UNKNOWN;
            FreeWorkers.Enqueue(worker);
            AvergaeNumberOfFreeWorkers.Add(1, _myAgent.MySim.CurrentTime);
        }

        public void SendWorkerToLunch(Worker worker)
        {
            worker.Work = Models.Work.LUNCH;
            int id = 0;
            if (worker.GetType() == typeof(Mechanic))
            {
                id = SimId.MechanicsLunchBreakScheduler;
            }
            if (worker.GetType() == typeof(Technician))
            {
                id = SimId.TechniciansLunchBreakScheduler; 
            }
            var message = new StkMessage(_myAgent.MySim, null, worker);
            worker.IsBusy = true;
            message.Addressee = _myAgent.FindAssistant(id);
            _myAgent.MyManager.StartContinualAssistant(message);
        }

        /// <summary>
        /// Inicializovanie pracovnikov
        /// </summary>
        /// <param name="numberOfMechanics"></param>
        /// <param name="numberOfTechnicians"></param>
        public void InitializeWorkers(Type type)
        {
            FreeWorkers.Clear();
            Worker worker;
            for (int i = 0; i < WorkersNumber; i++)
            {
                if (type == typeof(Mechanic))
                {
                    worker = new Mechanic(i);
                }
                else
                {
                    worker = new Technician(i);
                }

                FreeWorkers.Enqueue(worker);
                AllWorkers.Add(worker);
            }
            AvergaeNumberOfFreeWorkers.Add(WorkersNumber, _myAgent.MySim.CurrentTime);
        }

        public void ClearQueues()
        {
            FreeWorkers.Clear();
            AllWorkers.Clear();
        }

        public bool IsFreeWorker()
        {
            if (FreeWorkers.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Worker GetWorker()
        {
            AvergaeNumberOfFreeWorkers.Add(-1, _myAgent.MySim.CurrentTime);
            var worker = FreeWorkers.Dequeue();
            worker.IsBusy = true;
            worker.Work = Models.Work.UNKNOWN;
            return worker;
        }

        public void LunchBreakStart()
        {
            int freeWorkers = FreeWorkers.Count;
            for (int i = 0; i < freeWorkers; i++)
            {
                AvergaeNumberOfFreeWorkers.Add(-1, _myAgent.MySim.CurrentTime);
                SendWorkerToLunch(FreeWorkers.Dequeue());
            }
        }
        public void ResetLocalStats()
        {
            AvergaeNumberOfFreeWorkers.Reset();
        }

        public double AvergaeFreeWorkers()
        {
            return AvergaeNumberOfFreeWorkers.GetAverage();
        }
        public double AvergaeFreeWorkersGlobal()
        {
            return SIMULATIONAvergaeNumberOfFreeWorkers.GetAverage();
        }
    }
}
