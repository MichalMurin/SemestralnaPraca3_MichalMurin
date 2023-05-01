using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSTKSimulation.StkStation.Models
{
    public enum Work
    {
        ACCEPTANCE,
        SERVICE,
        PAYMENT,
        LUNCH,
        UNKNOWN
    }
    public static class WorkService
    {
        public static string SituationToString(Work work)
        {
            switch (work)
            {
                case Work.ACCEPTANCE:
                    return "prijima";
                case Work.SERVICE:
                    return "obsluhuje";
                case Work.PAYMENT:
                    return "vybavuje platenie";
                case Work.LUNCH:
                    return "obeduje";
                default:
                    return "oddychuje";
            }
        }
    }
}
