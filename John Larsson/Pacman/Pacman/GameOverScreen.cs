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
    /// The screen that appears when you lost or won the game
    /// </summary>
    class GameOverScreen : GameScreen
    {
        #region Variables
        SpriteFont font,bigFont;
        String inputText;
        FadeAnimation textFade;

        HighScore highScore;

        KeyboardState keyState, oldKeyState;
        #endregion
        #region Public methods
        /// <summary>
        /// Constructor that gets the current highscore class
        /// </summary>
        /// <param name="highScore"></param>
        public GameOverScreen(HighScore highScore) 
        {
            this.highScore = highScore;
        }
        /// <summary>
        /// Loads in all the fonts, sets the textfade animation to true,and initializes all the variables.
        /// </summary>
        /// <param name="Content"></param>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            textFade = new FadeAnimation();
            keyState = new KeyboardState();
            oldKeyState = new KeyboardState();
            font = Content.Load<SpriteFont>("PacGameFont");
            bigFont = Content.Load<SpriteFont>("PacFont");
            inputText = " ";
            textFade.LoadContent(Content, null, "Press Enter to go back to Main Menu", new Vector2(80, 540), "PacGameFont");
            textFade.Active = true;

        }
        /// <summary>
        /// Unloads the highscore class and the base class, called when a new screen is added
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            highScore.UnloadContent();
        }
        /// <summary>
        /// Gets the keyboard input for the player name text input dialog, saves the highscore when eneter is press, 
        /// the user then also is taken back to the mainmenu by adding a new MainMenu screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();

            Keys[] pressedKeys;
            pressedKeys = keyState.GetPressedKeys();

            foreach (Keys key in pressedKeys) 
            {
                if(oldKeyState.IsKeyUp(key))
                {
                    if (key == Keys.Back)
                        inputText = inputText.Remove(inputText.Length - 1, 1);
                    else if (key == Keys.Enter)
                    {
                        if (inputText != " ")
                        {
                            highScore.addPlayer(inputText);
                            highScore.CurrName = inputText;
                            highScore.saveScore();
                            ScreenManager.Instance.AddScreen(new MainMenu());
                        }
                    }
                    else
                    {
                        if (key == Keys.Space)
                            inputText = inputText.Insert(inputText.Length, " ");
                        else if (key == Keys.OemPeriod)
                            inputText = inputText.Insert(inputText.Length, ".");
                        else if (key == Keys.OemComma)
                            inputText = inputText.Insert(inputText.Length, ",");
                        else
                        {
                            inputText += key.ToString();
                        }
                    }
                }
            }
            textFade.Update(gameTime);
        }
        /// <summary>
        /// Draws the different texts and inputtext also the textfade animation draw function is called.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(bigFont, "GAME OVER!", new Vector2(200, 10), Color.White);
            spriteBatch.DrawString(font, "You scored: " + Convert.ToString(highScore.CurrScore) + " points!", new Vector2(120 - (Convert.ToString(highScore.CurrScore).Length / 2 * 10), 56), Color.White);
            spriteBatch.DrawString(font, "Enter your Name: ", new Vector2(30, 66), Color.White);
            spriteBatch.DrawString(font, inputText, new Vector2(170, 66), Color.White);
            textFade.Draw(spriteBatch);
        }
        #endregion
    }
}
