using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public class Projectile : Entity
    {
        private readonly bool _friendly;

        public Projectile(Entity sender)
        {
            var m = sender.Model;
            var spawnX = m.Left + m.Size.Width / 2 - 20;
            var spawnY = m.Top + m.Size.Height / 2 - 10;
            Model = new PictureBox
            {
                Size = new Size(20, 10),
                BackColor = SpaceImpact._darkMode ? Color.Olive : Color.Black,
                Location = new Point(spawnX, spawnY)
            };
            if (sender.GetType() == typeof(Player))
                _friendly = true;
        }

        public void Move()
        {
            if (_friendly)
                Model.Left += 10;
            else
                Model.Left -= 5;
            this.CheckBoundries();
        }
    }
}