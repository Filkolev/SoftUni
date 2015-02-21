namespace _02.AsynchronousTimer
{
    using System;
    using System.Threading;

    class AsyncTimer
    {
        private int ticks;
        private int sleepTimeInMilliseconds;

        public AsyncTimer(Action<int> method, int ticks, int sleepTimeInMilliseconds)
        {
            this.MethodToExecute = method;
            this.Ticks = ticks;
            this.SleepTimeInMilliseconds = sleepTimeInMilliseconds;
        }

        public Action<int> MethodToExecute { get; private set; }

        public int Ticks
        {
            get
            {
                return this.ticks;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ticks", "The method should be executed at least once.");
                }

                this.ticks = value;
            }
        }

        public int SleepTimeInMilliseconds
        {
            get
            {
                return this.sleepTimeInMilliseconds;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("sleepTimeInMilliseconds", "The sleep time cannot be negative.");
                }

                this.sleepTimeInMilliseconds = value;
            }
        }

        public void ExecuteAction()
        {
            Thread parallelThread = new Thread(this.Run);
            parallelThread.Start();
        }

        private void Run()
        {
            for (int i = 0; i < this.Ticks; i++)
            {
                Thread.Sleep(this.SleepTimeInMilliseconds);

                if (this.MethodToExecute != null)
                {
                    this.MethodToExecute(i);
                }
            }
        }
    }
}
