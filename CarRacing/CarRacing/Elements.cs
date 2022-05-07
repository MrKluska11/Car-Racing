using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class Elements : IElementsLines, IElementsCoins, IElementsEnemies
    {
        public List<PictureBox> Lines { get; set; }
        public PictureBox StartLine { get; set; }
        public PictureBox FinishLine { get; set; }
        public List<PictureBox> Coins { get; set; }
        public List<PictureBox> Enemies { get; set; }

        public Elements(List<PictureBox> lines, List<PictureBox> coins, List<PictureBox> enemies, PictureBox start, PictureBox finish)
        {
            Lines = lines;
            Coins = coins;
            Enemies = enemies;
            StartLine = start;
            FinishLine = finish;
        }
    }
}
