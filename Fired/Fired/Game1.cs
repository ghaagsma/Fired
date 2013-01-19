using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fired
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const string GOOD_END = "The End!";
        const string BAD_END = "The End?";
        const string FIRED = "You're Fired";
        const string ACCEPT = "Accept";
        const string DECLINE = "Decline";

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gameState;
        KeyboardState keyboard;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = GameState.Main;
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
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            keyboard = Keyboard.GetState();

            // TODO: Add your update logic here
            if (gameState == GameState.Main)
            {
            }
            else if (gameState == GameState.Game)
            {
            }
            else if (gameState == GameState.BadEnd || gameState == GameState.GoodEnd)
            {
                //if ();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (gameState == GameState.Main)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            else if (gameState == GameState.Game)
            {
                GraphicsDevice.Clear(Color.MediumPurple);
            }
            else if (gameState == GameState.BadEnd)
            {
                GraphicsDevice.Clear(Color.IndianRed);
            }
            else if (gameState == GameState.GoodEnd)
            {
                GraphicsDevice.Clear(Color.LawnGreen);
            }

            base.Draw(gameTime);
        }
    }
}
