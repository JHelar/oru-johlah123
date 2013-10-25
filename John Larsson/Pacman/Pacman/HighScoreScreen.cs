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
    public class HighScoreScreen : GameScreen
    {
        HighScore highScore;
        KeyboardState keyState;
        FadeAnimation textFade;

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

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            textFade.Update(gameTime);
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
                ScreenManager.Instance.AddScreen(new MainMenu());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            highScore.Draw(spriteBatch);
            textFade.Draw(spriteBatch);
        }

    }
}
