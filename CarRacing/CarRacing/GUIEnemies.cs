using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class GUIEnemies : IEnemiesMove
    {
        public IIndicatorsMove Indicators { get; set; }
        public IElementsEnemies Enemies { get; set; }
        public IElementsCoins Coins { get; set; }

        public GUIEnemies(IIndicatorsMove indicators, IElementsEnemies enemies, IElementsCoins coins)
        {
            Indicators = indicators;
            Enemies = enemies;
            Coins = coins;
        }

        public void moveEnemies()
        {
            Random rand = new Random();
            bool collision;

            foreach (PictureBox p in Enemies.Enemies)
            {
                if (p.Top < 400)
                {
                    p.Top += Indicators.Speed / 2;
                }
                else
                {
                    do
                    {
                        collision = false;
                        p.Location = new Point(rand.Next(44, 310), 0);

                        foreach (PictureBox p2 in Coins.Coins)
                        {
                            if (p2.Bounds.IntersectsWith(p.Bounds))
                            {
                                collision = true;
                            }
                        }
                    } while (collision);

                }
            }
        }
    }
}
