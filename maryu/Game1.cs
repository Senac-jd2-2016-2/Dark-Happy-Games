﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace maryu
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //>>>>>--------------NOME--------------<<<<<
            this.Window.Title = "Russian Attack 2";
            //>>>>>-----------TAMANHO DA TELA-----------<<<<<
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Contexto.inicializar(Content); 
            // TODO: use this.Content to load your game content here
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //---MOVIMENTO DO DIMITRI
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys k in keys)
            {
                if (k.Equals(Keys.A))
                {
                    Contexto.hero.gohorizotal(-5);
                }
                if (k.Equals(Keys.D))
                {
                    Contexto.hero.gohorizotal(5);
                }
                if (k.Equals(Keys.S))
                {
                    Contexto.hero.govertical(5);
                }
                if (k.Equals(Keys.W))
                {
                    Contexto.hero.govertical(-5);
                }
            }
            // TODO: Add your update logic here
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Contexto.background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            spriteBatch.Draw(Contexto.hero.textura, Contexto.hero.getVector(), Color.White);
            foreach (Personagem p in Contexto.enemy)
            {
                spriteBatch.Draw(p.textura, p.getVector(), Color.Red);
            }          
            foreach (Tiles t in Contexto.tijolinhos)
            {
                spriteBatch.Draw(Tiles.normalbrick, t.getVector() , Color.White);
            } 
            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
