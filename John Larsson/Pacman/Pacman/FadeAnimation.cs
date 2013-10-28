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
    /// A fade animation class that fades in and out a image or text, usable for screentransitions
    /// </summary>
    public class FadeAnimation : ScreenAnimation
    {
        #region Variables
        bool increase;
        float fadeSpeed;
        TimeSpan defaultTime, timer;
        float activateValue;
        bool stopUpdating;
        float defaultAlpha;

        #endregion

        #region Properties

        /// <summary>
        /// FadeAnimation properties
        /// </summary>
        public TimeSpan Timer 
        {
            get { return timer; }
            set { defaultTime = value; timer = defaultTime; }
        }

        public float FadeSpeed 
        {
            get { return fadeSpeed; }
            set { fadeSpeed = value; }
        }

        public override float Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;

                if (alpha == 1.0f)
                    increase = false;
                else if (alpha == 0.0f)
                    increase = true;
            }
        }

        public float ActivateValue 
        {
            get { return activateValue; }
            set { activateValue = value; }
        }

        public bool Increase 
        {
            set { increase = value; }
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Loads in a image, a text string the position in which we want these elements to be drawn on, and the font for the text.
        /// sets the default timespan variable to 1 milisecond
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="image"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        /// <param name="fontID"></param>
        public override void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position,string fontID)
        {
            base.LoadContent(Content, image, text, position,fontID);
            increase = false;
            fadeSpeed = 1.0f;
            defaultTime = new TimeSpan(0, 0, 1);
            timer = defaultTime;
            activateValue = 0.0f;
            stopUpdating = false;
            defaultAlpha = alpha;
        }
        /// <summary>
        /// Changes the alpha channel value, the value that determines transparency. Fades in or out depending on the increase boolean value.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (active)
            {
                if (!stopUpdating)
                {
                    if (!increase)
                        alpha -= fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else
                        alpha += fadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (alpha <= 0.0f)
                    {
                        alpha = 0.0f;
                        increase = true;
                    }
                    else if (alpha >= 1.0f)
                    {
                        alpha = 1.0f;
                        increase = false;
                    }
                }

                if (alpha == activateValue) 
                {
                    stopUpdating = true;
                    timer -= gameTime.ElapsedGameTime;
                    if (timer.TotalSeconds <= 0) 
                    {
                        timer = defaultTime;
                        stopUpdating = false;
                    }
                }
            }
            else 
            {
                alpha = defaultAlpha;
            }
        }
        #endregion
    }
}
