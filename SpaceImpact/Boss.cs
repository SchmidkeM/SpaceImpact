using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public class Boss : Entity
    {
        public List<Projectile> Projectiles;
        public int Cooldown;
        public int Health;

        public Boss()
        {
            Model = new PictureBox
            {
                Size = new Size(152, 160),
                BackColor = Color.Transparent,
                BackgroundImage = SpaceImpact._darkMode ? SpaceImpact.Images["bossGreen"] : SpaceImpact.Images["boss"],
                Location = new Point(800, 250)
            };
            UpperBound = 60;
            LowerBound = 460;
            WiggleDirection = "up";
            Health = 30;
            Projectiles = new List<Projectile>();
            Cooldown = 0;
        }

        public void Move()
        {
            if (Model.Right > 800)
                Model.Left--;
            if (WiggleDirection == "up")
                Model.Top--;
            else
                Model.Top++;
            this.CheckBoundries();
        }

        public void Shoot()
        {
            Projectiles.Add(new Projectile(this));
            Cooldown = 100;
            SpaceImpact.Sounds["shoot"].Play();
        }

        public void MoveProjectiles()
        {
            foreach (Projectile p in Projectiles)
                p.Move();
        }
    }
}