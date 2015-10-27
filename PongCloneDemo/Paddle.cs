using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCloneDemo
{
    public class Paddle : Sprite
    {
        private Rectangle screenBounds;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds) : base(texture, location)
        {
            this.screenBounds = screenBounds;
        }

        public override void Update(GameTime gameTime)
        {
            // move paddle up
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                velocity = new Vector2(0, -2.5f);

            // move paddle down
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                velocity = new Vector2(0, 2.5f);

            base.Update(gameTime);
        }

        protected override void checkBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, screenBounds.Height - texture.Height);
        }
    }

    public abstract class Sprite
    {
        protected Texture2D texture;
        public Vector2 Location;
        public int Width
        {
            get { return texture.Width; }
        }

        public int Height
        {
            get { return texture.Height; }
        }

        protected Vector2 velocity = Vector2.Zero;

        public Sprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location = Location + velocity;

            checkBounds();
        }

        protected abstract void checkBounds();
    }
}