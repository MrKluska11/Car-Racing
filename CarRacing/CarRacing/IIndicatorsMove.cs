using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    public interface IIndicatorsMove
    {
        int Speed { get; set; }
        int Distance { get; set; }
    }
}
