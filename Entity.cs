using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpaceImpact
{
    public abstract class Entity
    {
        public PictureBox Model;
        protected int UpperBound;
        protected int LowerBound;
        protected string WiggleDirection;
        public bool OutTheWindow;

        protected void CheckBoundries()
        {
            if (Model.Top < UpperBound)
                WiggleDirection = "down";
            if (Model.Bottom > LowerBound)
                WiggleDirection = "up";
            if (Model.Right < 0 || Model.Left > 800)
                OutTheWindow = true;
        }
    }
}