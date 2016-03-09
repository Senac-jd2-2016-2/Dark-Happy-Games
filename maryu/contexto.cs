using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    class contexto
    {
        public static personagem[] enemy = new personagem[3];

        public static personagem hero = new personagem(15, 24);

        

        public static Texture2D background;
        public static Rectangle fundo = new Rectangle(0, 0, 1000, 1000);

        public static List<tiles> tijolinhos = new List<tiles>();

      


        public static void inicializar(ContentManager content)
        {
            hero.textura = content.Load<Texture2D>("vine");
            background = content.Load<Texture2D>("kermit");
            tiles.normalbrick =  content.Load<Texture2D>("brick");
           
             
         
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new personagem(10 + (i * 20), 14);
                enemy[i].textura = content.Load<Texture2D>("vine");
            }

            for (int i = 0; i < 5; i++)
            {
                tiles rect = new tiles(10, 100);
                tijolinhos.Add(rect);
                if (i == 1)
                {
                    tiles rect1 = new tiles(20, 200);
                    tijolinhos.Add(rect1);
                }
                if (i == 2)
                {
                    tiles rect3 = new tiles(30, 300);
                    tijolinhos.Add(rect3);
                }
                if (i == 3)
                {
                    tiles rect2 = new tiles(40, 400);
                    tijolinhos.Add(rect2);
                }
                if (i == 4)
                {
                    tiles rect4 = new tiles(50, 500);
                    tijolinhos.Add(rect4);
                }
            }

            
        }
        
    }
}
