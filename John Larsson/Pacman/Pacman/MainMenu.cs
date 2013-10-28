using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    /// <summary>
    /// The main menu screen, uses the MenuManager class
    /// </summary>
    public class MainMenu : GameScreen
    {
        MenuManager menu;
        #region Public methods
        /// <summary>
        /// Loads the content to the menu class.
        /// </summary>
        /// <param name="Content"></param>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            menu = new MenuManager();
            menu.LoadContent(content, "PacMenu");
        }
        /// <summary>
        /// Unloads the content, called when a new screen has been added
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            menu.UnloadContent();
        }
        /// <summary>
        /// Updates the menu
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
        }
        /// <summary>
        /// Draws the menu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
        #endregion
    }
}
