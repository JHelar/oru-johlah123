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
    class GameOverScreen : GameScreen
    {
        SpriteFont font;
        String inputText;

        HighScore highScore;

        KeyboardState keyState, oldKeyState;

        public GameOverScreen(HighScore highScore) 
        {
            this.highScore = highScore;
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            keyState = new KeyboardState();
            oldKeyState = new KeyboardState();
            font = Content.Load<SpriteFont>("PacGameFont");
            inputText = " ";

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            highScore.UnloadContent();
        }

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
                        highScore.addPlayer(inputText);
                        highScore.CurrName = inputText;
                        highScore.saveScore();
                        ScreenManager.Instance.AddScreen(new MainMenu());
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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "GAME OVER!", new Vector2(230, 10), Color.White);
            spriteBatch.DrawString(font, "You scored: " + Convert.ToString(highScore.CurrScore) + " points!", new Vector2(120 - (Convert.ToString(highScore.CurrScore).Length / 2 * 10), 20), Color.White);
            spriteBatch.DrawString(font, "Enter your Name: ", new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, inputText, new Vector2(140, 30), Color.White);
        }
    }
}
