using AgentSim.StkStation.Models;
using DISS_S2.StkStation;
using OSPABA;
namespace simulation
{
	public class StkMessage : MessageForm
	{
        public Customer Customer { get; set; }
        public Worker Worker { get; set; }
		public bool HasParkingReserved { get; set; }
		public StkMessage(Simulation sim, Customer cus, Worker wor) :
			base(sim)
		{
			HasParkingReserved = false;
			Customer = cus;
			Worker = wor;
		}

		public StkMessage(StkMessage original) :
			base(original)
		{
			// copy() is called in superclass
		}

		override public MessageForm CreateCopy()
		{
			return new StkMessage(this);
		}

		override protected void Copy(MessageForm message)
		{
			base.Copy(message);
			StkMessage original = (StkMessage)message;
			if (original.Customer != null)
            {
                Customer = new Customer(original.Customer);
            }
			if (original.Worker != null)
            {
                Worker = new Worker(original.Worker);
            }
            HasParkingReserved = original.HasParkingReserved;
            // Copy attributes
        }

        public override string ToString()
        {
            return Customer.ToString();
        }
    }
}
