using System;
using SME;

namespace GettingStarted
{
    public struct PCB
    {
        // Connection state
        public byte state; 

        // Protocol
        public byte protocol; 

        // Foreign address and port
        public uint f_address;
        public ushort f_port;

        // Local address and port
        public uint l_address;
        public ushort l_port;

        // Accumulated checksum (used in TCP)
        public uint checksum_acc;

        // Counts the bytes received for the current packet
        public uint bytes_received;
    }


    public unsafe struct PCBUnsafe
    {
        // Connection state
        public byte state; 

        // Protocol
        public byte protocol; 

        // Foreign address and port
        public uint f_address;
        public ushort f_port;

        // Local address and port
        public uint l_address;
        public ushort l_port;

        // Accumulated checksum (used in TCP)
        public uint checksum_acc;

        // Counts the bytes received for the current packet
        public uint bytes_received;

        // data for protocol-specific data
        private const int DATA_SIZE = 64;
        public fixed byte data[DATA_SIZE];
    }


	public class TestProcess: SimpleProcess
	{
        [InputBus]
        private readonly IndexBus idx_bus;

		[OutputBus]
		public readonly PCBBus pcb_bus = Scope.CreateBus<PCBBus>();


		// Local
		PCB[] pcbs = new PCB[10];

		public TestProcess(IndexBus idx_bus)
		{
			this.idx_bus = idx_bus;


			// Test
			Random rand = new Random(42);
			for(uint i = 0; i < pcbs.Length; i++)
			{
				pcbs[i].f_address = (uint)rand.Next();
				pcbs[i].f_port = (byte)rand.Next();
			}
		}

 		protected override void OnTick()
		{
			pcb_bus.valid = true;
			pcb_bus.pcb = pcbs[idx_bus.idx];
		}
	}

	public class TestUnsafeProcess: SimpleProcess
	{
        [InputBus]
        private readonly IndexBus idx_bus;

		[OutputBus]
		public readonly PCBUnsafeBus pcb_bus = Scope.CreateBus<PCBUnsafeBus>();


		// Local
		PCBUnsafe[] pcbs = new PCBUnsafe[10];

		public TestUnsafeProcess(IndexBus idx_bus)
		{
			this.idx_bus = idx_bus;


			// Test
			Random rand = new Random(0xBEEF);
			for(uint i = 0; i < pcbs.Length; i++)
			{
				pcbs[i].f_address = (uint)rand.Next();
				pcbs[i].f_port = (byte)rand.Next();
				unsafe {
					pcbs[i].data[0] = 7;
				}
			}
		}

 		protected override void OnTick()
		{
			pcb_bus.valid = true;
			pcb_bus.pcb = pcbs[idx_bus.idx];
		}
	}
}
