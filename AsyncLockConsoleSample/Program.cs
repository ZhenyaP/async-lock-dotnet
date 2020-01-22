using System;
using System.Threading.Tasks;

namespace AsyncLockConsoleSample
{
    class Program
    {
        private static async Task Foo()
        {
            var _lock = new AsyncLock();
            var unlock = await _lock.Lock();
            unlock();         //if we comment out this line, we will have a deadlock,
                              // as the lock has already been acquired !
            for (var i = 0; i < 10; i++) await Bar(_lock);

            //unlock();
        }

        private static async Task Bar(AsyncLock _lock)
        {
            var unlock = await _lock.Lock();
            // do something sync
            unlock();
        }

        static async Task Main(string[] args)
        {
            await Foo();
        }
    }
}
