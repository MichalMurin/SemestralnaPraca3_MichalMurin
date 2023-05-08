using AgentSim.StkStation.Models;
using DISS_S2.StkStation;
using OSPABA;
namespace simulation
{
	public class StkMessage : MessageForm
	{
		/// <summary>
		/// zakaznik prechadzajuci systemom
		/// </summary>
        public Customer Customer { get; set; }
		/// <summary>
		/// pracovnik obsluhujuci zakaznika
		/// </summary>
        public Worker Worker { get; set; }
		/// <summary>
		/// Konstruktor spravy
		/// </summary>
		/// <param name="sim"></param>
		/// <param name="cus"></param>
		/// <param name="wor"></param>
		public StkMessage(Simulation sim, Customer cus, Worker wor) :
			base(sim)
		{
			Customer = cus;
			Worker = wor;
		}
		/// <summary>
		/// Kopirovaci konstruktor spravy
		/// </summary>
		/// <param name="original"></param>
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
				Customer = original.Customer;
            }
			if (original.Worker != null)
            {
				Worker = original.Worker;
            }
            // Copy attributes
        }

        public override string ToString()
        {
            return Customer.ToString();
        }
    }
}
