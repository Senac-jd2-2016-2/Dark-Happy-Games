using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace maryu
{
    class Tiles
    {
        public Texture2D Texture;
        public Rectangle Rectangle { get; protected set; }
        public static ContentManager Content{ protected get; set; }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            Texture = Content.Load<Texture2D>("Tijolos/Terra" + i);
            this.Rectangle = newRectangle;
        }
    }
}