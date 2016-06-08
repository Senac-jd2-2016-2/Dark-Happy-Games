using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maryu
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera camera;
        Mapa maapa1;
        Personagem C45510;
        Rectangle tank, historia2obj, menuobj, fimobj, clickerobj, historiacomeçoobj, background, findeljueguito;
        Rectangle[] chips = new Rectangle[5], mensagem = new Rectangle[4], plataformaobj = new Rectangle[4], blockersobj = new Rectangle[8];
        Texture2D chipsimagem, fundo, mensagemimagem, tankimagem, historiacomeçoimagem, historia2imagem, menuimagem, fimimagem, clickerimagem, plataformaimagem, gameoverscreen;
        Vector2 vidaobj;
        bool menu = true, game = false, historia2 = false, fim = false, gameover = false;
        bool[] historiacomeço = new bool[5], blockers = new bool[4];
        int timer = 240;
        public static int vida = 2;
        SpriteFont vidas;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            //>>>>>-------------------------------NOME-----------------------------<<<<<
            Window.Title = "The Robot";
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            //>>>>>>>>-----------------------INICIAR COISASS---------------------------<<<<<<<
            tank = new Rectangle(8070, 50, 89, 111);

            chips[0] = new Rectangle(1050, 700, 30, 30);
            chips[1] = new Rectangle(2050, 1000, 30, 30);
            chips[2] = new Rectangle(5050, 400, 30, 30);
            chips[3] = new Rectangle(7050, 700, 30, 30);
            chips[4] = new Rectangle(10050, 900, 30, 30);

            //for (int i = 0; i < blockers.Length; i++)
            //{
            //    blockers[i] = true;
            //}

            //for (int i = 0; i < plataformaobj.Length; i++)
            //{
            //    blockersobj[i] = new Rectangle((1050 * i), 600, 300, 77);
            //    plataformaobj[i] = new Rectangle((1050 * i), 900, 300, 77);
            //    blockersobj[i + 4] = new Rectangle((1050 * i), 1200, 300, 77);   
            //}

            maapa1 = new Mapa();
            C45510 = new Personagem(new Vector2(19000, 4800));

            for (int i = 0; i < historiacomeço.Length; i++)
            {
                historiacomeço[i] = false;
            }

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;
            camera = new Camera(GraphicsDevice.Viewport);
            //-----------------------------------------------gerar mapa (entre 0,1,2)--------------------------------------------
            maapa1.Generate(new int[,] {
               {5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,5},
               {6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5},
               {0,0,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0},
               {8,0,0,0,0,0,0,0,0,4,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,1,2,0,0,1,2,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0},
               {0,0,8,0,0,0,0,0,1,2,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,3,2,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,8,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,8,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,8,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,8,0,0,0,0,0,3,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,8,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,8,0,0,0,8,0,0,8,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,8,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {8,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
               {0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,1,2,2,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,0,0,0,3,1,2,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0},
               {0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,3,0,0},
               {0,0,0,2,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,2,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,1,2,0,0,0,0,0,0,0,0,0,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,2,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,3,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {8,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,3,2,0,0,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,5,5,5,5,5,5,5,5,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,5,5,0,0,5,5},
               {0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0},
               {0,0,0,0,0,0,0,8,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,1,2,1,2,1,2,1,3,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,0,0,8,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0},
               {0,0,1,2,1,3,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,3,2,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,1,0,0,8,0,0,0,0,8,0,0,0,8,8,8,8,8,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,3,1,2,0,0,0,0,0,8,0,0,0,0,8,0,0,0,0,0,3,2,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,2,3,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,8},
               {0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,0,8,8,8,0,0,8,8,8,8,8,8,8,8,8,8,8,8},
               {0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,0,0,8,8,8,8,8,8,8,8,8,8,8,8},
               {0,0,0,0,0,0,0,0,0,0,1,0,4,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,1,2,1,2,1,2,1,2,1,2},
               {0,0,0,0,0,0,0,0,0,1,3,0,4,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,1,2,1,2,1,2,1,2,1,2},
               {0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,0,0,0,0,0,0,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,0,0,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2},

            }, 77);//<<---------tamanho do map
            //------carregar imagens n shit----------
            C45510.LoadContent(Content);
            chipsimagem = Content.Load<Texture2D>("Varies/chip0");
            vidas = Content.Load<SpriteFont>("Vidas");
            fundo = Content.Load<Texture2D>("Fundo/Sol");
            mensagemimagem = Content.Load<Texture2D>("Mensagens/mensagem0");
            historiacomeçoimagem = Content.Load<Texture2D>("começos/começo1");
            tankimagem = Content.Load<Texture2D>("Varies/Barril");
            menuimagem = Content.Load<Texture2D>("Fundo/menu");
            clickerimagem = Content.Load<Texture2D>("Varies/clicker");
            gameoverscreen = Content.Load<Texture2D>("Fundo/GAME OVER");
            plataformaimagem = Content.Load<Texture2D>("Tijolos/moveble");

            for (int i = 0; i < chips.Length; i++)
            {
                mensagemimagem = Content.Load<Texture2D>("Varies/chip" + i);
            }
            //------carregar imagens n shit----------

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //---------------------------------------------------------------------------------menu--------------------------------------------------------------------
            if (menu)
            {
                menuobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                C45510.Posiçao.X = 19000;
                C45510.Posiçao.Y = 1000;
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    menu = false;
                    game = true;
                }
            }
            if (!menu)
            {
                menuobj = new Rectangle(0, 0, 0, 0);
            }
            //---------------------------------------------------------------------------------menu--------------------------------------------------------------------

            //-------------------------------------------------------------------HISTORIA COMEÇO--------------------------------------------------------------------
            //----------------------------------------------------historia parte1--------------------------------------------------------------------

            //if (historiacomeço[0])
            //{                  
            //    historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo1");

            //    --timer;
            //    historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200); 

            //    if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && timer <= 0)
            //    {
            //        timer = 240;
            //        historiacomeço[1] = true;
            //        historiacomeço[0] = false;
            //    }
            //}
            ////----------------------------------------------------historia parte2--------------------------------------------------------------------
            //if (historiacomeço[1])
            //{
            //    historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo2");
            //    clickerobj.Height = 0;
            //    clickerobj.Width = 0;

            //    --timer;
            //    historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

            //    if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && timer <= 0)
            //    {
            //        timer = 240;
            //        historiacomeço[2] = true;
            //        historiacomeço[1] = false;
            //    }
            //}
            ////----------------------------------------------------historia parte3--------------------------------------------------------------------
            //if (historiacomeço[2])
            //{
            //    historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo3");
            //    clickerobj.Height = 0;
            //    clickerobj.Width = 0;

            //    --timer;
            //    historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

            //    if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && timer <= 0)
            //    {
            //        timer = 240;
            //        historiacomeço[3] = true;
            //        historiacomeço[2] = false;
            //    }
            //}

            ////----------------------------------------------------historia parte4--------------------------------------------------------------------

            //if (historiacomeço[3])
            //{
            //    historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo4");
            //    clickerobj.Height = 0;
            //    clickerobj.Width = 0;

            //    --timer;
            //    historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

            //    if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && timer <= 0)
            //    {
            //        timer = 240;
            //        historiacomeço[4] = true;
            //        historiacomeço[3] = false;
            //    }
            //}

            ////----------------------------------------------------historia parte5--------------------------------------------------------------------

            //if (historiacomeço[4])
            //{
            //    historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo5");

            //    --timer;
            //    historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

            //    if (timer <= 0)
            //    {
            //        clickerobj = new Rectangle((int)-camera.Transform.Translation.X + 1600, (int)-camera.Transform.Translation.Y + 900, 30, 30);
            //    }

            //    if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && timer <= 0)
            //    {
            //        timer = 240;
            //        game = true;
            //        historiacomeço[4] = false;
            //    }
            //}
            //if (!historiacomeço[4])
            //{
            //    clickerobj = new Rectangle(0, 0, 0, 0);
            //}

            //-------------------------------------------------------------------HISTORIA COMEÇO--------------------------------------------------------------------

            //---------------------------------------------------------------------GAME--------------------------------------------------------------------------------


            //------------criar mensagens----------------------------------------
            for (int i = 0; i < chips.Length; i++)
            {
                if (C45510.Rectangle.Intersects(chips[i]))
                {
                    --timer;
                    mensagem[i] = new Rectangle(chips[i].X - 400, chips[i].Y - 400, 450, 450);
                    mensagemimagem = Content.Load<Texture2D>("Mensagens/mensagem" + i);
                    if (timer <= 0)
                    {
                        mensagem[i] = new Rectangle(0, 0, 0, 0);
                    }
                }
            }

            vidaobj = new Vector2(background.X, background.Y);
            if (vida <= 0)
            {
                gameover = true;
                game = false;
            }
            if(C45510.Rectangle.Intersects(tank))
            {
                gameover = true;
                game = false;
            }
            //------------criar mensagens----------------------------------------

            //------------colisao do russo sobre os tijolos e camera-------------
            if (game)
            {

                C45510.Update(gameTime);
            }
            if (!game)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    C45510.Posiçao.X = C45510.Posiçao.X - 3;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    C45510.Posiçao.X = C45510.Posiçao.X + 3;
                }
                else
                {
                    C45510.Posiçao.X = 0f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    C45510.Posiçao.Y += 9f;
                    C45510.Posiçao.Y = +12f;
                }
            }
            foreach (CollisionTiles tile in maapa1.CollisionTile)
            {
                C45510.Collision(tile.Rectangle, maapa1.Width, maapa1.Height);
                camera.Update(C45510.Posiçao, maapa1.Width, maapa1.Height);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                game = false;
                menu = true;
            }

            //------------colisao do russo sobre os tijolos e camera-------------

            //------------------------------------plataformas moveis------------------------------------------------------------------

            //for (int i = 0; i < plataformaobj.Length; i++)
            //{
            //    if (C45510.Rectangle.Intersects(plataformaobj[i]))
            //    {
            //        C45510.Posiçao.Y -= 10.3f;
            //        C45510.jump = false;
            //    }
            //}
            //for (int i = 0; i < plataformaobj.Length; i++)
            //{
            //    if (plataformaobj[i].Intersects(blockersobj[i]))
            //    {
            //        blockers[i] = false;
            //    }
            //    if (plataformaobj[i].Intersects(blockersobj[i+4]))
            //    {
            //        blockers[i] = true;
            //    }

            //    if (blockers[i])
            //    {
            //        plataformaobj[i].Y -= 2;
            //    }
            //    if (!blockers[i])
            //    {
            //        plataformaobj[i].Y += 2;
            //    }    
            //}

            //---------------------------------------------------------------------GAME--------------------------------------------------------------------------------

            //---------------------------------------------------------------------gameover--------------------------------------------------------------
            if(gameover)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    gameover = false;
                    menu = true;
                }
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            if (menu)
            {
                spriteBatch.Draw(menuimagem, menuobj, Color.White);
            }
            for (int i = 0; i < historiacomeço.Length; i++)
            {
                if (historiacomeço[i])
                {
                    spriteBatch.Draw(historiacomeçoimagem, historiacomeçoobj, Color.White);
                    spriteBatch.Draw(clickerimagem, clickerobj, Color.White);
                }
            }

            if (game)
            {
                background = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1800);
                spriteBatch.Draw(fundo, background, Color.White);
                maapa1.Draw(spriteBatch);
                spriteBatch.DrawString(vidas, "Vidas: " + vida, vidaobj, Color.Black);

                for (int i = 0; i < chips.Length; i++)
                {
                    spriteBatch.Draw(chipsimagem, chips[i], Color.White);
                }
                for (int i = 0; i < mensagem.Length; i++)
                {
                    spriteBatch.Draw(mensagemimagem, mensagem[i], Color.White);
                }
                C45510.Draw(spriteBatch);
                spriteBatch.Draw(tankimagem, tank, Color.White);
            }

            if (gameover)
            {
                findeljueguito = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height + 100);
                spriteBatch.Draw(gameoverscreen, findeljueguito, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
