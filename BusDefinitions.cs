using SME;

namespace GettingStarted
{
	public interface IndexBus : IBus {
		[InitialValue(0)]
		uint idx { get; set; }
	}

	public interface PCBBus : IBus {
		[InitialValue]
		bool valid { get; set; }

		[InitialValue]
		PCB pcb { get; set; }	

		[InitialValue]
		bool finished { get; set; }
	}

	public interface PCBUnsafeBus: IBus {
		[InitialValue]
		bool valid { get; set; }

		[InitialValue]
		PCBUnsafe pcb { get; set; }	

		[InitialValue]
		bool finished { get; set; }
	}


}
