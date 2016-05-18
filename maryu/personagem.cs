using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace maryu
{
    class Personagem
    {
        public Vector2 Posiçao;
        private Vector2 Velocidade;
        public Animaçao spriteShit;
        public Rectangle Rectangle;
        private bool jump;
        public Vector2 Posiçaosave;
        StreamWriter save;


        public Personagem(Vector2 position)
        {
            Posiçao = position;
            spriteShit = new Animaçao(109, 101, 3);
        }

        //-----------imagem do russo-----
        public void LoadContent(ContentManager Content)
        {
            spriteShit.LoadContent(Content, "Atores/Hero/russo");
        }
        //-----------imagem do russo-----

        //------a spritesheet do russo-----
        public void Update(GameTime gameTime)
        {
            Posiçao += Velocidade;
            Rectangle = new Rectangle((int)Posiçao.X, (int)Posiçao.Y, 109, 101);
            Input(gameTime);
            if (Velocidade.Y < 10)
            {
                Velocidade.Y += 0.4f;
            }
            spriteShit.Update(gameTime);
        }
        //------a spritesheet do russo-----

        //-----------controles do russo-------
        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Velocidade.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                spriteShit.SetFrame(0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Velocidade.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                spriteShit.SetFrame(109);
            }
            else
            {
                Velocidade.X = 0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !jump)
            {
                Posiçao.Y -= 9f;
                Velocidade.Y = -12f;
                jump = true;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.R) && !jump)
            {
                save = new StreamWriter("data.txt");
                save.Write(Posiçao.X + '|' + Posiçao.Y);

                save.Close();
            }
            
        }
        //-----------controles do russo-------

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (Rectangle.TouchTopOf(newRectangle))
            {
                Rectangle.Y = newRectangle.Y - Rectangle.Height;
                Velocidade.Y = 0f;
                jump = false;
            }

            if (Rectangle.TouchLeftOf(newRectangle))
            {
                Posiçao.X = newRectangle.X + Rectangle.Width / 2 + 30;
            }
            if (Rectangle.TouchRightOf(newRectangle))
            {
                Posiçao.X = newRectangle.X - Rectangle.Width/2 - 30;
            }
            if (Rectangle.TouchBottomOf(newRectangle))
            {
                Velocidade.Y = 1f;
            }
            if (Posiçao.X < 0)
            {
                Posiçao.X = 0;
            }
            if (Posiçao.X > xOffset - Rectangle.Width)
            {
                Posiçao.X = xOffset - Rectangle.Width;
            }
            if (Posiçao.Y < 0)
            {
                Velocidade.Y = 1f;
            }
            if (Posiçao.Y > yOffset - Rectangle.Height)
            {
                Posiçao.Y = yOffset - Rectangle.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteShit.Textuer, Posiçao, spriteShit.Rectangel, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}
