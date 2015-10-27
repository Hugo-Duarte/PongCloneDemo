using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongCloneDemo
{
    public class Paddle : Sprite
    {
        public Paddle(Texture2D texture, Vector2 location) : base(texture, location)
        {
        }
}

    public class Sprite
    {
        private Texture2D texture;
        private Vector2 location;

        public Sprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }
    }
}