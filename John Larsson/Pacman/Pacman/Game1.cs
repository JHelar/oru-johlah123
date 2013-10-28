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

namespace Pacman
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        bool exit;

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        public Game1(bool exit) 
        {
            this.UnloadContent();
        }
        /// <summary>
        /// Initializes the ScreenManager, sets the dimensions of the game window
        /// </summary>
        protected override void Initialize()
        {
            ScreenManager.Instance.Init();
            ScreenManager.Instance.Dimensions = new Vector2(560, 655);
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.ApplyChanges();
            base.Initialize();
        }
        /// <summary>
        /// Gives the ScreenManager class it's own Contentmanager
        /// </summary>
        protected override void LoadContent()
        {
            ScreenManager.Instance.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {
            
            this.Exit();
        }
        /// <summary>
        /// Checks to see if we want to exit if not then update the current screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            bool exit = false;
            if (!exit)
                exit = ScreenManager.Instance.Update(gameTime);
            if (exit)
            {
                ScreenManager.Instance.UnloadContent();
                this.Exit();
            }
            base.Update(gameTime);
        }
        /// <summary>
        /// Draw the current screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
