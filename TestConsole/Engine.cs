using System.Timers;

namespace TestConsole
{
    public class Engine
    {
        public bool IsEnabled { get; set; }

        private readonly Game _game = new();
        private readonly Timer _clock = new();

        private int _fps = 30;
        public int FPS
        {
            get => _fps;
            set
            {
                _fps = value;
                _clock.Interval = 1000 / value;
            }
        }

        public Engine()
        {
            _clock.Elapsed += TimerTick;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            _game.UpdateGame();


            ConsoleVizulizator.ShowFrame(MapConverter.ConvertMapToFrame(_game.GetMap()));
        }

        public void Start()
        {
            if (IsEnabled) return;
            _clock.Start();
            IsEnabled = true;
        }


        public void Stop()
        {
            _clock.Stop();
            IsEnabled = false;
        }
    }
}
