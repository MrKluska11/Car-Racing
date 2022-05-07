using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public interface IElementsLines
    {
        List<PictureBox> Lines { get; set; }
        PictureBox StartLine { get; set; }
        PictureBox FinishLine { get; set; }
    }
}
