using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace switcher
{
    public class Switchers : IEnumerable<Switcher>
    {
        private readonly List<Switcher> _switchers;

        public Switchers()
        {
            _switchers = new List<Switcher>();
        }

        public void Add(Switcher switcher)
        {
            var switchers = _switchers;
            switchers.Add(switcher);
        }

        public async Task SwitchIfNeededAsync(CancellationToken ct = default)
        {
            var switchers = _switchers;
            foreach (var sw in switchers)
            {
                await SwitchIfNeededInnerLoopAsync(sw, ct);
            }
        }

        private async Task SwitchIfNeededInnerLoopAsync(Switcher switcher, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
                throw new TaskCanceledException();

            switcher.SwitchIfNeeded();
            await Task.Yield();
        }

        public IEnumerator<Switcher> GetEnumerator()
        {
            var switchers = _switchers;
            return switchers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var switchers = _switchers;
            return switchers.GetEnumerator();
        }
    }
}
