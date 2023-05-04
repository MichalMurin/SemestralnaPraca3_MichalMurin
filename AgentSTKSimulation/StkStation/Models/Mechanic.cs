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
        public bool Certificated { get; set; }
        public Mechanic(int id, bool certificated = true) : base(id)
        {
            Certificated = certificated;
        }

        public override string ToString()
        {
            string work = WorkService.SituationToString(Work);
            string isWorkingStr = CustomerId > 0 ? $", zakaznik: {CustomerId}" : "";
            string certificate = Certificated ? "Certifikovany" : "Necertifikovany";
            return $"{certificate} Mechanik {Id} {work} {isWorkingStr}";
        }
    }
}
