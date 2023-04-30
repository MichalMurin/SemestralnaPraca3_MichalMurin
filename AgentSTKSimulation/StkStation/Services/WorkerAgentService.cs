using agents;
using AgentSim.StkStation.Models;
using OSPABA;
using simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSTKSimulation.StkStation.Services
{
    internal class WorkerAgentService
    {
        private Agent _myAgent;
        public WorkerAgentService(Agent myAgent)
        {
            _myAgent = myAgent;
        }

        /// <summary>
        /// Uvolnenenie pracovnika
        /// </summary>
        /// <param name="worker"></param>
        internal void SetWorkerFree(Worker worker)
        {
            worker.IsWorking = false;
            worker.Work = Models.Work.UNKNOWN;
            if (worker.GetType() == typeof(Mechanic))
            {
                ((MechanicsAgent)_myAgent).FreeMechanics.Enqueue((Mechanic)worker);
                ((MechanicsAgent)_myAgent).AvergaeNumberOfFreeMechanics.Add(1, _myAgent.MySim.CurrentTime);
            }
            if (worker.GetType() == typeof(Technician))
            {
                ((TechniciansAgent)_myAgent).FreeTechnicians.Enqueue((Technician)worker);
                ((TechniciansAgent)_myAgent).AvergaeNumberOfFreeTechnicians.Add(1, _myAgent.MySim.CurrentTime);
            }
        }

        internal void SendWorkerToLunch(Worker worker)
        {
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
            worker.IsWorking = true;
            message.Addressee = _myAgent.FindAssistant(id);
            _myAgent.MyManager.StartContinualAssistant(message);
        }
    }
}
