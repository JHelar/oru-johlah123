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
    /// A screen class that displays the highscore list
    /// </summary>
    public class HighScoreScreen : GameScreen
    {
        #region Variables
        HighScore highScore;
        KeyboardState keyState;
        FadeAnimation textFade;
        #endregion
        #region Public methods
        /// <summary>
        /// Initializes the variables and loads the text to be fade-animated, loads the highscore from the highscore XML file
        /// </summary>
        /// <param name="Content"></param>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            highScore = new HighScore();
            keyState = new KeyboardState();
            textFade = new FadeAnimation();

            textFade.LoadContent(Content,null,"Press Enter to go back to Main Menu",new Vector2(80,540),"PacGameFont");
            textFade.Active = true;

            highScore.Init(Content);
            highScore.LoadScore("PacScore", Content);
        }
        /// <summary>
        /// Unloads the highscore class and fadeanimation class, called when a new screen is added
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            highScore.UnloadContent();
            textFade.UnloadContent();
        }
        /// <summary>
        /// checks to see if the user has pressed the Enter key, if so change the screen to a Main menu screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            textFade.Update(gameTime);
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
                ScreenManager.Instance.AddScreen(new MainMenu());
        }
        /// <summary>
        /// Draws the highscore list and text fade animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            highScore.Draw(spriteBatch);
            textFade.Draw(spriteBatch);
        }
        #endregion
    }
}
