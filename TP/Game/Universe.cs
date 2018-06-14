using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Engine.Utils;

namespace Game
{
    class Universe
    {
        public static List<PowerUp> Pows = new List<PowerUp>();
        public static List<EnemyShip> EShips = new List<EnemyShip>(); 
        public static Image[] ShipModels = Spritesheet.Load
            (@"Resources\shipsheetparts.png", new Size(128, 128));
        public static Image[] RightFacingShipModels = Spritesheet.Load
            (@"Resources\shipsheetparts.png", new Size(128, 128));
        public static void RotateShips ()
        {
            foreach(Image I in ShipModels)
            {
                I.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            foreach (Image I in RightFacingShipModels)
            {
                I.RotateFlip(RotateFlipType.Rotate270FlipNone);
               I.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
        }
    }
}
