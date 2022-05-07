using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public partial class RacingGame : Form
    {
        #region variables

        IElementsLines lines;
        IElementsCoins coins;
        IElementsEnemies enemies;
        ICar car;
        ILinesMove guiLines;
        IStart start;
        IEnemiesMove guiEnemies;
        ICoinsAction guiCoins;
        public Main main { get; set; }
        public Indicators indicators { get; set; }

        #endregion


        //constructor
        public RacingGame()
        {
            InitializeComponent();

            lines = new Elements(new List<PictureBox>() { pictBoxLine1, pictBoxLine2, pictBoxLine3, pictBoxLine4 }, new List<PictureBox>()
                                      { pictBoxCoin1, pictBoxCoin2 }, new List<PictureBox>() { pictBoxEnemy1, pictBoxEnemy2, pictBoxEnemy3 },
                                       pictBoxStart, pictBoxMeta);

            coins = new Elements(new List<PictureBox>() { pictBoxLine1, pictBoxLine2, pictBoxLine3, pictBoxLine4 }, new List<PictureBox>()
                                      { pictBoxCoin1, pictBoxCoin2 }, new List<PictureBox>() { pictBoxEnemy1, pictBoxEnemy2, pictBoxEnemy3 },
                           pictBoxStart, pictBoxMeta);

            enemies = new Elements(new List<PictureBox>() { pictBoxLine1, pictBoxLine2, pictBoxLine3, pictBoxLine4 }, new List<PictureBox>()
                                      { pictBoxCoin1, pictBoxCoin2 }, new List<PictureBox>() { pictBoxEnemy1, pictBoxEnemy2, pictBoxEnemy3 },
                           pictBoxStart, pictBoxMeta);

            car = new Car(pictBoxCar);

            indicators = new Indicators();

            start = new Start(timerMove, timerStart, indicators);

            guiLines = new GUILines(pictBoxStart, pictBoxMeta, indicators, lines);

            guiEnemies = new GUIEnemies(indicators, enemies, coins);

            guiCoins = new GUICoins(indicators, car, coins, enemies);

            main = new Main(timerStart, timerMove, indicators, car, lines, enemies, coins, start);

            
        }


        #region timers

        private void timerMove_Tick(object sender, EventArgs e)
        {
            guiLines.moveLines();

            guiEnemies.moveEnemies();

            guiCoins.moveCoins();
            guiCoins.pickCoins(lblCoins);

            main.GameOver(panelGameOver, btnStart);
            main.Finish(panelStart, panelFinish, panelGameOver, btnStart);
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            start.StartCounting(lblCounting, panelStart, panelGameOver);
        }

        #endregion


        #region events

        private void RacingGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && !indicators.IsGameOver && !indicators.IsStart && !indicators.IsFinish && !indicators.IsPause &&
             indicators.Speed > 0)
            {
                if (car.MainCar.Left >= 49)
                {
                    car.MainCar.Left -= 15;
                }
            }
            else if (e.KeyCode == Keys.Right && !indicators.IsGameOver && !indicators.IsStart && !indicators.IsFinish && !indicators.IsPause &&
                indicators.Speed > 0)
            {
                if (car.MainCar.Right <= 339)
                {
                    car.MainCar.Left += 15;
                }
            }
            else if (e.KeyCode == Keys.Up && !indicators.IsGameOver && !indicators.IsStart && !indicators.IsFinish && !indicators.IsPause)
            {
                if (indicators.Speed < 10)
                {
                    indicators.Speed += 2;
                }
            }
            else if (e.KeyCode == Keys.Down && !indicators.IsGameOver && !indicators.IsStart && !indicators.IsFinish && !indicators.IsPause)
            {
                if (indicators.Speed > 0)
                {
                    indicators.Speed -= 2;
                }
            }
            else if (e.KeyCode == Keys.Space && !indicators.IsGameOver && !indicators.IsStart && !indicators.IsFinish && !indicators.IsPause)
            {
                timerMove.Enabled = false;
                indicators.IsPause = true;

                panelGameOver.Visible = true;
                panelStart.Visible = true;
                panelFinish.Visible = true;
                panelPasue.Visible = true;
            }
            //Odpauzowanie
            else if (e.KeyCode == Keys.Space && !indicators.IsGameOver && !indicators.IsStart && !indicators.IsFinish && indicators.IsPause)
            {
                timerMove.Enabled = true;
                indicators.IsPause = false;

                panelGameOver.Visible = false;
                panelStart.Visible = false;
                panelFinish.Visible = false;
                panelPasue.Visible = false;
            }
        }

        #endregion

        //metoda reset
        private void btnStart_Click(object sender, EventArgs e)
        {
            main.Reset(btnStart, panelStart, panelFinish, panelGameOver, lblCoins);

            start.StartCounting(lblCounting, panelStart, panelGameOver);
        }

    }
}
