using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class GUICoins : ICoinsAction
    {
        public PictureBox CollectedCoin { get; set; }
        public IIndicatorsMove IndicatorsMove { get; set; }
        public IIndicatorCoins IndicatorsCoins { get; set; }
        public ICar Car { get; set; }
        public IElementsCoins Coins { get; set; }
        public IElementsEnemies Enemies { get; set; }

        public GUICoins(Indicators indicators, ICar car, IElementsCoins coins, IElementsEnemies enemies)
        {
            IndicatorsMove = indicators;
            IndicatorsCoins = indicators;
            Car = car;
            Coins = coins;
            Enemies = enemies;
        }

        public void moveCoins()
        {
            bool collision;
            Random rand = new Random();

            foreach (PictureBox p in Coins.Coins)
            {
                if (p.Top < 400)
                {
                    p.Top += IndicatorsMove.Speed / 2;
                }
                else
                {
                    p.Visible = true;

                    if (p == CollectedCoin)
                    {
                        CollectedCoin = null;    //ponieważ przy null wyskoczy wyjątek
                    }

                    do
                    {
                        collision = false;
                        p.Location = new Point(rand.Next(34, 320), 0);

                        //monety nie mogą się zazębiać z wrogimi autami
                        foreach (PictureBox p2 in Enemies.Enemies)
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

        public void pickCoins(Label label)
        {
            foreach (PictureBox p in Coins.Coins)
            {
                if (p.Bounds.IntersectsWith(Car.MainCar.Bounds) && p != CollectedCoin)
                {
                    CollectedCoin = p;
                    IndicatorsCoins.Coins++;
                    label.Text = "Coins: " + IndicatorsCoins.Coins;

                    p.Visible = false;
                }
            }
        }
    }
}
