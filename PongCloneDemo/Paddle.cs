using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCloneDemo
{

    public enum PlayerTypes
    {
        Human,
        Computer
    }

    public class Paddle : Sprite
    {
        private readonly PlayerTypes playerType;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds, PlayerTypes playerType) : base(texture, location, screenBounds)
        {
            this.playerType = playerType;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (playerType == PlayerTypes.Computer)
            {
                if(gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y)
                    Velocity = new Vector2(0, -3.5f);
                if (gameObjects.Ball.Location.Y  > Location.Y + Height)
                    Velocity = new Vector2(0, 3.5f);
            }

            if (playerType == PlayerTypes.Human)
            {
                // move paddle up
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    Velocity = new Vector2(0, -3.5f);

                // move paddle down
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    Velocity = new Vector2(0, 3.5f);
            }
            base.Update(gameTime, gameObjects);
        }

        protected override void checkBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - texture.Height);
        }
    }
}