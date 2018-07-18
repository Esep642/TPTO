using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Engine;
using Engine.Utils;

namespace Game
{
    public class EnemyShip : GameObject
    {
        private static Random rnd = new Random();

        private int shipIndex;
        private EnemyBehavior behavior;
        
        public EnemyShip(int shipIndex, EnemyBehavior behavior)
        {
            this.shipIndex = shipIndex;
            this.behavior = behavior;
            
            Visible = false;
            Universe.EShips.Add(this);
        }
        public override void Delete()
        {
            Universe.EShips.Remove(this);
            base.Delete();
        }
        public PlayerShip Player
        {
            get
            {
                return Universe.Player; 
            }
        }

        public EnemyBehavior Behavior
        {
            get { return behavior; }
        }

        public override void Update(float deltaTime)
        {
            behavior.Update(this, deltaTime);
           if (Position.X < 0)
                Delete();
      
            Visible = true;
        }

        public void Explode()
        {
            if (rnd.NextDouble() > 0.95)
            {
                PowerUp pup = new PowerUp();
                pup.Center = Center;
                Root.AddChild(pup);
            }
            Explosion.Burst(Parent, Center);
            Delete();
        }

        public override void DrawOn(Graphics graphics)
        {
            graphics.DrawImage(LoadImage(), Bounds);
        }

        private Image LoadImage()
        {
            // Image[] ships = Spritesheet.Load(@"Resources\shipsheetparts.png", new Size(128, 128));
            /* foreach (Image img in ships)
             {
                 img.RotateFlip(RotateFlipType.Rotate270FlipNone);
             }*/
            // Image result = ships[shipIndex];
            // result.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Image result = Universe.ShipModels[shipIndex];
  
            Extent = new SizeF(result.Size.Width / 2, result.Size.Height / 2);
            return result;
        }
    }
}
