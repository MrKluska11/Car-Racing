using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public interface ICar
    {
        PictureBox MainCar { get; set; }
        string Nick { get; set; }
    }
}
