using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace maryu
{
    class Tiles
    {
        public int tilesx;
        public int tilesy;
        public static Texture2D normalbrick;
        public Tiles(int x1, int y1)
        {
            tilesx = x1;
            tilesy = y1;
        }
        public Vector2 getVector()
        {
            return new Vector2(tilesx, tilesy);
        }
    }
}