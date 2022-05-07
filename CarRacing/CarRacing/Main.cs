using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class Main
    {
        public ICar Car { get; set; }
        public Timer TimerMove { get; set; }    //timery wrzuć do jakiejś klasy np Timers
        public Timer TimerStart { get; set; }       
        public Indicators Indicators { get; set; }
        public IElementsLines Lines { get; set; }
        public IElementsEnemies Enemies { get; set; }
        public IElementsCoins Coins { get; set; }
        public IStart Start { get; set; }

        public Main(Timer tStart, Timer tMove, Indicators indicators, ICar car, IElementsLines lines, IElementsEnemies enemies, 
                        IElementsCoins coins, IStart start)
        {
            TimerStart = tStart;
            TimerMove = tMove;
            TimerStart.Enabled = true;
            TimerMove.Enabled = false;
            Indicators = indicators;
            Car = car;
            Lines = lines;
            Enemies = enemies;
            Coins = coins;
            Start = start;
        }


        public void Reset(Button bStart, Panel pStart, Panel pFinish, Panel pGameOver, Label label)
        {
            Indicators.IsGameOver = false;
            Indicators.IsFinish = false;

            Lines.StartLine.Location = new Point(25, 251);
            Enemies.Enemies[0].Location = new Point(290, 99);
            Enemies.Enemies[1].Location = new Point(131, -1);
            Enemies.Enemies[2].Location = new Point(230, 202);
            Coins.Coins[0].Location = new Point(277, 12);
            Coins.Coins[1].Location = new Point(39, 139);
            Coins.Coins[0].Visible = true;
            Coins.Coins[1].Visible = true;
            Car.MainCar.Location = new Point(85, 258);
            bStart.Visible = false;
            pFinish.Visible = false;
            pGameOver.Visible = false;
            pStart.Visible = true;

            Start.StartCounter = 3;
            Indicators.Coins = 0;
            label.Text = "Coins: " + Indicators.Coins;

            TimerMove.Enabled = false;
            TimerStart.Enabled = true;

            Lines.FinishLine.Top = -1;
            Lines.FinishLine.Visible = false;
        }

        public void GameOver(Panel pGameOver, Button bStart)
        {
            foreach (PictureBox p in Enemies.Enemies)
            {
                if (p.Bounds.IntersectsWith(Car.MainCar.Bounds))
                {
                    pGameOver.Visible = true;
                    Indicators.Speed = 0;
                    Indicators.IsGameOver = true;
                    bStart.Visible = true;
                    TimerMove.Enabled = false;

                    break;
                }
            }
        }

        public void Finish(Panel pStart, Panel pFinish, Panel pGameOver, Button bStart)
        {
            if (Car.MainCar.Bounds.IntersectsWith(Lines.FinishLine.Bounds))
            {
                TimerMove.Enabled = false;
                Indicators.IsFinish = true;
                pGameOver.Visible = true;
                pStart.Visible = true;
                pFinish.Visible = true;
                bStart.Visible = true;
            }
        }
    }

}

