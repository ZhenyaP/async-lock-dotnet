using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLockConsoleSample
{
    public class AsyncLock
    {
        private Task _unlockedTask = Task.CompletedTask;

        public async Task<Action> Lock()
        {
            var tcs = new TaskCompletionSource<object>();

            await Interlocked.Exchange(ref _unlockedTask, tcs.Task);

            return () => tcs.SetResult(null);
        }
    }
}
