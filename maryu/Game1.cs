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
        Rectangle dimitri;
        Rectangle[] terra = new Rectangle[3];
        int pulo = 25, gravidade = 1;
        bool Jump;
        Contexto heroi = new Contexto();

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
            dimitri = new Rectangle((int)Contexto.hero.x, (int)Contexto.hero.y, 30, 30);
            terra[0] = new Rectangle(0, 600, 500, 500);
            terra[1] = new Rectangle(500, 600, 500, 500);
            terra[2] = new Rectangle(1000, 600, 500, 500);
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
                Contexto.hero.y -= pulo;
                pulo -= gravidade;
            }



            //---COLISAO
           
            



            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(Contexto.background, new Rectangle(0,0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            spriteBatch.Draw(Contexto.hero.herotextura, new Rectangle((int)Contexto.hero.x, (int)Contexto.hero.y,75,150) , Color.White);
            /*
            foreach (Personagem p in Contexto.enemy)
            {
                spriteBatch.Draw(p.herotextura, p.getVector(), Color.Red);
            }          
            */
            foreach (Tiles t in Contexto.tijolinhos)
            {
                
                spriteBatch.Draw(Tiles.normalbrick, t.getVector(),Color.BlueViolet);
            }
            //spriteBatch.Draw(Tiles.terratextura, terra[0], Color.White);
            //spriteBatch.Draw(Tiles.terratextura, terra[1], Color.White);
            //spriteBatch.Draw(Tiles.terratextura, terra[2], Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
