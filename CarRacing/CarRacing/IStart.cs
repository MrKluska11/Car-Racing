using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public interface IStart
    {
        int StartCounter { get; set; }
        Indicators Indicators { get; set; }
        Timer TimerMove { get; set; }
        Timer TimerStart { get; set; }

        void StartCounting(Label label, Panel pStart, Panel pGameOver);
    }
}
