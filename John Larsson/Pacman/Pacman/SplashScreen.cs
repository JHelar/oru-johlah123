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
    /// A splash screen that is shown before the title screen
    /// </summary>
    public class SplashScreen : GameScreen
    {
        #region Variables
        KeyboardState keyState;
        SpriteFont font;
        List<FadeAnimation> fade;
        List<Texture2D> images;

        FileManager fileManager;

        int imageNumber;
        #endregion
        #region Public mathods
        /// <summary>
        /// Loads the Splash screen images that will be transistioned between which are given from the text file.
        /// Loads them into their fade animation.
        /// </summary>
        /// <param name="Content"></param>
        public override void LoadContent(ContentManager Content) 
        {
            base.LoadContent(Content);
            if (font == null)
                font = content.Load<SpriteFont>("PacFont");

            imageNumber = 0;
            fileManager = new FileManager();
            fade = new List<FadeAnimation>();
            images = new List<Texture2D>();

            fileManager.LoadContent("Load/SplashScreen.cme", attributes, contents);

            for (int i = 0; i < attributes.Count; i++) 
            {
                for (int j = 0; j < attributes[i].Count; j++) 
                {
                    switch (attributes[i][j]) 
                    {
                        case "Image":
                            images.Add(content.Load<Texture2D>(contents[i][j]));
                            fade.Add(new FadeAnimation());
                            break; 
                    }
                }
            }

            for (int i = 0; i < fade.Count; i++) 
            {
                fade[i].FadeSpeed = 0.5f;
                fade[i].LoadContent(content, images[i], "", Vector2.Zero,null);
                fade[i].Scale = 1.0f;
                fade[i].Active = true;
            }
        }
        /// <summary>
        /// Unloads the content, called when a new screen has been added
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            fileManager = null;
        }
        /// <summary>
        /// Fades in and out the images until the last screen has been shown then transtition to the Titelscreen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
            fade[imageNumber].Update(gameTime);

            if (fade[imageNumber].Alpha == 0.0f && imageNumber != fade.Count)
                imageNumber++;
            if (imageNumber == fade.Count)
                ScreenManager.Instance.AddScreen(new TitelScreen(), fade[imageNumber -1].Alpha);
        }
        /// <summary>
        /// Draw the splash screen images
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (imageNumber == fade.Count)
                fade[imageNumber - 1].Draw(spriteBatch);
            else
                fade[imageNumber].Draw(spriteBatch);
        }
        #endregion
    }
}
