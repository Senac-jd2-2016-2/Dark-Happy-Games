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
        Personagem position, size;
        Mapa maapa1;
        Rectangle findeljueguito;
        Personagem dimitri;
        private Rectangle background;
        Rectangle portal, historia2obj, menuobj, fimobj, clickerobj, historiacomeçoobj;
        Rectangle[] paper = new Rectangle[5], messagem = new Rectangle[4], plataformaobj = new Rectangle[4], blockersobj = new Rectangle[8];
        Texture2D paperimagem, fundo, messagemimagem, portalimagem, historiacomeçoimagem, historia2imagem, menuimagem, fimimagem, clickerimagem, plataformaimagem;
        bool menu = true, game = false, historia2 = false, fim = false;
        bool[] historiacomeço = new bool[5], blockers = new bool[4];
        int timer = 240;
        public int vida = 2;
        SpriteFont vidas;
        public bool gameover = false;
        public Texture2D gameoverscreen;

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

            paper[0] = new Rectangle(1050, 700, 30, 30);
            paper[1] = new Rectangle(2050, 1000, 30, 30);
            paper[2] = new Rectangle(5050, 400, 30, 30);
            paper[3] = new Rectangle(7050, 700, 30, 30);
            paper[4] = new Rectangle(10050, 900, 30, 30);

            for (int i = 0; i < blockers.Length; i++)
			{
                blockers[i] = true;
			}

            for (int i = 0; i < plataformaobj.Length; i++)
            {
                blockersobj[i] = new Rectangle((1050 * i), 600, 300, 77);
                plataformaobj[i] = new Rectangle((1050 * i), 900, 300, 77);
                blockersobj[i + 4] = new Rectangle((1050 * i), 1200, 300, 77);   
            }
            

            

            maapa1 = new Mapa();
            dimitri = new Personagem(new Vector2(10, 4800));
          findeljueguito = new Rectangle(0, 0,Window.ClientBounds.Width, Window.ClientBounds.Height+100);
  
  
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
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2},
               {0,0,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,2,2,0,0,2,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0},
               {0,0,2,0,0,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,2,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,2,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,2,0,0,0,0,0,0,2,2,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,2,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,2,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0,0,0,2,0,0,2,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,2,0,0,0,0,0,0,2,0,0,2,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,2,2,2,0,0,2,0,0,2,0,0,2,0,0,0,2,2,2,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
               {0,0,0,0,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,0,0,0,0,0,0,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2},

            }, 77);//<<--------------tamanho do mapa----------------
            dimitri.LoadContent(Content);
            paperimagem = Content.Load <Texture2D>("Varies/chip0");
            vidas = Content.Load<SpriteFont>("Vidas");
            fundo = Content.Load<Texture2D>("Fundo/FundoPronto");
            messagemimagem = Content.Load<Texture2D>("Mensagens/mensagem0");
            historiacomeçoimagem = Content.Load<Texture2D>("começos/começo1");
            portalimagem = Content.Load<Texture2D>("Varies/porta");
            menuimagem = Content.Load<Texture2D>("Fundo/menu");
            clickerimagem = Content.Load<Texture2D>("Varies/clicker");
            gameoverscreen = Content.Load<Texture2D>("GAME OVER");
            plataformaimagem = Content.Load<Texture2D>("Tijolos/moveble");

            for (int i = 0; i < paper.Length; i++)
            {
                messagemimagem = Content.Load<Texture2D>("Varies/chip" + i);
            }
            
            
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
                dimitri.Posiçao.X = 10;
                dimitri.Posiçao.Y = 300;
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

            portal = new Rectangle(8070, 50, 109, 101);
            //------------criar mensagens----------------------------------------
            for (int i = 0; i < paper.Length; i++)
            {
                if (dimitri.Rectangle.Intersects(paper[i]))
                {
                    --timer;
                    messagem[i] = new Rectangle(paper[i].X - 400, paper[i].Y - 400, 450, 450);
                    messagemimagem = Content.Load<Texture2D>("Mensagens/mensagem" + i);
                    if(timer <= 0)
                    {
                        messagem[i] = new Rectangle(0,0,0,0);
                    }
                }
            }
            if (position.Posiçao > size.yOffset - position.Rectangle.Height)
            {
                vida--;
                position.Posiçao.Y = 100;
                position.Posiçao.X = 100;
            }
            if (vida <= 0)
            {
                gameover = true;
            }
            //------------criar mensagens----------------------------------------

            //------------colisao do russo sobre os tijolos e camera-------------
            if (game)
            {
                
                dimitri.Update(gameTime);
            }
            if (!game)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    dimitri.Posiçao.X = dimitri.Posiçao.X - 3;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    dimitri.Posiçao.X = dimitri.Posiçao.X + 3;
                }
                else
                {
                    dimitri.Posiçao.X = 0f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    dimitri.Posiçao.Y += 9f;
                    dimitri.Posiçao.Y = +12f;
                }
            }
            foreach (CollisionTiles tile in maapa1.CollisionTile)
            {
                dimitri.Collision(tile.Rectangle, maapa1.Width, maapa1.Height);
                camera.Update(dimitri.Posiçao, maapa1.Width, maapa1.Height);
            }

            //Puzzles da primeira fase


            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                game = false;
                menu = true;
            }
            for (int i = 0; i < plataformaobj.Length; i++)
            {
                if (dimitri.Rectangle.Intersects(plataformaobj[i]))
                {
                    dimitri.Posiçao.Y -= 10.3f;
                    dimitri.jump = false;
                }    
            }

            //------------colisao do russo sobre os tijolos e camera-------------
            //------------------------------------plataformas moveis------------------------------------------------------------------
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

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
         
            if(menu)
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
            

            if(game)
            {
                background = new Rectangle((int)-camera.Transform.Translation.X, (int)-camera.Transform.Translation.Y, 2000, 1200);
                spriteBatch.Draw(fundo, background, Color.White);
                maapa1.Draw(spriteBatch);

                for (int i = 0; i < paper.Length; i++)
                {
                    spriteBatch.Draw(paperimagem, paper[i], Color.White);
                }

                for (int i = 0; i < messagem.Length; i++)
                {
                    spriteBatch.Draw(messagemimagem, messagem[i], Color.White);
                }
                dimitri.Draw(spriteBatch);
                spriteBatch.Draw(portalimagem, portal, Color.White);
            }
            if (gameover)
            {
                spriteBatch.Draw(gameoverscreen, findeljueguito, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
