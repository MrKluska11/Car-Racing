using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public interface IIndicatorState
    {
        bool IsGameOver { get; set; }
        bool IsStart { get; set; }
        bool IsPause { get; set; }
        bool IsFinish { get; set; }
    }
}
