using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousTimer
{
    class AsyncTimer
    {
        private Action action;
        private int ticks;
        private int interval;
        private bool isReady;

        public AsyncTimer(Action action, int ticks, int interval)
        {
            this.action = action;
            this.ticks = ticks;
            this.interval = interval;
        }

        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                this.isReady = false;
                int ticksLeft = this.ticks;
                while (--ticksLeft > 0)
                {
                    this.action();
                    Thread.Sleep(this.interval);
                }
                this.isReady = true;
            });
        }

        public bool IsReady
        {
            get { return this.isReady; }
        }
    }
}
