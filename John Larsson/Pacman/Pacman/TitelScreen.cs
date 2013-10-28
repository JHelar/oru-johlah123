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
    /// Titel screen, shown after the splash screen before the main menu screen
    /// </summary>
    public class TitelScreen : GameScreen
    {
        #region Variables
        KeyboardState keyState;

        Animation animation;
        FadeAnimation fade,textFade;
        Texture2D image;
        Vector2 animationPosition;
        #endregion
        #region Public methods
        /// <summary>
        /// Loads the text fade and screen fade animation. Loads in a computer contoled character animation.
        /// </summary>
        /// <param name="Content"></param>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            fade = new FadeAnimation();
            textFade = new FadeAnimation();
            image = content.Load<Texture2D>("TitelScreen/PacTitel");
            fade.LoadContent(content, image, "", Vector2.Zero,null);
            textFade.LoadContent(content, null, "Press Enter to Start", new Vector2(80, 540),"PacFont");
            fade.Scale = 1.0f;
            textFade.Active = true;
            fade.Active = false;
            fade.FadeSpeed = 1.0f;
            animationPosition = new Vector2(-40, 340);
            animation = new Animation();
            animation.Init(new Vector2(-40, 340), new Vector2(12, 1));
            animation.AnimationImage = content.Load<Texture2D>("TitelScreen/TitelPacAnim");
            animation.Active = true;
        }
        /// <summary>
        /// Unloads the content and fade animations.
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            fade.UnloadContent();
            textFade.UnloadContent();
            image = null;
        }
        /// <summary>
        /// Updates the fade animations and the character animation and it's position.
        /// And checks if the user has pressed the Enter key transitions to the main menu screen.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            animationPosition = animation.Position;
            animationPosition.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (animationPosition.X >= 560)
                animationPosition.X = -40;
            animation.Position = animationPosition;
            animation.Update(gameTime);
            fade.Update(gameTime);
            textFade.Update(gameTime);
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
                ScreenManager.Instance.AddScreen(new MainMenu());
        }
        /// <summary>
        /// Draws the fade animations and the character animations.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            fade.Draw(spriteBatch);
            textFade.Draw(spriteBatch);
            animation.Draw(spriteBatch);
        }
        #endregion
    }
}
