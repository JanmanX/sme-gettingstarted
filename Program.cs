using System;
using System.Linq;
using SME;

namespace GettingStarted
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            // Safe version
            using(var sim = new Simulation())
            {
                var simulator = new IndexSimulator();
                var test_process = new TestProcess(simulator.idx_bus);

                sim
                    .AddTopLevelOutputs(test_process.pcb_bus)
                    .AddTopLevelInputs(simulator.idx_bus)
                    .BuildCSVFile()
                    .BuildVHDL()
    			    .Run();
           }

             // Unsafe version
             using(var sim = new Simulation())
             {
                 var simulator = new IndexSimulator();
                 var test_process = new TestUnsafeProcess(simulator.idx_bus);

                 sim
                     .AddTopLevelOutputs(test_process.pcb_bus)
                     .AddTopLevelInputs(simulator.idx_bus)
                     .BuildCSVFile()
                     .BuildVHDL()
    			     .Run();
            }
	
		}
	}
}
