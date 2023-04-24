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
            string work = Work == null ? string.Empty : Work.ToString();
            string isWorkingStr = IsWorking ? $"pracuje: {work}" : "nepracuje";
            return $"Mechanik {Id} {isWorkingStr}";
        }
    }
}
