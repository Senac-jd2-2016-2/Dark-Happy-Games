using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class Camera
    {
        public Matrix Transform { set; get; }
        private Vector2 Center;
        private Viewport ViewPort;
        public Camera(Viewport newViewPort)
        {
            ViewPort = newViewPort;
        }
        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < ViewPort.Width / 2)
            {
                Center.X = ViewPort.Width / 2;
            }
            else if (position.X > xOffset - (ViewPort.Width / 2))
            {
                Center.X = xOffset - (ViewPort.Width / 2);
            }
            else
            {
                Center.X = position.X;
            }


            if (position.Y < ViewPort.Height / 2)
            {
                Center.Y = ViewPort.Height / 2;
            }
            else if (position.Y > yOffset - (ViewPort.Height / 2))
            {
                Center.Y = yOffset - (ViewPort.Height / 2);
            }
            else
            {
                Center.Y = position.Y;
            }
            Transform = Matrix.CreateTranslation(new Vector3(-Center.X + (ViewPort.Width / 2), -Center.Y + (ViewPort.Height / 2), 0));
        }
    }
}
