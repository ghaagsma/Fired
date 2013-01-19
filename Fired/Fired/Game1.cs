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
        const int SCREEN_WIDTH = 800;
        const int SCREEN_HEIGHT = 600;
        const string GOOD_END = "The End!";
        const string BAD_END = "The End?";
        const string FIRED = "You're Fired";
        const string ACCEPT = "Accept";
        const string DECLINE = "Decline";

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gameState;
        KeyboardState keyboard;
        SpriteFont font;
        bool menuSelect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = GameState.GoodEnd;
            menuSelect = false;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Font");
        }

        protected override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();

            if (gameState == GameState.Main)
            {
                if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.Right))
                {
                    menuSelect = !menuSelect;
                }

            }
            else if (gameState == GameState.Game)
            {
            }
            else if (gameState == GameState.BadEnd || gameState == GameState.GoodEnd)
            {
                if (keyboard.IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.Main;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (gameState == GameState.Main)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.DrawString(font, FIRED, new Vector2((SCREEN_WIDTH / 2) - (font.MeasureString(FIRED).X / 2), 50), Color.DarkRed);
                spriteBatch.DrawString(font, ACCEPT, new Vector2((SCREEN_WIDTH / 4) - (font.MeasureString(ACCEPT).X / 2), SCREEN_HEIGHT / 2), Color.Ivory);
                spriteBatch.DrawString(font, DECLINE, new Vector2((SCREEN_WIDTH * 3 / 4) - (font.MeasureString(DECLINE).X / 2), SCREEN_HEIGHT / 2), Color.Ivory);
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

            spriteBatch.End();
        }
    }
}
