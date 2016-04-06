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
        public static Personagem hero = new Personagem(100, 500);
        public static Texture2D background;
        public static Fisica herogravy = new Fisica();
        public static Rectangle tijolos = new Rectangle(500, 500, 100, 100);
        public static List<Tiles> tijolinhos = new List<Tiles>();

        //>>>>>------PARA CARREGAR AS IMAGENS N SHIT------<<<<<
        public static void inicializar(ContentManager content)
        {
            Tiles.terratextura = content.Load<Texture2D>("CenarioRetoGrande");
            hero.herotextura = content.Load<Texture2D>("russo (1)");
            background = content.Load<Texture2D>("kermit");
            Tiles.normalbrick = content.Load<Texture2D>("brick");

            /*
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i] = new Personagem(10 + (i * 200), 14);
                enemy[i].herotextura = content.Load<Texture2D>("vine");
            }
            */

            for (int i = 0; i < 7; i++)
            {
                Tiles rect1 = new Tiles(500 + (i * 50), 300);
                tijolinhos.Add(rect1);


                /*
                Tiles rect = new Tiles(0, 600);
                tijolinhos.Add(rect);
                if (i == 1)
                {
                    Tiles rect1 = new Tiles(100, 600);
                    tijolinhos.Add(rect1);
                }
                if (i == 2)
                {
                    Tiles rect2 = new Tiles(200, 600);
                    tijolinhos.Add(rect2);
                }
                if (i == 3)
                {
                    Tiles rect3 = new Tiles(300, 600);
                    tijolinhos.Add(rect3);
                }
                if (i == 4)
                {
                    Tiles rect4 = new Tiles(400, 600);
                    tijolinhos.Add(rect4);
                }
                */


                ////==================
                //if (i == 5)
                //{
                //    Tiles rect5 = new Tiles(500, 400);
                //    tijolinhos.Add(rect5);
                //}
                //if (i == 6)
                //{
                //    Tiles rect6 = new Tiles(550, 400);
                //    tijolinhos.Add(rect6);
                //}
                //if (i == 7)
                //{
                //    Tiles rect7 = new Tiles(600, 400);
                //    tijolinhos.Add(rect7);
                //}
                //if (i == 8)
                //{
                //    Tiles rect8 = new Tiles(650, 400);
                //    tijolinhos.Add(rect8);
                //}
                //if (i == 9)
                //{
                //    Tiles rect9 = new Tiles(700, 500);
                //    tijolinhos.Add(rect9);
                //}
                //if (i == 10)
                //{
                //    Tiles rect10 = new Tiles(750, 500);
                //    tijolinhos.Add(rect10);
                //}
                //if (i == 11)
                //{
                //    Tiles rect11 = new Tiles(800, 500);
                //    tijolinhos.Add(rect11);
                //}
                ////==================

                /*
                if (i == 12)
                {
                    Tiles rect12 = new Tiles(850, 600);
                    tijolinhos.Add(rect12);
                }
                
                if (i == 13)
                {
                    Tiles rect13 = new Tiles(900, 600);
                    tijolinhos.Add(rect13);
                }
                
                if (i == 14)
                {
                    Tiles rect14 = new Tiles(1400, 600);
                    tijolinhos.Add(rect14);
                }
                if (i == 15)
                {
                    Tiles rect15 = new Tiles(1500, 600);
                    tijolinhos.Add(rect15);
                }
                if (i == 16)
                {
                    Tiles rect16 = new Tiles(1600, 600);
                    tijolinhos.Add(rect16);
                }
                if (i == 17)
                {
                    Tiles rect17 = new Tiles(1700, 600);
                    tijolinhos.Add(rect17);
                }
                if (i == 18)
                {
                    Tiles rect18 = new Tiles(1800, 600);
                    tijolinhos.Add(rect18);
                }
                if (i == 19)
                {
                    Tiles rect19 = new Tiles(1900, 600);
                    tijolinhos.Add(rect19);
                }
                if (i == 20)
                {
                    Tiles rect20 = new Tiles(2000, 600);
                    tijolinhos.Add(rect20);
                }
                if (i == 21)
                {
                    Tiles rect21 = new Tiles(2100, 600);
                    tijolinhos.Add(rect21);
                }
                if (i == 22)
                {
                    Tiles rect22 = new Tiles(2200, 600);
                    tijolinhos.Add(rect22);
                }
                if (i == 23)
                {
                    Tiles rect23 = new Tiles(2300, 600);
                    tijolinhos.Add(rect23);
                }
                if (i == 24)
                {
                    Tiles rect24 = new Tiles(2400, 600);
                    tijolinhos.Add(rect24);
                }
                if (i == 25)
                {
                    Tiles rect25 = new Tiles(2500, 600);
                    tijolinhos.Add(rect25);
                }
                if (i == 26)
                {
                    Tiles rect26 = new Tiles(2600, 600);
                    tijolinhos.Add(rect26);
                }
                */
            }
        }     
    }
}
