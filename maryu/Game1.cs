using Microsoft.Xna.Framework;
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
        Rectangle terra;
        
        bool Jump;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            
            //>>>>>--------------NOME--------------<<<<<
            Window.Title = "Russian Attack 2";
            //>>>>>-----------TAMANHO DA TELA-----------<<<<<
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 750;
            graphics.ApplyChanges();


            terra = new Rectangle(700, 200 , 500, 500);
            base.Initialize();
        }
       
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Contexto.inicializar(Content);
            
            
        }
        
        protected override void UnloadContent()
        {
           
        }
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //---MOVIMENTO DO DIMITRI

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Contexto.hero.gohorizotal(10);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Contexto.hero.gohorizotal(-10);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Jump = true;
            }
            //if (Jump)
            //{
            //   Contexto.herogravy.jump (Contexto.hero, Jump);
            //    Jump = Contexto.herogravy.jump(Contexto.hero, Jump); 
            //}
            //Contexto.herogravy.gravidad(Contexto.hero);

            //---COLISAO






            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Contexto.background, new Rectangle(0,0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            spriteBatch.Draw(Contexto.hero.herotextura, new Rectangle((int)Contexto.hero.x, (int)Contexto.hero.y,50,50) , Color.White);
            foreach (Personagem p in Contexto.enemy)
            {
                spriteBatch.Draw(p.herotextura, p.getVector(), Color.Red);
            }          
            foreach (Tiles t in Contexto.tijolinhos)
            {

                spriteBatch.Draw(Tiles.normalbrick, t.getVector(), Color.White);
            }
            //spriteBatch.Draw(Tiles.terratextura, terra, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
