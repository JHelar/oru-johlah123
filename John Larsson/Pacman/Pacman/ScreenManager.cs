using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    /// <summary>
    /// Screen manager that takes care of loading,unloading,updating and drawing of all the screens
    /// </summary>
    public class ScreenManager
    {
        #region Variabler

        /// <summary>
        /// The current screen
        /// </summary>
        GameScreen currentScreen;

        /// <summary>
        /// The new screen that will replace the old one
        /// </summary>
        
        GameScreen newScreen;
        
        /// <summary>
        /// creates a new contentmanager
        /// </summary>
        
        ContentManager content;

        /// <summary>
        /// ScreenManager instance
        /// </summary>

        private static ScreenManager instance;

        /// <summary>
        /// A stack of all the screens
        /// </summary>
        
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        Vector2 dimensions;

        bool transition;

        FadeAnimation fade;

        Texture2D fadeTexture;

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
        #region Public methods
        /// <summary>
        /// Sets transision to a new screen. Adds a screen to newScreen
        /// </summary>
        /// <param name="screen"></param>
        public void AddScreen(GameScreen screen) 
        {
            transition = true;
            newScreen = screen;
            fade.Active = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;    
        }
        /// <summary>
        /// Overloaded version, changes the alpha so it will fade back instead of just switching a screen back instantly, 
        /// usable when you want a smooth transition between screens.
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="alpha"></param>
        public void AddScreen(GameScreen screen, float alpha) 
        {
            transition = true;
            newScreen = screen;
            fade.Active = true;
            fade.ActivateValue = 1.0f;
            if (alpha != 1.0f)
                fade.Alpha = 1.0f - alpha;
            else
                fade.Alpha = alpha;
            fade.Increase = true;
        }
        /// <summary>
        /// When the game starts the splash screen will show and a new fade animation will be initialized
        /// </summary>
        public void Init() 
        {
            currentScreen = new MainMenu();
            fade = new FadeAnimation();
        }
        /// <summary>
        /// Loads in the contentmanager and fade transistion animation.
        /// Calls the loadcontent function of the current screen.
        /// </summary>
        /// <param name="Content"></param>
        public void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(content);

            fadeTexture = content.Load<Texture2D>("ScreenFade");
            fade.LoadContent(content, fadeTexture, "", Vector2.Zero,null);
            fade.Scale = dimensions.Y;
        }
        /// <summary>
        /// calls the update function of the current screen, check and return the value from the exit function of the current screen.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns></returns>
        public bool Update(GameTime gameTime) 
        {
            bool exit = false;
            if (!transition)
            {
                currentScreen.Update(gameTime);
                exit = currentScreen.Exit();
            }
            else
            {
                Transition(gameTime);
            }
            return exit;
        }
        /// <summary>
        /// Calls the unloadcontent functions for the current screen and clears the screen stack, unloads the fade animation.
        /// </summary>
        public void UnloadContent() 
        {
            fade.UnloadContent();
            screenStack.Clear();
            currentScreen.UnloadContent();
            content.Unload();
        }
        /// <summary>
        /// Calls the drawfunction of the current screen. and calls the draw function if we are transitioning between screens
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) 
        {
            currentScreen.Draw(spriteBatch);
            if(transition)
                fade.Draw(spriteBatch);
        }

        #endregion
        #region Private methods
        /// <summary>
        /// Updates the fade animation, transition and switches between the old and new screen. 
        /// </summary>
        /// <param name="gameTime"></param>
        private void Transition(GameTime gameTime) 
        {
            fade.Update(gameTime);
            if (fade.Alpha == 1.0f && fade.Timer.TotalSeconds == 1.0f) 
            {
                screenStack.Push(newScreen);
                currentScreen.UnloadContent();
                currentScreen = newScreen;
                currentScreen.LoadContent(content);
            }
            else if (fade.Alpha == 0.0f) 
            {
                transition = false;
                fade.Active = false;
            }
        }
        #endregion
    }
}
