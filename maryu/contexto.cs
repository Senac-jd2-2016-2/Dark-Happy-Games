using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace maryu
{
    class Contexto
    {
        public static Personagem[] enemy = new Personagem[3];
        public static Personagem hero = new Personagem(15, 24);     
        public static Texture2D background;
        public static Rectangle fundo = new Rectangle(0, 0, 1000, 700);
        public static Rectangle tijolos = new Rectangle(500, 500, 100, 100);
        public static List<Tiles> tijolinhos = new List<Tiles>();
        //>>>>>------PARA CARREGAR AS IMAGENS N SHIT------<<<<<
        public static void inicializar(ContentManager content)
        {
            hero.textura = content.Load<Texture2D>("vine");
            background = content.Load<Texture2D>("kermit");
            Tiles.normalbrick = content.Load<Texture2D>("brick");
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new Personagem(10 + (i * 20), 14);
                enemy[i].textura = content.Load<Texture2D>("vine");
            }

            //--------------------------->depois perguntar pro calaça como colocar cada brick no lugar
            for (int i = 0; i < 5; i++)
            {
                Tiles rect = new Tiles(0, 200);
                tijolinhos.Add(rect);
                if (i == 1)
                {
                    Tiles rect1 = new Tiles(50, 200);
                    tijolinhos.Add(rect1);
                }
                if (i == 2)
                {
                    Tiles rect3 = new Tiles(100, 200);
                    tijolinhos.Add(rect3);
                }
                if (i == 3)
                {
                    Tiles rect2 = new Tiles(150, 200);
                    tijolinhos.Add(rect2);
                }
                if (i == 4)
                {
                    Tiles rect4 = new Tiles(300, 200);
                    tijolinhos.Add(rect4);
                }
                if (i == 5)
                {
                    Tiles rect5 = new Tiles(350, 200);
                    tijolinhos.Add(rect5);
                }
            }           
        }     
    }
}
