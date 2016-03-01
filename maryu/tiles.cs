using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class tiles
    {
        public int tilesx;

        public int tilesy;

        public Texture2D tilesimagem;

        public tiles(int x1,int y1)
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
