﻿using Microsoft.Xna.Framework;
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
        Song backgroundsong;
        Mapa maapa1, maapa2;
        Personagem C45510;
        Rectangle tankobj, historiafinalobj, menuobj, clickerobj, historiacomeçoobj, backgroundobj, gameoverobj, manuelobj, pauseobj, fimobj;
        Rectangle[] chipsobj = new Rectangle[11], mensagemobj = new Rectangle[11], hearthobj = new Rectangle[2];
        Texture2D chipsimagem, backgroundimagem, mensagemimagem, tankimagem, historiacomeçoimagem, historiafinalimagem, menuimagem, clickerimagem, gameoverimagem, manuelimagem, pauseimagem, fimimagem;
        Texture2D[] hearthimagem = new Texture2D[2];
        Vector2 vidavector;
        public static bool gamebool = false, pausebool = false;
        bool menubool = true, manuelbool = false, gameoverbool = false, fimbool = false, fase1bool = false, fase2bool = true, songstartbool = false;
        bool[] historiacomeçobool = new bool[5], historiafinalbool = new bool[5], mensagembool = new bool[11];
        int timer = 30;
        public static SoundEffect clickeffect, ironeffect, walkingeffect, porta1effect, porta2effect;
        public static int vida = 2;
        SpriteFont vidasfont;

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
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height - 60;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            //>>>>>>>>-----------------------INICIAR COISASS---------------------------<<<<<<<

            tankobj = new Rectangle(8070, 50, 89, 111);

            chipsobj[0] = new Rectangle(1050, 700, 30, 30);
            chipsobj[1] = new Rectangle(2050, 1000, 30, 30);
            chipsobj[2] = new Rectangle(5050, 400, 30, 30);
            chipsobj[3] = new Rectangle(7050, 700, 30, 30);
            chipsobj[4] = new Rectangle(10050, 900, 30, 30);
            chipsobj[5] = new Rectangle(200, 2900, 30, 30);

            maapa2 = new Mapa();
            maapa1 = new Mapa();
            C45510 = new Personagem(new Vector2(19000, 4800));

            for (int i = 0; i < historiacomeçobool.Length; i++)
            {
                historiacomeçobool[i] = false;
            }

            


            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;

            camera = new Camera(GraphicsDevice.Viewport);

            //-----------------------------------------------gerar mapa2--------------------------------------------

            maapa2.Generate(new int[,] {
               {5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,5},
               {6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5},
               {0,0,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0},
               {8,0,0,0,0,0,0,0,0,4,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,1,2,0,0,1,2,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0},
               {0,0,8,0,0,0,0,0,1,2,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,3,2,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,8,0,8,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,8,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0},
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
               {5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {4,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {4,0,5,5,0,0,1,2,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,1,0,0,8,0,0,0,0,8,0,0,0,8,8,8,8,8,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {4,0,4,5,5,0,0,0,0,8,0,0,0,0,0,8,0,0,0,0,0,3,2,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {5,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,2,3,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,8},
               {5,5,4,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,0,8,8,8,0,0,8,8,8,8,8,8,8,8,8,8,8,8},
               {5,5,5,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,0,0,8,8,8,8,8,8,8,8,8,8,8,8},
               {0,0,0,0,0,0,0,0,0,0,1,0,4,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,1,2,1,2,1,2,1,2,1,2},
               {0,0,0,0,0,0,0,0,0,1,3,0,4,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,1,2,1,2,1,2,1,2,1,2},
               {1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

            }, 77);//<<---------tamanho do map

            //-----------------------------------------------gerar mapa1--------------------------------------------

            maapa1.Generate(new int[,] {
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5},
               {5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0},
               {0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,5,5,0,0,0,0,0,0,5,0,0,0,0},
               {0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,5,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0,5,5,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,5,5,5,5,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,5,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,5,5,5,0,0,5,5,5,5,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,5,5,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,5,0,0,0,0,5,0,0,0,0,0,0,5,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,5,5,5},
               {5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0},
               {0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,5,5,0,0,5,5,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5},
               {0,0,0,5,5,0,0,0,0,5,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,4,4,4},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5},
               {5,5,5,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,2},
               {0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2},
               {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,0,5,5,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2,1,2},

            }, 77);

            //------carregar imagens n shit----------

            C45510.LoadContent(Content);
            chipsimagem = Content.Load<Texture2D>("Varies/chip0");
            vidasfont = Content.Load<SpriteFont>("Vidas");
            hearthimagem[0] = Content.Load<Texture2D>("Varies/S1");
            hearthimagem[1] = Content.Load<Texture2D>("Varies/S1");

            //backgroundsong = Content.Load<Song>("The Desolate Hope OST - Menu");
            //MediaPlayer.IsRepeating = true;
            
            backgroundimagem = Content.Load<Texture2D>("Fundo/Sol");
            mensagemimagem = Content.Load<Texture2D>("Mensagens/texto0");
            historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo1");
            tankimagem = Content.Load<Texture2D>("Varies/Barril");
            menuimagem = Content.Load<Texture2D>("Menus, Telas e Afins/menu");
            clickerimagem = Content.Load<Texture2D>("Varies/clicker");
            gameoverimagem = Content.Load<Texture2D>("Menus, Telas e Afins/gameover");
            fimimagem = Content.Load<Texture2D>("Menus, Telas e Afins/Fimdejogo");
            manuelimagem = Content.Load<Texture2D>("Menus, Telas e Afins/howtoplay");
            pauseimagem = Content.Load<Texture2D>("Menus, Telas e Afins/Pause");

            //click = Content.Load<SoundEffect>("Sons/SFX/clique");
            //walking = Content.Load<SoundEffect>("Sons/SFX/Robo andando");

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

            if (menubool)
            {
                --timer;
                menuobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                C45510.Posiçao.X = 100;
                C45510.Posiçao.Y = 2900;
                vida = 2;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer <= 0)
                {
                    menubool = false;
                    timer = 30;
                    historiacomeçobool[0] = false;
                    gamebool = true;
                    fase2bool = true;
                }
            }

            if (!menubool)
            {
                menuobj = new Rectangle(0, 0, 0, 0);
            }

            //---------------------------------------------------------------------------------menu--------------------------------------------------------------------



            //-------------------------------------------------------------------HISTORIA COMEÇO-------------------------------------------------------------<<<<<<<<<

            //----------------------------------------------------historia parte1--------------------------------------------------------------------

            if (historiacomeçobool[0])
            {
                historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo1");
                --timer;
                historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiacomeçobool[1] = true;
                    historiacomeçobool[0] = false;
                }
            }

            //----------------------------------------------------historia parte2--------------------------------------------------------------------

            if (historiacomeçobool[1])
            {
                historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo2");
                --timer;
                historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiacomeçobool[2] = true;
                    historiacomeçobool[1] = false;
                }
            }

            //----------------------------------------------------historia parte3--------------------------------------------------------------------

            if (historiacomeçobool[2])
            {
                historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo3");
                --timer;
                historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiacomeçobool[3] = true;
                    historiacomeçobool[2] = false;
                }
            }

            //----------------------------------------------------historia parte4--------------------------------------------------------------------

            if (historiacomeçobool[3])
            {
                historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo4");
                --timer;
                historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiacomeçobool[4] = true;
                    historiacomeçobool[3] = false;
                }
            }

            //----------------------------------------------------historia parte5--------------------------------------------------------------------

            if (historiacomeçobool[4])
            {
                historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo5");
                --timer;
                historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if (timer <= 0)
                {
                    clickerobj = new Rectangle((int)-camera.Transform.Translation.X + 1600, (int)-camera.Transform.Translation.Y + 900, 30, 30);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    manuelbool = true;
                    historiacomeçobool[4] = false;
                }
            }

            if (!historiacomeçobool[4])
            {
                clickerobj = new Rectangle(0, 0, 0, 0);
            }

            //-------------------------------------------------------------------HISTORIA COMEÇO-------------------------------------------------------------<<<<<<

            //-------------------------------------------------------------------manual-------------------------------------------------------------------------

            if (manuelbool)
            {
                --timer;
                manuelobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                C45510.Posiçao.X = 100;
                C45510.Posiçao.Y = 2900;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 120;
                    gamebool = true;
                    fase2bool = true;
                    manuelbool = false;
                }
            }

            //-------------------------------------------------------------------manual-------------------------------------------------------------------------

            //---------------------------------------------------------------------GAME------------------------------------------------------------------------<<<<<<<

            //---------------------------------------------------------------fase1-----------------------------------------------------------------
            
            if(fase1bool)
            {
                //------------criar mensagens----------------------------------------
                for (int i = 0; i < 5; i++)
                {
                    if (C45510.Rectangle.Intersects(chipsobj[i]))
                    {
                        mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                        mensagemimagem = Content.Load<Texture2D>("Mensagens/texto" + i);

                        if (!C45510.Rectangle.Intersects(chipsobj[i]))
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                            {
                                mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 0, 0);
                            }
                        }

                        //click.Play();
                    }
                }
                //------------criar mensagens----------------------------------------





                vidavector = new Vector2(backgroundobj.X, backgroundobj.Y);


                if (vida <= 0)
                {
                    gameoverbool = true;
                    gamebool = false;
                }

                if (C45510.Rectangle.Intersects(tankobj))
                {
                    fimbool = true;
                    gamebool = false;
                }

                



                //------------colisao do russo sobre os tijolos e camera mapa1-------------


                if (gamebool)
                {
                    C45510.Update(gameTime);
                }

                foreach (CollisionTiles tile in maapa1.CollisionTile)
                {
                    C45510.Collision(tile.Rectangle, maapa1.Width, maapa1.Height);
                    camera.Update(C45510.Posiçao, maapa1.Width, maapa1.Height);
                }
                //------------colisao do russo sobre os tijolos e camera mapa1-------------
            }

            //---------------------------------------------------------------fase1-----------------------------------------------------------------

            //---------------------------------------------------------------fase2-----------------------------------------------------------------

            if (fase2bool)
            {
                //------------criar mensagens----------------------------------------

                for (int i = 0; i < chipsobj.Length; i++)
                {
                    if(C45510.Rectangle.Intersects(chipsobj[i]))
                    {
                        mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                        mensagemimagem = Content.Load<Texture2D>("Mensagens/texto" + i);     

                        //click.Play();
                    }
                    if (!C45510.Rectangle.Intersects(chipsobj[i]))
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 0, 0);
                        }
                    }
                }

                //------------criar mensagens----------------------------------------



                vidavector = new Vector2(backgroundobj.X, backgroundobj.Y);


                for (int i = 0; i < hearthobj.Length; i++)
                {
                    hearthobj[i] = new Rectangle((int)-camera.Transform.Translation.X + i*85, (int)-camera.Transform.Translation.Y + 69, 80, 69);
                }

                if (vida == 2)
                {
                    hearthimagem[1] = Content.Load<Texture2D>("Varies/S1");
                }
                if(vida == 1)
                {
                    hearthimagem[1] = Content.Load<Texture2D>("Varies/S2");
                }

                if (vida <= 0)
                {
                    gameoverbool = true;
                    gamebool = false;
                }

                if (C45510.Rectangle.Intersects(tankobj))
                {
                    historiafinalbool[0] = true;
                    timer = 30;
                    gamebool = false;
                }

                

                //------------colisao do russo sobre os tijolos e camera mapa2-------------

                if (gamebool)
                {
                    C45510.Update(gameTime);
                }

                foreach (CollisionTiles tile in maapa2.CollisionTile)
                {
                    C45510.Collision(tile.Rectangle, maapa2.Width, maapa2.Height);
                    camera.Update(C45510.Posiçao, maapa2.Width, maapa2.Height);
                }

                //------------colisao do russo sobre os tijolos e camera mapa2-------------
            }

            //---------------------------------------------------------------fase2-----------------------------------------------------------------

            //-------------------------------------------------------INICIAR A MUSICA-------------------------------------------------------
            
            //if (!songstart)
            //{
            //    MediaPlayer.Play(backgroundsong);
            //    songstart = true; 
            //}

            //-------------------------------------------------------INICIAR A MUSICA-------------------------------------------------------
      

            //--------------------------------pause------------------------------

            if (pausebool)
            {
                pauseobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if (Keyboard.GetState().IsKeyDown(Keys.H))
                {
                    menubool = true;
                    pausebool = false;
                    gamebool = false;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.G))
                {
                    pausebool = false;
                }
            }

            //--------------------------------pause------------------------------

            //---------------------------------------------------------------------GAME----------------------------------------------------------------------<<<<<<<<<

            //------------------------------------------------------------------HISTORIA FINAL-----------------------------------------------------------------<<<<<<<<<

            //----------------------------------------------------historia parte1--------------------------------------------------------------------

            if (historiafinalbool[0])
            {
                historiafinalimagem = Content.Load<Texture2D>("Começos/começo1");
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiafinalbool[1] = true;
                    historiafinalbool[0] = false;
                }
            }

            //----------------------------------------------------historia parte2--------------------------------------------------------------------

            if (historiafinalbool[1])
            {
                historiafinalimagem = Content.Load<Texture2D>("Começos/começo1");
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiafinalbool[2] = true;
                    historiafinalbool[1] = false;
                }
            }

            //----------------------------------------------------historia parte3--------------------------------------------------------------------

            if (historiafinalbool[2])
            {
                historiafinalimagem = Content.Load<Texture2D>("Começos/começo1");
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiafinalbool[3] = true;
                    historiafinalbool[2] = false;
                }
            }

            //----------------------------------------------------historia parte4--------------------------------------------------------------------

            if (historiafinalbool[3])
            {
                historiafinalimagem = Content.Load<Texture2D>("Começos/começo1");
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    historiafinalbool[4] = true;
                    historiafinalbool[3] = false;
                }
            }

            //----------------------------------------------------historia parte5--------------------------------------------------------------------

            if (historiafinalbool[4])
            {
                historiafinalimagem = Content.Load<Texture2D>("Começos/começo1");
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    fimbool = true;
                    historiafinalbool[4] = false;
                }
            }

            //------------------------------------------------------------------HISTORIA FINAL-----------------------------------------------------------------<<<<<<<<<

            //---------------------------------------------------------------------gameover----------------------------------------------------------------------------

            if (gameoverbool)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameoverbool = false;
                    C45510.Posiçao.X = 100;
                    C45510.Posiçao.Y = 2900;
                    menubool = true;
                }
            }

            //---------------------------------------------------------------------gameover----------------------------------------------------------------------------

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            if (menubool)
            {
                spriteBatch.Draw(menuimagem, menuobj, Color.White);
            }

            for (int i = 0; i < historiacomeçobool.Length; i++)
            {
                if (historiacomeçobool[i])
                {
                    spriteBatch.Draw(historiacomeçoimagem, historiacomeçoobj, Color.White);
                    spriteBatch.Draw(clickerimagem, clickerobj, Color.White);
                }
            }

            if (manuelbool)
            {
                spriteBatch.Draw(manuelimagem, manuelobj, Color.White);
            }

            if (gamebool)
            {
                if(fase1bool)
                {
                    backgroundobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                    spriteBatch.Draw(backgroundimagem, backgroundobj, Color.White);
                    maapa1.Draw(spriteBatch);

                    for (int i = 0; i < chipsobj.Length; i++)
                    {
                        spriteBatch.Draw(chipsimagem, chipsobj[i], Color.White);
                    }
                    C45510.Draw(spriteBatch);
                    for (int i = 0; i < mensagemobj.Length; i++)
                    {
                        spriteBatch.Draw(mensagemimagem, mensagemobj[i], Color.White);
                    }

                    spriteBatch.Draw(tankimagem, tankobj, Color.White);
                }

                if(fase2bool)
                {
                    backgroundobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                    spriteBatch.Draw(backgroundimagem, backgroundobj, Color.White);
                    maapa2.Draw(spriteBatch);

                    for (int i = 0; i < chipsobj.Length; i++)
                    {
                        spriteBatch.Draw(chipsimagem, chipsobj[i], Color.White);
                    }
                    C45510.Draw(spriteBatch);
                    for (int i = 0; i < mensagemobj.Length; i++)
                    {
                        spriteBatch.Draw(mensagemimagem, mensagemobj[i], Color.White);
                    }

                    spriteBatch.Draw(tankimagem, tankobj, Color.White);
                }
                
                spriteBatch.DrawString(vidasfont, "Vidas: ", vidavector, Color.Black);

                for (int i = 0; i < hearthobj.Length; i++)
                {
                    spriteBatch.Draw(hearthimagem[i], hearthobj[i], Color.White);     
                }
                

                if (pausebool)
                {
                    spriteBatch.Draw(pauseimagem, pauseobj, Color.White);
                }
            }

            if (gameoverbool)
            {
                gameoverobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                spriteBatch.Draw(gameoverimagem, gameoverobj, Color.White);
            }

            for (int i = 0; i < historiafinalbool.Length; i++)
            {
                if (historiafinalbool[i])
                {
                    spriteBatch.Draw(historiafinalimagem, historiafinalobj, Color.White);
                    spriteBatch.Draw(clickerimagem, clickerobj, Color.White);
                }
            }

            if (fimbool)
            {
                fimobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 1800, 1600);
                spriteBatch.Draw(fimimagem, fimobj, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}