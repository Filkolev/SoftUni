namespace SolarSystem
{
    using System;
    using System.ComponentModel;
    using System.Windows.Threading;

    public class OrbitsCalculator : INotifyPropertyChanged
    {
        private const double EarthYear = 365.25;
        private const double EarthRotationPeriod = 1.0;
        private const double SunRotationPeriod = 25.0;

        private DateTime startTime;
        private DispatcherTimer timer;

        private double daysPerSecond = 2;

        public OrbitsCalculator()
        {
            this.EarthOrbitPositionX = this.EarthOrbitRadius;
            this.DaysPerSecond = 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double DaysPerSecond
        {
            get
            {
                return this.daysPerSecond;
            }

            set
            {
                this.daysPerSecond = value;
                this.Update("DaysPerSecond");
            }
        }

        public double EarthOrbitRadius
        {
            get
            {
                return 40;
            }
        }

        public double Days { get; set; }

        public double EarthRotationAngle { get; set; }

        public double SunRotationAngle { get; set; }

        public double EarthOrbitPositionX { get; set; }

        public double EarthOrbitPositionY { get; set; }

        public double EarthOrbitPositionZ { get; set; }

        public bool ReverseTime { get; set; }

        public bool Paused { get; set; }

        public void StartTimer()
        {
            this.startTime = DateTime.Now;
            this.timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };
            this.timer.Tick += this.OnTimerTick;
            this.timer.Start();
        }

        public void Pause(bool doPause)
        {
            if (doPause)
            {
                this.StopTimer();
            }
            else
            {
                this.StartTimer();
            }
        }

        private void StopTimer()
        {
            this.timer.Stop();
            this.timer.Tick -= this.OnTimerTick;
            this.timer = null;
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            this.Days += (now - this.startTime).TotalMilliseconds * this.DaysPerSecond / 1000.0 * (this.ReverseTime ? -1 : 1);
            this.startTime = now;
            this.Update("Days");
            this.OnTimeChanged();
        }

        private void OnTimeChanged()
        {
            this.EarthPosition();
            this.EarthRotation();
            this.SunRotation();
        }

        private void EarthPosition()
        {
            double angle = 2 * Math.PI * this.Days / EarthYear;
            this.EarthOrbitPositionX = this.EarthOrbitRadius * Math.Cos(angle);
            this.EarthOrbitPositionY = this.EarthOrbitRadius * Math.Sin(angle);
            this.Update("EarthOrbitPositionX");
            this.Update("EarthOrbitPositionY");
        }

        private void EarthRotation()
        {
            // for (decimal step = 0; step <= 360; step += 0.00005m)
            // {
            //    EarthRotationAngle = ((double)step) * Days / EarthRotationPeriod;
            // }

            this.EarthRotationAngle = 360 * this.Days / EarthRotationPeriod;
            this.Update("EarthRotationAngle");
        }

        private void SunRotation()
        {
            this.SunRotationAngle = 360 * this.Days / SunRotationPeriod;
            this.Update("SunRotationAngle");
        }

        private void Update(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
    }
}
