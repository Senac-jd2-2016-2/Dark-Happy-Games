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
        Mapa maapa1, maapa2;
        Personagem C45510;
        Rectangle tankobj, historiafinalobj, menuobj, clickerobj, historiacomeçoobj, backgroundobj, gameoverobj, manuelobj, pauseobj, fimobj, chiphudobj, amensagemobj;
        Rectangle[] chipsobj = new Rectangle[11], mensagemobj = new Rectangle[11], hearthobj = new Rectangle[2];
        Texture2D chipsimagem, backgroundimagem, mensagemimagem, tankimagem, historiacomeçoimagem, historiafinalimagem, menuimagem, clickerimagem, gameoverimagem, manuelimagem, pauseimagem, fimimagem, amensagemimagem;
        Texture2D[] hearthimagem = new Texture2D[2];
        Rectangle alavanca1 = new Rectangle();
        Rectangle alavanca2 = new Rectangle();
        Vector2 vidavector, chipsvector;
        public static bool gamebool = false, pausebool = false, personmovebool = false;
        bool menubool = true, manuelbool = false, gameoverbool = false, fimbool = false, fase1bool = false, fase2bool = true, songstartbool = false;
        bool[] historiacomeçobool = new bool[5], historiafinalbool = new bool[5], mensagembool = new bool[11];
        int timer = 30;
        public static SoundEffect clickeffect, ironeffect, walkingeffect, porta1effect, porta2effect;
        public static int vida = 2, chipsget = 0;
        SpriteFont hudfont;
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

            chipsobj[0] = new Rectangle(1050, 700, 30, 30);
            chipsobj[1] = new Rectangle(2050, 1000, 30, 30);
            chipsobj[2] = new Rectangle(5050, 90, 30, 30);
            chipsobj[3] = new Rectangle(7050, 700, 30, 30);
            chipsobj[4] = new Rectangle(10050, 900, 30, 30);
            chipsobj[5] = new Rectangle(600, 100, 30, 30);
            chipsobj[6] = new Rectangle(4050, 800, 30, 30);
            chipsobj[7] = new Rectangle(10050, 1000, 30, 30);
            chipsobj[8] = new Rectangle(500, 400, 30, 30);
            chipsobj[9] = new Rectangle(500, 800, 30, 30);
            chipsobj[10] = new Rectangle(8070, 800, 30, 30);
            

            maapa2 = new Mapa();
            maapa1 = new Mapa();
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

            maapa2.Generate(new int[,] {
               {5,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,5},
               {6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5},
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
            hudfont = Content.Load<SpriteFont>("Vidas");
            hearthimagem[0] = Content.Load<Texture2D>("Varies/S1");
            hearthimagem[1] = Content.Load<Texture2D>("Varies/S1");
            amensagemimagem = Content.Load<Texture2D>("Varies/thewater");
            backgroundsong = Content.Load<Song>("Sons/Disintegratingwav.wav");
            backgroundimagem = Content.Load<Texture2D>("Fundo/Fabrica");
            mensagemimagem = Content.Load<Texture2D>("Mensagens/texto0");
            historiacomeçoimagem = Content.Load<Texture2D>("Começos/começo1");
            tankimagem = Content.Load<Texture2D>("Varies/Barril");
            menuimagem = Content.Load<Texture2D>("Menus, Telas e Afins/menu");
            clickerimagem = Content.Load<Texture2D>("Varies/clicker");
            gameoverimagem = Content.Load<Texture2D>("Menus, Telas e Afins/gameover");
            fimimagem = Content.Load<Texture2D>("Menus, Telas e Afins/Fimdejogo");
            manuelimagem = Content.Load<Texture2D>("Menus, Telas e Afins/howtoplay");
            pauseimagem = Content.Load<Texture2D>("Menus, Telas e Afins/Pause");
            clickeffect = Content.Load<SoundEffect>("Sons/SFX/clique");
            walkingeffect = Content.Load<SoundEffect>("Sons/SFX/Robo andando");

            //------carregar imagens n shit----------

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {



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
                    songstartbool = true;
                    timer = 30;
                    historiacomeçobool[0] = false;
                    gamebool = true;
                    fase2bool = true;
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
                for (int i = 0; i < 6; i++)
                {
                    if (C45510.Rectangle.Intersects(chipsobj[i]))
                    {
                        mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                        mensagemimagem = Content.Load<Texture2D>("Mensagens/texto" + i);
                        personmovebool = false;
                        chipsobj[i] = new Rectangle(0, 0, 0, 0);
                        if (!C45510.Rectangle.Intersects(chipsobj[i]))
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                            {
                                personmovebool = true;
                                mensagemobj[i] = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 0, 0);
                            }
                        }
                    }
                }
                //------------criar mensagens----------------------------------------

                vidavector = new Vector2(backgroundobj.X, backgroundobj.Y);
                chipsvector = new Vector2((backgroundobj.X + backgroundobj.X - 200), backgroundobj.Y);

                for (int i = 0; i < hearthobj.Length; i++)
                {
                    hearthobj[i] = new Rectangle((int)-camera.Transform.Translation.X + i * 85, (int)-camera.Transform.Translation.Y + 69, 80, 69);
                }

                if (vida == 2)
                {
                    hearthimagem[1] = Content.Load<Texture2D>("Varies/S1");
                }
                if (vida == 1)
                {
                    hearthimagem[1] = Content.Load<Texture2D>("Varies/S2");
                }

                if (vida <= 0)
                {
                    gameoverbool = true;
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
                        chipsget++;
                        clickeffect.Play();
                        personmovebool = false;
                        chipsobj[i] = new Rectangle(0, 0, 0, 0);
                        clickeffect.Play();
                    
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

                vidavector = new Vector2(backgroundobj.X, backgroundobj.Y);
                chipsvector = new Vector2((backgroundobj.X + 1630), backgroundobj.Y);
                chiphudobj = new Rectangle((backgroundobj.X + 1850), (backgroundobj.Y + 10), 60,49);

                for (int i = 0; i < hearthobj.Length; i++)
                {
                    if(i == 1)
                    {
                        hearthobj[i] = new Rectangle(backgroundobj.X + 210, backgroundobj.Y, 80, 69);
                    }
                    else 
                    {
                        hearthobj[i] = new Rectangle(backgroundobj.X + 120, backgroundobj.Y, 80, 69);
                    }   
                }

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
                    
                    amensagemobj = new Rectangle(backgroundobj.X + 1000, backgroundobj.Y, 400, 200);
                }

                tankobj = new Rectangle(8070, 50, 89, 111);

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
                    fase2bool = false;
                    gamebool = false;
                    
                }

                //------------colisao do russo sobre os tijolos e camera mapa2-------------

                if (gamebool)
                {
                    C45510.Update(gameTime);
                    if(songstartbool)
                    {
                        MediaPlayer.Play(backgroundsong);
                        songstartbool = false;
                    }
                }

                foreach (CollisionTiles tile in maapa2.CollisionTile)
                {
                    C45510.Collision(tile.Rectangle, maapa2.Width, maapa2.Height);
                    camera.Update(C45510.Posiçao, maapa2.Width, maapa2.Height);
                }

                //------------colisao do russo sobre os tijolos e camera mapa2-------------
            }

            //---------------------------------------------------------------fase2-----------------------------------------------------------------


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
                historiafinalimagem = Content.Load<Texture2D>("Finais/começo1");
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
                historiafinalimagem = Content.Load<Texture2D>("Finais/começo2");
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
                historiafinalimagem = Content.Load<Texture2D>("Finais/começo3");
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
                historiafinalimagem = Content.Load<Texture2D>("Finais/começo4");
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
                historiafinalimagem = Content.Load<Texture2D>("Finais/começo5");
                --timer;
                historiafinalobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);

                if ((Keyboard.GetState().IsKeyDown(Keys.Enter)) && timer <= 0)
                {
                    timer = 40;
                    fimbool = true;
                    historiafinalbool[4] = false;
                }
            }

            //------------------------------------------------------------------HISTORIA FINAL-----------------------------------------------------------------<<<<<<<<<

            //---------------------------------------------------------------------Fim----------------------------------------------------------------------------

            if(fimbool)
            {
                timer--;
                C45510.Posiçao.X = 7000;
                C45510.Posiçao.Y = 100;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer < 30)
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

                    spriteBatch.DrawString(hudfont, "Vidas: ", vidavector, Color.Black);
                    spriteBatch.DrawString(hudfont, "Chips: " + chipsget + "/" + chipsobj.Length, chipsvector, Color.Black);

                    spriteBatch.Draw(chipsimagem, chiphudobj, Color.White);

                    for (int i = 0; i < hearthobj.Length; i++)
                    {
                        spriteBatch.Draw(hearthimagem[i], hearthobj[i], Color.White);
                    }

                    for (int i = 0; i < mensagemobj.Length; i++)
                    {
                        spriteBatch.Draw(mensagemimagem, mensagemobj[i], Color.White);
                    }

                    spriteBatch.Draw(amensagemimagem, amensagemobj, Color.White);

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

                    spriteBatch.DrawString(hudfont, "Vidas: ", vidavector, Color.Black);
                    spriteBatch.DrawString(hudfont, "Chips: " + chipsget + "/" + chipsobj.Length, chipsvector, Color.Black);
                    spriteBatch.Draw(chipsimagem, chiphudobj, Color.White);

                    for (int i = 0; i < hearthobj.Length; i++)
                    {
                        spriteBatch.Draw(hearthimagem[i], hearthobj[i], Color.White);
                    }

                    spriteBatch.Draw(tankimagem, tankobj, Color.White);
                    
                    for (int i = 0; i < mensagemobj.Length; i++)
                    {
                        spriteBatch.Draw(mensagemimagem, mensagemobj[i], Color.White);
                    }
                    spriteBatch.Draw(amensagemimagem, amensagemobj, Color.White);
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
                fimobj = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                spriteBatch.Draw(fimimagem, fimobj, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}