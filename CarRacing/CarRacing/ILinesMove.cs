using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    public interface ILinesMove
    {
        IIndicatorsMove Indicators { get; set; }
        void moveLines();
    }
}
