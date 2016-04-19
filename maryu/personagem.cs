using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace maryu
{
    class Personagem
    {
        public Vector2 Position;
        private Vector2 Velocity;
        //public SpriteSheet spriteSheet;
        public Rectangle Rectangle;
        public Texture2D yes;

        private bool hasJumped;

        public Personagem(Vector2 position)
        {
            Position = position;
            //spriteSheet = new SpriteSheet(40, 51, 8);
        }

        public void LoadContent(ContentManager Content)
        {
            yes = Content.Load<Texture2D>("Atores/Hero/Russo");          
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, 40, 51);
            
            Input(gameTime);

            if (Velocity.Y < 10)
                Velocity.Y += 0.4f;

            //spriteSheet.Update(gameTime);

        }


        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                //spriteSheet.SetFrame(0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                //spriteSheet.SetFrame(51);
            }
            else Velocity.X = 0f;

                        

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !hasJumped)
            {
                Position.Y -= 9f;
                Velocity.Y = -12f;
                hasJumped = true;
            }


        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            //if (Rectangle.TouchTopOf(newRectangle))
            {
                Rectangle.Y = newRectangle.Y - Rectangle.Height;
                Velocity.Y = 0f;
                hasJumped = false;
            }

            //if (Rectangle.TouchLeftOf(newRectangle))
            {
                Position.X = newRectangle.X - Rectangle.Width - 2;
            }
            //if (Rectangle.TouchRightOf(newRectangle))
            {
                Position.X = newRectangle.X + Rectangle.Width + 2;
            }
            //if (Rectangle.TouchBottomOf(newRectangle))
                Velocity.Y = 1f;

            if(Position.X < 0) Position.X = 0;
            if (Position.X > xOffset - Rectangle.Width) Position.X = xOffset - Rectangle.Width;
            if(Position.Y < 0) Velocity.Y = 1f;
            if (Position.Y > yOffset - Rectangle.Height) Position.Y = yOffset - Rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(yes, Position, Rectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);        
        }
    }
}
