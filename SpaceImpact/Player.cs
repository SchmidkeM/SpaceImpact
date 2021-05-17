using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public class Player : Entity
    {
        public List<Projectile> Projectiles;
        public int Cooldown;
        public int Health;

        public Player()
        {
            Model = new PictureBox
            {
                Size = new Size(100, 70),
                BackColor = Color.Transparent,
                BackgroundImage = SpaceImpact._darkMode ? SpaceImpact.Images["shipGreen"] : SpaceImpact.Images["ship"],
                Location = new Point(20, 220)
            };
            Health = 3;
            Projectiles = new List<Projectile>();
            Cooldown = 0;
        }

        public void Move()
        {
            switch (SpaceImpact._activeKey)
            {
                case Keys.Down:
                    if (Model.Bottom < 460)
                        Model.Top += 4;
                    break;
                case Keys.Up:
                    if (Model.Top > 60)
                        Model.Top -= 4;
                    break;
                case Keys.Left:
                    if (Model.Left > 0)
                        Model.Left -= 4;
                    break;
                case Keys.Right:
                    if (Model.Right < 600)
                        Model.Left += 4;
                    break;
            }
        }

        public void Shoot()
        {
            Projectiles.Add(new Projectile(this));
            Cooldown = 30;
            SpaceImpact.Sounds["shoot"].Play();
        }

        public void MoveProjectiles()
        {
            foreach (Projectile p in Projectiles)
                p.Move();
        }
    }
}