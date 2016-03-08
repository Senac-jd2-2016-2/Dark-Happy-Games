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

        public static tiles normalbrick;

        public static Texture2D background;
        public static Rectangle fundo = new Rectangle(0, 0, 1000, 1000);
      


        public static void inicializar(ContentManager content)
        {
            hero.textura = content.Load<Texture2D>("vine");
            background = content.Load<Texture2D>("kermit");
             
         
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new personagem(10 + (i * 20), 14);
                enemy[i].textura = content.Load<Texture2D>("vine");
            }
            
        }
        
    }
}
