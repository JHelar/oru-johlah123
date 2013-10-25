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

        #region Huvudmetoder

        public void AddScreen(GameScreen screen) 
        {
            transition = true;
            newScreen = screen;
            fade.Active = true;
            fade.Alpha = 0.0f;
            fade.ActivateValue = 1.0f;    
        }

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
        public void Init() 
        {
            currentScreen = new SplashScreen();
            fade = new FadeAnimation();
        }
        public void LoadContent(ContentManager Content) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(content);

            fadeTexture = content.Load<Texture2D>("ScreenFade");
            fade.LoadContent(content, fadeTexture, "", Vector2.Zero);
            fade.Scale = dimensions.Y;
        }
        public void Update(GameTime gameTime) 
        {
            if (!transition)
                currentScreen.Update(gameTime);
            else
                Transition(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            currentScreen.Draw(spriteBatch);
            if(transition)
                fade.Draw(spriteBatch);
        }

        #endregion

        #region Privata metoder

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
