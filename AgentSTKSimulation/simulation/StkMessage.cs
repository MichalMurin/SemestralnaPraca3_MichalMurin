using OSPABA;
namespace simulation
{
	public class StkMessage : MessageForm
	{
		public StkMessage(Simulation sim) :
			base(sim)
		{
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
			// Copy attributes
		}
	}
}
