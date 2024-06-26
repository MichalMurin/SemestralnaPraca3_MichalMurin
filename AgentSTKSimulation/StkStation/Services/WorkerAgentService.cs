﻿using agents;
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
    /// <summary>
    /// Trieda pre spravu funkcii agenta spravujuceho zamestnancov
    /// </summary>
    public class WorkerAgentService
    {
        /// <summary>
        /// Front volnych zamestnancov
        /// </summary>
        public Queue<Worker> FreeWorkers { get; set; }
        /// <summary>
        /// Zoznam vsetkych zamestnancov
        /// </summary>
        public ObservableCollection<Worker> AllWorkers { get; set; }
        /// <summary>
        /// Pocet zamestnancov
        /// </summary>
        public int WorkersNumber { get; set; }
        /// <summary>
        /// Referencia na agenta
        /// </summary>
        protected Agent _myAgent;
        /// <summary>
        /// Lokalna Statistika volnych zamestnancov
        /// </summary>
        public WeightedAritmeticAverage AvergaeNumberOfFreeWorkers { get; set; }
        /// <summary>
        /// Globalna statistika volnych zamestnancov
        /// </summary>
        public StandartStaticstic SIMULATIONAvergaeNumberOfFreeWorkers { get; set; }
        /// <summary>
        /// Informacia ci uz bolo 11 hodin
        /// </summary>
        public bool IsTimeForLunch { get; set; }
        /// <summary>
        /// konstruktor triedy
        /// </summary>
        /// <param name="myAgent"></param>
        public WorkerAgentService(Agent myAgent)
        {
            WorkersNumber = 5;
            _myAgent = myAgent;
            FreeWorkers = new Queue<Worker>();
            AllWorkers = new ObservableCollection<Worker>();
            AvergaeNumberOfFreeWorkers = new WeightedAritmeticAverage();
            SIMULATIONAvergaeNumberOfFreeWorkers = new StandartStaticstic();
            IsTimeForLunch = false;
        }
        /// <summary>
        /// Metoda na priradenie prace zamestnancovi, ktory uz skoncil cinnost
        /// </summary>
        /// <param name="worker">zamestnanec ktory hlada pracu</param>
        /// <param name="findWorkMethod">metoda, ktora prideli konkretnu cisnnost</param>
        public void HandleFinishedWork(Worker worker, System.Action findWorkMethod)
        {
            // ak nie je validacia a je cas na obed posielame pracovnikov, ktori nemali obed na obed
            if (!((STKAgentSimulation)_myAgent.MySim).IsValidation && IsTimeForLunch && !worker.HadLunch)
            {
                SendWorkerToLunch(worker);
            }
            else
            {
                SetWorkerFree(worker);
                findWorkMethod();
            }
        }

        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker">pracovnik, ktory bude uvolneny</param>
        public virtual void SetWorkerFree(Worker worker)
        {
            worker.CustomerId = -1;
            worker.IsBusy = false;
            worker.Work = Models.Work.UNKNOWN;
            FreeWorkers.Enqueue(worker);
            AvergaeNumberOfFreeWorkers.Add(1, _myAgent.MySim.CurrentTime);
        }
        /// <summary>
        /// Poslanie pracovnika na obed
        /// </summary>
        /// <param name="worker">pracovnik, ktory ide na obed</param>
        public void SendWorkerToLunch(Worker worker)
        {
            worker.CustomerId = -1;
            worker.Work = Models.Work.LUNCH;
            int id = 0;
            if (worker.GetType() == typeof(Mechanic))
            {
                id = SimId.MechanicsLunchBreakProcess;
            }
            if (worker.GetType() == typeof(Technician))
            {
                id = SimId.TechniciansLunchBreakProcess; 
            }
            var message = new StkMessage(_myAgent.MySim, null, worker);
            worker.IsBusy = true;
            message.Addressee = _myAgent.FindAssistant(id);
            _myAgent.MyManager.StartContinualAssistant(message);
        }

        /// <summary>
        /// Inicializovanie pracovnikov
        /// </summary>
        public virtual void InitializeWorkers(Type type)
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
        /// <summary>
        /// Precistenie struktur triedy
        /// </summary>
        public virtual void ClearQueues()
        {
            FreeWorkers.Clear();
            AllWorkers.Clear();
        }
        /// <summary>
        /// Zistenie, ci je volny pracovnik
        /// </summary>
        /// <returns></returns>
        public virtual bool IsFreeWorker()
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
        /// <summary>
        /// Ziskanie volneho pracovnika
        /// </summary>
        /// <returns></returns>
        public virtual Worker GetWorker()
        {
            AvergaeNumberOfFreeWorkers.Add(-1, _myAgent.MySim.CurrentTime);
            var worker = FreeWorkers.Dequeue();
            worker.IsBusy = true;
            worker.Work = Models.Work.UNKNOWN;
            return worker;
        }
        /// <summary>
        /// Zacatie obednej prestavky
        /// </summary>
        public virtual void LunchBreakStart()
        {
            IsTimeForLunch = true;
            int freeWorkers = FreeWorkers.Count;
            for (int i = 0; i < freeWorkers; i++)
            {
                AvergaeNumberOfFreeWorkers.Add(-1, _myAgent.MySim.CurrentTime);
                SendWorkerToLunch(FreeWorkers.Dequeue());
            }
        }
        /// <summary>
        /// Resetovanie lokalnych statistik
        /// </summary>
        public void ResetLocalStats()
        {
            AvergaeNumberOfFreeWorkers.Reset();
        }
        /// <summary>
        /// Getter pre priemerny pocet volnych placovnikov - lokalna statistika
        /// </summary>
        /// <returns></returns>
        public double AvergaeFreeWorkers()
        {
            return AvergaeNumberOfFreeWorkers.GetAverage();
        }
        /// <summary>
        /// Getter pre priemerny pocet volnych pracovnikov - globalna statistika
        /// </summary>
        /// <returns></returns>
        public double AvergaeFreeWorkersGlobal()
        {
            return SIMULATIONAvergaeNumberOfFreeWorkers.GetAverage();
        }
    }
}
