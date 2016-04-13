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
        Rectangle[] terra = new Rectangle[6];
        Rectangle[] bricks = new Rectangle[7];
        Rectangle dimitri;
        int pulo = 20, gravidade = 1;
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

            for (int i = 0; i < terra.Length; i++)
            {
                terra[i] = new Rectangle(0 + (i * 300), 600, 300, 300);
            }
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = new Rectangle(500 + (i * 60), 500 ,60 ,60);
            }

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

            Contexto.hero.y += 5;

            //--------------MOVIMENTO DO DIMITRI

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

            if (Jump)
            {
                Contexto.hero.y -= pulo;
                pulo -= gravidade;
            }

            //--------------COLISÃO  

            for (int i = 0; i < terra.Length; i++)
            {
                if (dimitri.Intersects(terra[i]))
                {
                    Contexto.hero.y -= 5;
                    Jump = false;
                    pulo = 20;
                }
            }
            for (int i = 0; i < bricks.Length; i++)
            {
                if (dimitri.Intersects(bricks[i]))
                {
                    Contexto.hero.y -= 5;
                    Jump = false;
                    pulo = 20;
                }
            }
                
            

            
            



            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Contexto.background, new Rectangle(0,0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            spriteBatch.Draw(Contexto.hero.herotextura, dimitri = new Rectangle((int)Contexto.hero.x, (int)Contexto.hero.y,75,150) , Color.White);
            /*
            foreach (Personagem p in Contexto.enemy)
            {
                spriteBatch.Draw(p.herotextura, p.getVector(), Color.Red);
            }          
            */
           for (int i = 0; i < bricks.Length; i++)
            {
                
                spriteBatch.Draw(Tiles.normalbrick,bricks[i] ,Color.BlueViolet);
            }

            for (int i = 0; i < terra.Length; i++)
            {
                spriteBatch.Draw(Tiles.terratextura, terra[i], Color.White);
            }
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
