using System;
using System.Threading;

namespace Ticker
{
    internal class Ticker
    {
        public delegate void TickerEventHandler(object sender, TickerEventArgs args);

        private readonly Func<bool> context;

        private readonly int interval;

        public Ticker(int interval, Func<bool> context)
        {
            this.interval = interval;
            this.context = context;
        }

        public event TickerEventHandler OnTick;

        public void Start()
        {
            void TickerWorker()
            {
                Thread.Sleep(interval);
                while (!context())
                {
                    OnTick?.Invoke(this, new TickerEventArgs(DateTime.Now));
                    Thread.Sleep(interval);
                }
            }

            ThreadStart tickerRef = TickerWorker;
            var tickerThread = new Thread(tickerRef);
            tickerThread.Start();
        }

        public class TickerEventArgs
        {
            public TickerEventArgs(DateTime t)
            {
                Time = t;
            }

            public DateTime Time { get; }
        }
    }

    internal class Alarm
    {
        public delegate void AlarmEventHandler(object sender, Ticker.TickerEventArgs args);

        private readonly DateTime time;
        private Action cancel;
        private bool enable;
        private bool finished;
        private Ticker ticker;

        public Alarm(DateTime t)
        {
            time = t;
            enable = false;
        }

        public bool Enable
        {
            get => enable;
            set
            {
                if (value)
                {
                    if (enable) return;
                    if (finished) throw new InvalidOperationException("Can't enable finished alarm.");
                    var interval = time - DateTime.Now;
                    if (interval.Ticks <= 0)
                        throw new InvalidOperationException("Can't enable alarm with passed fire time.");
                    var (ctx, _cancel) = Program.Context();
                    cancel = _cancel;
                    ticker = new Ticker(interval.Milliseconds * 10, ctx);
                    ticker.OnTick += (_, e) =>
                    {
                        finished = true;
                        cancel();
                        OnAlarm?.Invoke(this, e);
                    };
                    ticker.Start();
                    enable = true;
                }
                else
                {
                    if (!enable) throw new InvalidOperationException("Can't cancel alarm that haven't enabled.");
                    if (finished) return;
                    finished = true;
                    cancel();
                }
            }
        }

        public event AlarmEventHandler OnAlarm;
    }

    internal static class Program
    {
        public static (Func<bool>, Action) Context()
        {
            var fired = false;
            return (() => fired, () => fired = true);
        }

        private static void Main()
        {
            Console.WriteLine($"[Main  : {DateTime.Now.ToLongTimeString()}] Started.");
            var (context, cancel) = Context();
            var timer1 = new Ticker(1000, context);
            var timer2 = new Ticker(1500, context);
            timer1.OnTick += (_, e) => Console.WriteLine($"[Timer1: {e.Time.ToLongTimeString()}] Tick in 1s.");
            timer2.OnTick += (_, e) => Console.WriteLine($"[Timer2: {e.Time.ToLongTimeString()}] Tick in 1.5s.");

            var alarm = new Alarm(DateTime.Now.AddSeconds(10));
            alarm.OnAlarm += (_, e) => Console.WriteLine($"[Alarm : {e.Time.ToLongTimeString()}] Alarm fired.");

            timer1.Start();
            timer2.Start();
            alarm.Enable = true;

            Thread.Sleep(30000);
            cancel();

            Console.WriteLine($"[Main  : {DateTime.Now.ToLongTimeString()}] Finished.");
            Console.ReadLine();
        }
    }
}