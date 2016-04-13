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
        public static Personagem hero = new Personagem(100, 300);
        public static Texture2D background;

        //>>>>>------PARA CARREGAR AS IMAGENS N SHIT------<<<<<
        public static void inicializar(ContentManager content)
        {
            Tiles.terratextura = content.Load<Texture2D>("CenarioRetoGrande");
            hero.herotextura = content.Load<Texture2D>("russo (1)");
            background = content.Load<Texture2D>("kermit");
            Tiles.normalbrick = content.Load<Texture2D>("brick");
            Personagem.enemitextura = content.Load<Texture2D>("vine");
        }     
    }
}
