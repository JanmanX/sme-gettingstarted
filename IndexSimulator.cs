using SME;
using System;
using System.Threading.Tasks;

namespace GettingStarted
{
	public class IndexSimulator : SimulationProcess
	{
		[OutputBus]
		public readonly IndexBus idx_bus = Scope.CreateBus<IndexBus>();

		private Random rand = new Random();

		public override async Task Run()
		{
			for(uint i = 0; i < 100; i++)
			{
				idx_bus.idx = (uint)(rand.Next() % 10);

				await ClockAsync();
			}
		}
	}
}
