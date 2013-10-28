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
    /// The base class of all the different screens
    /// </summary>
    public class GameScreen
    {
        #region Protected variables
        protected ContentManager content;
        protected List<List<string>> attributes, contents;
        #endregion
        #region Public virtual methods
        /// <summary>
        /// Unloads the contentmanager
        /// </summary>
        public virtual void UnloadContent() 
        {
            content.Unload();
        }
        /// <summary>
        /// Loads the contentmanager to the one that Game1 is using.
        /// initializes the lists
        /// </summary>
        /// <param name="Content"></param>
        public virtual void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            attributes = new List<List<string>>();
            contents = new List<List<string>>();
        }
        /// <summary>
        /// Generic update funcion
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime) { }
        /// <summary>
        /// Generic draw function
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch) { }
        /// <summary>
        /// Allways returns false except when changed.
        /// </summary>
        /// <returns></returns>
        public virtual bool Exit() { return false; }
    }
        #endregion
}
