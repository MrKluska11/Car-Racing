using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class Indicators : IIndicatorsMove, IIndicatorCoins, IIndicatorState
    {
        public int Coins { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsStart { get; set; }
        public bool IsPause { get; set; }
        public bool IsFinish { get; set; }

        public Indicators()
        {
            Speed = 6;
            IsGameOver = false;
            IsStart = true;
            IsPause = false;
            IsFinish = false;
        }
    }
}
