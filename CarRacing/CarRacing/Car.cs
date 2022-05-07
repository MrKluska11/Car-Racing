using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRacing
{
    public class Car : ICar
    {
        public PictureBox MainCar { get; set; }
        public string Nick { get; set; }

        public Car(PictureBox mainCar)
        {
            MainCar = mainCar;
            Nick = "Player";
        }
    }
}
