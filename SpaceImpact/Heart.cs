using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public class Heart : Entity
    {
        public Heart()
        {
            Model = new PictureBox
            {
                Size = new Size(40, 40),
                BackColor = Color.Transparent,
                BackgroundImage = SpaceImpact._darkMode ? SpaceImpact.Images["heartGreen"] : SpaceImpact.Images["heart"],
                Location = new Point(800, 250)
            };
            UpperBound = 60;
            LowerBound = 460;
            WiggleDirection = "up";
        }

        public void Move()
        {
            Model.Left--;
            if (WiggleDirection == "up")
                Model.Top--;
            else
                Model.Top++;
            this.CheckBoundries();
        }
    }
}