﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongCloneDemo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private GameObjects gameObjects;
        private Paddle playerPaddle;
        private Paddle computerPaddle;
        private Ball ball;
        private Score score;
        //private Texture2D playerPaddle;

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

            IsMouseVisible = true;

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

            // TODO: use this.Content to load your game content here
            //playerPaddle = Content.Load<Texture2D>("Paddle");

            var gameBoundaries = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            var paddleTexture = Content.Load<Texture2D>("Paddle");

            playerPaddle = new Paddle(paddleTexture, Vector2.Zero, gameBoundaries, PlayerTypes.Human);

            var computerPaddleLocation = new Vector2(Window.ClientBounds.Width - paddleTexture.Width, 0);
            computerPaddle = new Paddle(paddleTexture, computerPaddleLocation, gameBoundaries, PlayerTypes.Computer);

            ball = new Ball(Content.Load<Texture2D>("Ball"), Vector2.Zero, gameBoundaries);
            ball.AttachTo(playerPaddle);

            score = new Score(Content.Load<SpriteFont>("GameFont"), gameBoundaries);

            gameObjects = new GameObjects {PlayerPaddle = playerPaddle, ComputerPaddle = computerPaddle, Ball = ball, Score = score };
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

            // TODO: Add your update logic here
            playerPaddle.Update(gameTime, gameObjects);
            computerPaddle.Update(gameTime, gameObjects);
            ball.Update(gameTime, gameObjects);
            score.Update(gameTime, gameObjects);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            playerPaddle.Draw(spriteBatch);
            computerPaddle.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            score.Draw(spriteBatch);
            
            //spriteBatch.Draw(playerPaddle, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
