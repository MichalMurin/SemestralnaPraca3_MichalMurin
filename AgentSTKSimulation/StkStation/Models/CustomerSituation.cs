using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.StkStation.Models
{
    public enum CustomerSituation
    {
        CREATED,
        WAITING_FOR_ACCEPTANCE,
        BEEING_ACCEPTED,
        WAITING_IN_GARAGE,
        SERVED_BY_MECHANIC,
        WAITING_FOR_PAYMENT,
        IS_PAYING,
        LEFT,
        UNKNOWN
    }
    public static class CustomerSitutationService
    {
        public static string SituationToString(CustomerSituation customerSituation)
        {
            switch (customerSituation)
            {
                case CustomerSituation.CREATED:
                    return "bol prave vytvoreny";
                case CustomerSituation.WAITING_FOR_ACCEPTANCE:
                    return "caka na prijatie";
                case CustomerSituation.BEEING_ACCEPTED:
                    return "je prijimany technikom";
                case CustomerSituation.WAITING_IN_GARAGE:
                    return "caka na parkovisku v garazi";
                case CustomerSituation.SERVED_BY_MECHANIC:
                    return "je na kontrole";
                case CustomerSituation.WAITING_FOR_PAYMENT:
                    return "caka na platenie";
                case CustomerSituation.IS_PAYING:
                    return "plati";
                case CustomerSituation.LEFT:
                    return "opustil prevadzku";
                default:
                    return "UNKNOWN";
            }
        }
    }
}
