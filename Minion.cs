using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public class Minion : Entity
    {
        private static readonly Random Rnd = new Random();

        public Minion()
        {
            var spawnY = Rnd.Next(130, 350);
            Model = new PictureBox
            {
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                BackgroundImage = SpaceImpact._darkMode ? SpaceImpact.Images["minionGreen"] : SpaceImpact.Images["minion"],
                Location = new Point(800, spawnY)
            };
            UpperBound = spawnY - 60;
            LowerBound = spawnY + 60;
            WiggleDirection = "up";
        }

        public void Move()
        {
            Model.Left -= 2;
            if (WiggleDirection == "up")
                Model.Top--;
            else
                Model.Top++;
            this.CheckBoundries();
        }
    }
}