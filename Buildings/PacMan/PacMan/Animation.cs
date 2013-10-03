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

namespace PacMan
{
    class Animation
    {
        Texture2D animation;
        Rectangle sourceRect;
        Vector2 position;

        float elapsed;
        float frameTime;
        int numOfFrames;
        int currentFrame;
        int width;
        int height;
        int frameHight;
        int frameWidth;
        bool looping;

        public Animation(ContentManager Content, string spriteName, float frameSpeed, int numOfFrames, bool looping) 
        {
            this.frameTime = frameSpeed;
            this.numOfFrames = numOfFrames;
            this.looping = looping;
            this.animation = Content.Load<Texture2D>(spriteName);
            frameWidth = (animation.Width / numOfFrames);
            frameHight = animation.Height;
            position = new Vector2(100, 100);

        }

        public void PlayAnimation(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHight);

            if (elapsed >= frameTime)
            {
                if(currentFrame >= numOfFrames - 1)
                {
                    if (looping)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame++;
                    }
                    elapsed = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(animation, position, sourceRect, Color.Purple, 0f, new Vector2(0, 0),1f ,SpriteEffects.None, 1f);
        }
    }
}
