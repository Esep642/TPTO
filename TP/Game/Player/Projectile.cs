using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Engine;
using Engine.Extensions;

namespace Game
{
    public class Projectile : GameObject
    {
        private Image img;
        private float speed = 700;

        public Projectile()
        {
            img = Properties.Resources.projectile;

            Extent = img.Size;
        }

        public override void Update(float deltaTime)
        {
            X += speed * deltaTime;
            if (X > Root.Right) Delete();
            CheckForCollision();
        }

        private void CheckForCollision()
        {
            IEnumerable<EnemyShip> collisions = Universe.EShips
                .Where((m) => CollidesWith(m));
            for (int C = 0; C < collisions.Count(); C++)
            {
                collisions.ElementAt(C).Explode();
                Delete();
            }
           /* foreach (EnemyShip enemy in collisions)
            {
                if (enemy != null)
                {
                    enemy.Explode();
                    Delete();
                }
            }
            */
        }

        public override void DrawOn(Graphics graphics)
        {
            graphics.DrawImage(img, Position);
        }
    }
}
