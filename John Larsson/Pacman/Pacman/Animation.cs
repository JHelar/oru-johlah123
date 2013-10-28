using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pacman
{
    /// <summary>
    /// Animation class, for any kind of animation of a spritesheet.
    /// </summary>
    public class Animation
    {
        #region Variables
        int frameCounter, switchFrame,animationSpeed;

        bool active;
        Vector2 position, amountOfFrames, currentFrame;
        Texture2D animationImage;
        Rectangle sourcRect;
        #endregion
        #region Properties
        public bool Active 
        {
            get { return active; }
            set { active = value; }
        }

        public Vector2 CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public Vector2 Position 
        {
            get { return position; }
            set { position = value; }
        }

        public int FrameWidth 
        {
            get { return animationImage.Width / (int)amountOfFrames.X; }
        }

        public int FrameHeight 
        {
            get { return animationImage.Height / (int)amountOfFrames.Y; }
        }

        public Texture2D AnimationImage 
        {
            set { animationImage = value; }
        }

        public int AnimationSpeed 
        {
            set { animationSpeed = value; }
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Sets the start position,and the amount of frames the spritesheet has.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="amountOfFrames"></param>
        public void Init(Vector2 position,Vector2 amountOfFrames)
        {
            active = false;
            this.position = position;
            this.amountOfFrames = amountOfFrames;
            animationSpeed = 80;
        }
        /// <summary>
        /// Unloads the class, called when a new screen in added
        /// </summary>
        public void UnloadContent() 
        {
            position = amountOfFrames = currentFrame = Vector2.Zero;
            animationImage = null;
            sourcRect = Rectangle.Empty;
        }
        /// <summary>
        /// Sets when to switch frame, depends on the set animationspeed. Puts the framecounter back to 0 when a new frame is set. 
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime) 
        {
            switchFrame = animationSpeed;
            if(this.active)
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            else if(!this.active)
                frameCounter = 0;
            if (frameCounter > switchFrame)  
            {
                frameCounter = 0;
                currentFrame.X += FrameWidth;
                if (currentFrame.X >= animationImage.Width)
                    currentFrame.X = 0;
                
            }
            sourcRect = new Rectangle((int)currentFrame.X, (int)currentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }
        /// <summary>
        /// Draws the current frame of the animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(animationImage, position, sourcRect, Color.White);
        }
        #endregion
    }
}
