using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class personagem
    {
         public int x;

        public int y;

        public Texture2D textura;

        public personagem(int x1, int y1)
        {

            x = x1;
            y = y1;
        }

        public Vector2 getVector()
        {
            return new Vector2(x, y);
        }

        public void gohorizotal(int pass)
        {
            x += pass;
        }

        public void govertical(int pass)
        {
            y += pass;
        }
    
    }

}
