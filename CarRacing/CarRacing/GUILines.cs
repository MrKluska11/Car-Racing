using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class GUILines : ILinesMove
    {
        public IElementsLines Lines { get; set; }
        public IIndicatorsMove Indicators { get; set; }


        public GUILines(PictureBox start, PictureBox finish, IIndicatorsMove indicators, IElementsLines lines)
        {
            Lines = lines;
            Lines.StartLine = start;
            Lines.FinishLine = finish;
            Indicators = indicators;
        }

        public void moveLines()
        {
            foreach (PictureBox p in Lines.Lines)
            {
                if (p.Top < 400)
                {
                    p.Top += Indicators.Speed;
                }
                else
                {
                    p.Top = 0;
                }
            }

            Lines.StartLine.Top += Indicators.Speed;
            Indicators.Distance += Indicators.Speed;

            if (Indicators.Distance >= 15000)
            {
                Lines.FinishLine.Visible = true;
                Lines.FinishLine.Top += Indicators.Speed;
            }
        }
    }
}
