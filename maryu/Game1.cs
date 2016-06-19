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
        Song backgroundsong;
        Mapa maapa;
        Personagem C45510;
        Rectangle tankobj, historiafinalobj, menuobj, clickerobj, historiacomeçoobj, backgroundobj, gameoverobj, manuelobj, pauseobj, fimobj, chiphudobj, vidahudobj, amensagemobj, creditosobj;
        Texture2D chipsimagem, backgroundimagem, mensagemimagem, tankimagem, menuimagem, clickerimagem, gameoverimagem, manuelimagem, pauseimagem, fimimagem, amensagemimagem, chiphudimagem, vidahudimagem;
        int timer = 30, chipsget = 0;
        bool menubool = true, manuelbool = false, gameoverbool = false, fimbool = false, fase1bool = true, songstartbool = true;
        SoundEffect clickeffect;
        SpriteFont hudfont;
        Rectangle[] chipsobj = new Rectangle[11], mensagemobj = new Rectangle[11], hearthobj = new Rectangle[2];
        Texture2D[] hearthimagem = new Texture2D[2], historiacomeçoimagem = new Texture2D[8], historiafinalimagem = new Texture2D[6], creditosimagem = new Texture2D[2];
        bool[] historiacomeçobool = new bool[8], historiafinalbool = new bool[6], mensagembool = new bool[11], creditosbool = new bool[2];
        public static bool gamebool = false, pausebool = false, personmovebool = false;
        public static int vida = 2;
        

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

            chipsobj[0] = new Rectangle(5450, 2000, 30, 30);
            chipsobj[1] = new Rectangle(3800, 2900, 30, 30);
            chipsobj[2] = new Rectangle(6000, 250, 30, 30);
            chipsobj[3] = new Rectangle(5545, 2800, 30, 30);
            chipsobj[4] = new Rectangle(8000, 850, 30, 30);
            chipsobj[5] = new Rectangle(300, 150, 30, 30);
            chipsobj[6] = new Rectangle(3800, 1400, 30, 30);
            chipsobj[7] = new Rectangle(1800, 1900, 30, 30);
            chipsobj[8] = new Rectangle(950, 2650, 30, 30);
            chipsobj[9] = new Rectangle(2680, 2700, 30, 30);
            chipsobj[10] = new Rectangle(8070, 2550, 30, 30);

            maapa = new Mapa();
            C45510 = new Personagem(new Vector2(19000, 4800));

            for (int i = 0; i < historiacomeçobool.Length; i++)
            {
                historiacomeçobool[i] = false;
            }
            for (int i = 0; i < historiafinalbool.Length; i++)
            {
                historiafinalbool[i] = false;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;

            camera = new Camera(GraphicsDevice.Viewport);

            //-----------------------------------------------gerar mapa2--------------------------------------------

            maapa.Generate(new int[,] {
               {5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,5},
               {6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5},
               {0,0,0,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,1,2,1,2,1,2,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,4,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,1,2,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,3,2,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,8,0,8,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,8,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,8,0,0,0,0,0,3,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,8,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,8,0,0,0,8,0,0,8,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,8,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0},
               {2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,5},
               {0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,1,2,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,5,5},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,3,1,2,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0},
               {0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,0,4,0},
               {0,0,0,2,1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,4,0},
               {0,0,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,2,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,5,5,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,4,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,5,5,5,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,4,0},
               {8,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,5,5,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,4,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,5,5,5,5,5,5,5,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,5,5},
               {0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0},
               {0,0,0,0,0,0,0,8,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,0,0,1,2,1,2,1,2,1,3,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,2,0,0,0,0,0,0,0,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,0,0,0,0,8,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0},
               {0,0,1,2,1,3,0,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0},
               {5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {4,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {4,0,5,5,0,0,1,2,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,1,0,0,8,0,0,0,0,8,0,0,0,8,8,8,8,8,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {4,0,4,5,5,0,0,0,0,8,0,0,0,0,0,8,0,0,0,0,0,3,2,0,0,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {5,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,2,3,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,5,5,5,5,5},
               {5,5,4,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,0,0,0,0,0,0,0,0,0,0,0,8,8,8,0,0,8,8,8,8,8,8,8,8,8,8,8,8},
               {5,5,5,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,0,0,8,8,8,8,8,8,8,8,8,8,8,8},
               {0,0,0,0,0,0,0,0,0,0,1,0,4,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,1,2,1,2,1,2,1,2,1,2},
               {0,0,0,0,0,0,0,0,0,1,3,0,4,0,3,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,8,8,8,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,8,8,1,2,1,2,1,2,1,2,1,2},
               {1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,1,2,1,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2},

            }, 77);//<<---------tamanho do map

            //------carregar imagens n shit----------

            C45510.LoadContent(Content);
            chipsimagem = Content.Load<Texture2D>("Varies/chip");
            chiphudimagem = Content.Load<Texture2D>("Varies/chips");
            vidahudimagem = Content.Load<Texture2D>("Varies/vida");
            hudfont = Content.Load<SpriteFont>("Vidas");
            hearthimagem[0] = Content.Load<Texture2D>("Varies/S1");
            hearthimagem[1] = Content.Load<Texture2D>("Varies/S1");
            amensagemimagem = Content.Load<Texture2D>("Varies/mensagem2");
            backgroundimagem = Content.Load<Texture2D>("Fundo/Fabrica");
            mensagemimagem = Content.Load<Texture2D>("Mensagens/texto0");

            for (int i = 0; i < historiacomeçoimagem.Length; i++)
            {
                historiacomeçoimagem[i] = Content.Load<Texture2D>("Começos/Começo" + (i + 1));
            }

            for (int i = 0; i < historiafinalimagem.Length; i++)
            {
                historiafinalimagem[i] = Content.Load<Texture2D>("Finais/Final" + (i + 1));
            }

            for (int i = 0; i < creditosimagem.Length; i++)
            {
                creditosimagem[i] = Content.Load<Texture2D>("Menus, Telas e Afins/creditos" + (i+1));
            }

            tankimagem = Content.Load<Texture2D>("Varies/Barril");
            menuimagem = Content.Load<Texture2D>("Menus, Telas e Afins/menu");
            clickerimagem = Content.Load<Texture2D>("Varies/clicker");
            gameoverimagem = Content.Load<Texture2D>("Menus, Telas e Afins/gameover");
            fimimagem = Content.Load<Texture2D>("Menus, Telas e Afins/Fimdejogo");
            manuelimagem = Content.Load<Texture2D>("Menus, Telas e Afins/howtoplay");
            pauseimagem = Content.Load<Texture2D>("Menus, Telas e Afins/Pause");
            clickeffect = Content.Load<SoundEffect>("Sons/SFX/clique");
            backgroundsong = Content.Load<Song>("Sons/Disintegratingwav.wav");
            MediaPlayer.IsRepeating = true;

            //------carregar imagens n shit----------

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //---------------------------------------------------------------------------------menu--------------------------------------------------------------------          

            if (songstartbool)
            {
                MediaPlayer.Play(backgroundsong);
                songstartbool = false;
            }

            if (menubool)
            {
                --timer;
                menuobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
                C45510.Posiçao.X = 2350;
                C45510.Posiçao.Y = 1000;
                chipsget = 0;
                vida = 2;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer <= 0)
                {
                    timer = 30;
                    historiacomeçobool[0] = true;
                    menubool = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) && timer < 30)
                    Exit();
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
                --timer;
                historiacomeçoobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[1] = true;
                    historiacomeçobool[0] = false;
                }
            }

            //----------------------------------------------------historia parte2--------------------------------------------------------------------

            if (historiacomeçobool[1])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[2] = true;
                    historiacomeçobool[1] = false;
                }
            }

            //----------------------------------------------------historia parte3--------------------------------------------------------------------

            if (historiacomeçobool[2])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[3] = true;
                    historiacomeçobool[2] = false;
                }
            }

            //----------------------------------------------------historia parte4--------------------------------------------------------------------

            if (historiacomeçobool[3])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[4] = true;
                    historiacomeçobool[3] = false;
                }
            }

            //----------------------------------------------------historia parte5--------------------------------------------------------------------

            if (historiacomeçobool[4])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[5] = true;
                    historiacomeçobool[4] = false;
                }
            }

            //----------------------------------------------------historia parte6--------------------------------------------------------------------

            if (historiacomeçobool[5])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[6] = true;
                    historiacomeçobool[5] = false;
                }
            }

            //----------------------------------------------------historia parte7--------------------------------------------------------------------

            if (historiacomeçobool[6])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiacomeçobool[7] = true;
                    historiacomeçobool[6] = false;
                }
            }

            //----------------------------------------------------historia parte8--------------------------------------------------------------------

            if (historiacomeçobool[7])
            {
                --timer;

                if (timer <= 0)
                {
                    clickerobj = new Rectangle((int)-camera.Transform.Translation.X + 1600, (int)-camera.Transform.Translation.Y + 900, 30, 30);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    manuelbool = true;
                    historiacomeçobool[7] = false;
                }

                if (!historiacomeçobool[7])
                {
                    clickerobj = new Rectangle(0, 0, 0, 0);
                }
            }

            //-------------------------------------------------------------------HISTORIA COMEÇO-------------------------------------------------------------<<<<<<

            //-------------------------------------------------------------------manual-------------------------------------------------------------------------

            if (manuelbool)
            {
                --timer;
                manuelobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

                C45510.Posiçao.X = 100;
                C45510.Posiçao.Y = 2900;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    gamebool = true;
                    fase1bool = true;
                    manuelbool = false;
                }
            }

            //-------------------------------------------------------------------manual-------------------------------------------------------------------------

            //---------------------------------------------------------------------GAME------------------------------------------------------------------------<<<<<<<

            //---------------------------------------------------------------fase1-----------------------------------------------------------------

            if (fase1bool)
            {
                //------------criar mensagens----------------------------------------
                
                for (int i = 0; i < chipsobj.Length; i++)
                {
                    if(C45510.Rectangle.Intersects(chipsobj[i]))
                    {
                        mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
                        mensagemimagem = Content.Load<Texture2D>("Mensagens/texto" + i);
                        chipsget++;
                        clickeffect.Play();
                        personmovebool = false;
                        chipsobj[i] = new Rectangle(0, 0, 0, 0);
                    }

                    if (!C45510.Rectangle.Intersects(chipsobj[i]))
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            personmovebool = true;
                            mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 0, 0);
                        }
                    }
                }

                //------------criar mensagens----------------------------------------

                //---------------------HUD---------------

                if (vida == 2)
                {
                    hearthimagem[1] = Content.Load<Texture2D>("Varies/S1");
                }
                if(vida == 1)
                {
                    hearthimagem[1] = Content.Load<Texture2D>("Varies/S2");
                }

                //---------------------HUD---------------

                if(chipsget == chipsobj.Length)
                {
                    amensagemimagem = Content.Load<Texture2D>("Varies/mensagem1");
                    tankobj = new Rectangle(8070, 50, 89, 111);
                }
   
                if (vida <= 0)
                {
                    gameoverbool = true;
                    gamebool = false;
                }

                if (C45510.Rectangle.Intersects(tankobj))
                {
                    historiafinalbool[0] = true;
                    tankobj = new Rectangle(0, 0, 0, 0);
                    timer = 30;
                    fase1bool = false;
                    gamebool = false;
                    
                }

                //------------colisao do russo sobre os tijolos e camera mapa2-------------

                if (gamebool)
                {
                    C45510.Update(gameTime);
                    
                }

                foreach (CollisionTiles tile in maapa.CollisionTile)
                {
                    C45510.Collision(tile.Rectangle, maapa.Width, maapa.Height);
                    camera.Update(C45510.Posiçao, maapa.Width, maapa.Height);
                }

                //------------colisao do russo sobre os tijolos e camera mapa2-------------
            }

            //---------------------------------------------------------------fase2-----------------------------------------------------------------


            //--------------------------------pause------------------------------

            if (pausebool)
            {
                pauseobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

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
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiafinalbool[1] = true;
                    historiafinalbool[0] = false;
                }
            }

            //----------------------------------------------------historia parte2--------------------------------------------------------------------

            if (historiafinalbool[1])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiafinalbool[2] = true;
                    historiafinalbool[1] = false;
                }
            }

            //----------------------------------------------------historia parte3--------------------------------------------------------------------

            if (historiafinalbool[2])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiafinalbool[3] = true;
                    historiafinalbool[2] = false;
                }
            }

            //----------------------------------------------------historia parte4--------------------------------------------------------------------

            if (historiafinalbool[3])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiafinalbool[4] = true;
                    historiafinalbool[3] = false;
                }
            }

            //----------------------------------------------------historia parte5--------------------------------------------------------------------

            if (historiafinalbool[4])
            {
                --timer;

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    historiafinalbool[5] = true;
                    historiafinalbool[4] = false;
                }
            }

            //----------------------------------------------------historia parte6--------------------------------------------------------------------

            if (historiafinalbool[5])
            {
                --timer;

                if (timer <= 0)
                {
                    clickerobj = new Rectangle((int)-camera.Transform.Translation.X + 1600, (int)-camera.Transform.Translation.Y + 900, 30, 30);
                }

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 50;
                    creditosbool[0] = true;
                    historiafinalbool[5] = false;
                }

                if (!historiafinalbool[5])
                {
                    clickerobj = new Rectangle(0, 0, 0, 0);
                }
            }

            //------------------------------------------------------------------HISTORIA FINAL-----------------------------------------------------------------<<<<<<<<<

            //-------------------------------------------------CREDITOS--------------------------------------------------------------------------------

            //------------------------1º--------------------

            if (creditosbool[0])
            {
                --timer;
                creditosobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    creditosbool[1] = true;
                    creditosbool[0] = false;
                }
            }

            //-------------------------2º--------------------

            if (creditosbool[1])
            {
                --timer;
                creditosobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 30;
                    fimbool = true;
                    creditosbool[1] = false;
                }
            }

            //-------------------------------------------------CREDITOS--------------------------------------------------------------------------------

            //---------------------------------------------------------------------Fim----------------------------------------------------------------------------

            if (fimbool)
            {
                timer--;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer <= 0)
                    Exit();
            }

            //---------------------------------------------------------------------Fim----------------------------------------------------------------------------

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
                    spriteBatch.Draw(historiacomeçoimagem[i], historiacomeçoobj, Color.White);
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
                    backgroundobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
                    spriteBatch.Draw(backgroundimagem, backgroundobj, Color.White);
                    maapa.Draw(spriteBatch);

                    for (int i = 0; i < chipsobj.Length; i++)
                    {
                        spriteBatch.Draw(chipsimagem, chipsobj[i], Color.White);
                    }

                    vidahudobj = new Rectangle((int)-camera.Transform.Translation.X + 40, (int)-camera.Transform.Translation.Y, 340, 100);
                    spriteBatch.Draw(vidahudimagem,vidahudobj,Color.White);

                    for (int i = 0; i < hearthobj.Length; i++)
                    {
                        if (i == 1)
                        {
                            hearthobj[i] = new Rectangle((int)-camera.Transform.Translation.X + 300, (int)-camera.Transform.Translation.Y + 22, 70, 59);
                    }
                        else
                    {
                            hearthobj[i] = new Rectangle((int)-camera.Transform.Translation.X + 230, (int)-camera.Transform.Translation.Y + 22, 70, 59);
                    }
                }

                    chiphudobj = new Rectangle((int)-camera.Transform.Translation.X + 1630, (int)-camera.Transform.Translation.Y, 240, 100);
                    spriteBatch.Draw(chiphudimagem, chiphudobj, Color.White);

                    Vector2 chipsvector = new Vector2((int)-camera.Transform.Translation.X + 1730, (int)-camera.Transform.Translation.Y + 20); 
                    spriteBatch.DrawString(hudfont, chipsget + "/" + chipsobj.Length, chipsvector, Color.DarkGreen);

                    for (int i = 0; i < hearthobj.Length; i++)
                    {
                        spriteBatch.Draw(hearthimagem[i], hearthobj[i], Color.White);
                    }
                    
                    amensagemobj = new Rectangle((int)-camera.Transform.Translation.X + 500, (int)-camera.Transform.Translation.Y, 1000, 100);
                    spriteBatch.Draw(amensagemimagem, amensagemobj, Color.White);

                    spriteBatch.Draw(tankimagem, tankobj, Color.White);
                    C45510.Draw(spriteBatch);

                    for (int i = 0; i < mensagemobj.Length; i++)
                    {
                        spriteBatch.Draw(mensagemimagem, mensagemobj[i], Color.White);
                    }
                }

                if (pausebool)
                {
                    spriteBatch.Draw(pauseimagem, pauseobj, Color.White);
                }
               
            }

            if (gameoverbool)
            {
                gameoverobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
                spriteBatch.Draw(gameoverimagem, gameoverobj, Color.White);
            }

            for (int i = 0; i < historiafinalbool.Length; i++)
            {
                if (historiafinalbool[i])
                {
                    spriteBatch.Draw(historiafinalimagem[i], historiafinalobj, Color.White);
                }
            }

            for (int i = 0; i < creditosbool.Length; i++)
            {
                if(creditosbool[i])
                {
                    spriteBatch.Draw(creditosimagem[i], creditosobj, Color.White);
                }
            }

            spriteBatch.Draw(clickerimagem, clickerobj, Color.White);

            if (fimbool)
            {
                fimobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height);
                spriteBatch.Draw(fimimagem, fimobj, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}