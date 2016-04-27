﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
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
        Mapa maapa;
        Personagem dimitri;
        Rectangle sas;
        Texture2D ssa;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //>>>>>--------------NOME--------------<<<<<
            Window.Title = "Russian Attack 2";
            graphics.ApplyChanges();

            
            maapa = new Mapa();
            dimitri = new Personagem(new Vector2(70, 390));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;

            camera = new Camera(GraphicsDevice.Viewport);
            //------------gerar mapa (entre 0,1,2)-----------
            maapa.Generate(new int[,] {
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,2,2,2,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,0,0},
               {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
               {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},


            }, 74);//<<--------------tamanho do mapa----------------


            dimitri.LoadContent(Content);

            ssa = Content.Load <Texture2D>("Atores/Enemigos/vine");

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if(dimitri.Posiçao.X >= 2970)
            {
                sas = new Rectangle(Window.ClientBounds.Width, Window.ClientBounds.Height, Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
            //------------colisao do russo sobre os tijolos e camera-------------
            dimitri.Update(gameTime);
            foreach (CollisionTiles tile in maapa.CollisionTile)
            {
                dimitri.Collision(tile.Rectangle, maapa.Width, maapa.Height);
                camera.Update(dimitri.Posiçao, maapa.Width, maapa.Height);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            maapa.Draw(spriteBatch);
            dimitri.Draw(spriteBatch);
            spriteBatch.Draw(ssa, sas, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
