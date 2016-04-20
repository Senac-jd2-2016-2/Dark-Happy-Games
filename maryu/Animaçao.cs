using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class Animaçao
    {
        public Texture2D Textuer;
        public Rectangle Rectangel;
        public int CurrentFrame;
        public int stayfreshTime;
        public Point fameSize;
        public int shitSize;

        public Animaçao(int frameSizeX, int frameSizeY, int size)
        {
            fameSize = new Point(frameSizeX, frameSizeY);
            shitSize = size;
            stayfreshTime = 0;
        }

        public void LoadContent(ContentManager Content, String dir)
        {
            Textuer = Content.Load<Texture2D>(dir);
            Rectangel = new Rectangle(CurrentFrame * fameSize.X, 0, fameSize.X, fameSize.Y);
        }

        public void SetFrame(int frame)
        {
            Rectangel = new Rectangle(CurrentFrame * fameSize.X, frame, fameSize.X, fameSize.Y);
        }

        public void Update(GameTime gameTime)
        {
            stayfreshTime += gameTime.ElapsedGameTime.Milliseconds;

            if (stayfreshTime > 70)
            {
                stayfreshTime = 0;
                CurrentFrame++;

                if (CurrentFrame >= shitSize)
                {
                    CurrentFrame = 0;
                }
            }
        }
    }
}
