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
    public class Fired : Microsoft.Xna.Framework.Game
    {
        public const int SOURCE_SIZE = 100;
        public const int TILE_SIZE = 40;
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
        bool selected;
        Map map;

        public Fired()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = GameState.Main;
            selected = false;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            map = new Map();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Font");

            map.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameState == GameState.Main)
            {
                if (keyboard.IsKeyDown(Keys.Enter) && Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    if (selected)
                        gameState = GameState.Game;
                    else
                        gameState = GameState.BadEnd;
                }
                if ((keyboard.IsKeyDown(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Left)) || (keyboard.IsKeyDown(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Right)))
                {
                    selected = !selected;
                }

            }
            else if (gameState == GameState.Game)
            {
                map.Update();
                if (map.CheckGameLose())
                    gameState = GameState.BadEnd;
                if (map.CheckGameWin())
                    gameState = GameState.GoodEnd;
            }
            else if (gameState == GameState.BadEnd || gameState == GameState.GoodEnd)
            {
                if (keyboard.IsKeyDown(Keys.Enter) && Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    gameState = GameState.Main;
                    selected = false;
                }
            }

            keyboard = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            if (gameState == GameState.Main)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.DrawString(font, FIRED, new Vector2((SCREEN_WIDTH / 2) - (font.MeasureString(FIRED).X / 2), 50), Color.Ivory);
                if (!selected)
                {
                    spriteBatch.DrawString(font, ACCEPT, new Vector2((SCREEN_WIDTH / 4) - (font.MeasureString(ACCEPT).X / 2), SCREEN_HEIGHT / 2), Color.DarkRed);
                    spriteBatch.DrawString(font, DECLINE, new Vector2((SCREEN_WIDTH * 3 / 4) - (font.MeasureString(DECLINE).X / 2), SCREEN_HEIGHT / 2), Color.Ivory);
                }
                else
                {
                    spriteBatch.DrawString(font, ACCEPT, new Vector2((SCREEN_WIDTH / 4) - (font.MeasureString(ACCEPT).X / 2), SCREEN_HEIGHT / 2), Color.Ivory);
                    spriteBatch.DrawString(font, DECLINE, new Vector2((SCREEN_WIDTH * 3 / 4) - (font.MeasureString(DECLINE).X / 2), SCREEN_HEIGHT / 2), Color.DarkRed);
                }
            }
            else if (gameState == GameState.Game)
            {
                GraphicsDevice.Clear(Color.MediumPurple);
                map.Draw(spriteBatch);
            }
            else if (gameState == GameState.BadEnd)
            {
                GraphicsDevice.Clear(Color.IndianRed);
                spriteBatch.DrawString(font, BAD_END, new Vector2((SCREEN_WIDTH / 2) - (font.MeasureString(BAD_END).X / 2), SCREEN_HEIGHT / 2), Color.Ivory);
            }
            else if (gameState == GameState.GoodEnd)
            {
                GraphicsDevice.Clear(Color.LawnGreen);
                spriteBatch.DrawString(font, GOOD_END, new Vector2((SCREEN_WIDTH / 2) - (font.MeasureString(GOOD_END).X / 2), SCREEN_HEIGHT / 2), Color.Ivory);
            }

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
