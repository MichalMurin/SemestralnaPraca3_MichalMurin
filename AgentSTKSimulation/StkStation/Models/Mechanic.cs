using AgentSTKSimulation.StkStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.StkStation.Models
{
    public class Mechanic: Worker
    {
        public Mechanic(int id):base(id)
        {
            
        }

        public override string ToString()
        {
            string work = WorkService.SituationToString(Work);
            string isWorkingStr = CustomerId > 0 ? $", zakaznik: {CustomerId}" : "";
            return $"Mechanik {Id} {work} {isWorkingStr}";
        }
    }
}
