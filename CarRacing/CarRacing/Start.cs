using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class Start : IStart
    {
        public int StartCounter { get; set; }
        public Indicators Indicators { get; set; }
        public Timer TimerMove { get; set; }
        public Timer TimerStart { get; set; }

        public Start(Timer move, Timer start, Indicators indicators)
        {
            StartCounter = 3;
            TimerMove = move;
            TimerStart = start;
            Indicators = indicators;
        }

        public void StartCounting(Label label, Panel pStart, Panel pGameOver)  //tu nie powinno być dostępu do kontrolek
        {
            TimerStart.Enabled = true;
            TimerMove.Enabled = false;
            Indicators.Speed = 4;       //zerowanie wskazników powinno być w metodzie "resetIndicators" w klasie "Indicators"
            Indicators.Coins = 0;
            Indicators.Distance = 0;
            Indicators.IsStart = true;

            if (StartCounter >= 0)
            {
                label.Text = StartCounter.ToString();
                StartCounter--;
            }
            else
            {
                TimerStart.Enabled = false;
                pStart.Visible = false;
                pGameOver.Visible = false;
                Indicators.IsStart = false;
                TimerMove.Enabled = true;
            }
        }
    }
}
