using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        
        public static Rectangle tijolos = new Rectangle(0, 0, 100, 100);
        public static List<tiles> tijolinhos = new List<tiles>();

        public Texture2D textura;

        public tiles(int x1,int y1)
        {
            tilesx = x1;
            tilesy = y1;
        }
        public Vector2 getVector()
        {
            return new Vector2(tilesx, tilesy);
        }

        void inicializarLista(ContentManager content)
        {
        
            
            for (int i = 0; i < 5; i++)
            {
                tiles rect = new tiles(10,10);
                tijolinhos.Add(rect);
                if (i == 1)
                {
                    tiles rect1 = new tiles(20, 20);
                    tijolinhos.Add(rect1);
                }
                if (i == 2)
                {
                    tiles rect3 = new tiles(30, 30);
                    tijolinhos.Add(rect3);
                }
                if (i == 3)
                {
                    tiles rect2 = new tiles(40, 40);
                    tijolinhos.Add(rect2);
                }
                if (i == 4)
                {
                    tiles rect4 = new tiles(10, 10);
                    tijolinhos.Add(rect4);
                }
            }
        }
         
    }
}
