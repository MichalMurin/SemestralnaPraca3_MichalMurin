using AgentSTKSimulation.StkStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.StkStation.Models
{
    public class Technician:Worker
    {
        public Technician(int id):base(id)
        {

        }

        public override string ToString()
        {
            string work = WorkService.SituationToString(Work);
            string isWorkingStr = CustomerId>0? $", zakaznik: {CustomerId}": "";
            return $"Technik {Id} {work} {isWorkingStr}";
        }
    }
}
