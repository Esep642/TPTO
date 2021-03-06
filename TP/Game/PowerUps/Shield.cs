﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine;
using System.Drawing;

namespace Game
{
    public class Shield : GameObject
    {
        private Image img;
        private int duration;
        private int startTime;

        public Shield (int duration = 2500)
        {
            img = Properties.Resources.shield;
            Extent = img.Size;

            this.duration = duration;
            startTime = Environment.TickCount;
        }

        public override void Update(float deltaTime)
        {
            PlayerShip player = Parent as PlayerShip;
            if (player != null) { player.ShieldActivated = true; }

            CheckForCollisions();
            if (Environment.TickCount - startTime > duration)
            {
                Delete();
                if (player != null) { player.ShieldActivated = false; }
            }
        }

        private void CheckForCollisions()
        {
            IEnumerable<EnemyShip> collisions = Universe.EShips/*AllObjects*/
                //.Select((m) => m as EnemyShip)
                .Where((m) => CollidesWith(m));

        /*    foreach (EnemyShip enemy in collisions)
            {
                enemy.Explode();
            }*/
            for (int C = 0; C < collisions.Count(); C++)
            {
                collisions.ElementAt(C).Explode();
               
            }
        }

        public override void DrawOn(Graphics graphics)
        {
            graphics.DrawImage(img, Bounds);
        }
    }
}
