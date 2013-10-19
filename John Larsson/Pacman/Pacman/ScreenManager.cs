using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class ScreenManager
    {
        #region Variabler

        /// <summary>
        /// Det nuvarande spelfönstret
        /// </summary>
        GameScreen currentScreen;

        /// <summary>
        /// Det nya spelfönstret som kommer att ersätta det nuvarande
        /// </summary>
        
        GameScreen newScreen;
        
        /// <summary>
        /// Skapar en egen ContrentManager utöver huvud managern
        /// </summary>
        
        ContentManager content;

        /// <summary>
        /// ScreenManager instance
        /// </summary>

        private static ScreenManager instance;

        /// <summary>
        /// Överlappning av olika fönster
        /// </summary>
        
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        /// <summary>
        /// Fönstrens höjd och bredd
        /// </summary>

        Vector2 dimensions;

        #endregion

        #region Properties

        public static ScreenManager Instance 
        {
            get 
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public Vector2 Dimensions 
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion

        #region Huvud metoder

        public void AddScreen(GameScreen screen) 
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content);
        }

        public void Init() 
        {
            currentScreen = new SplashScreen();
        }
        public void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(content);
        }
        public void Update(GameTime gameTime) 
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            currentScreen.Draw(spriteBatch);
        }

        #endregion
    }
}
