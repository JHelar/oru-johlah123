using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Pacman
{
    public class ScreenAnimation
    {
        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle sourceRect;
        protected ContentManager content;
        protected bool active;
        protected float rotation, scale, axis;
        protected Vector2 origin, position;
        protected float alpha;

        public virtual float Alpha 
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public bool Active 
        {
            get { return active; }
            set { active = value; }
        }

        public float Scale 
        {
            set { scale = value; } 
        }
        public virtual void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position,string fontID) 
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            this.image = image;
            this.text = text;
            this.position = position;
            if (text != String.Empty)
            {
                font = content.Load<SpriteFont>(fontID);
                color = new Color(255, 255, 255);
            }
            if (image != null)
                sourceRect = new Rectangle(0, 0, image.Width, image.Height);
            rotation = 0.0f;
            axis = 0.0f;
            scale = alpha = 1.0f;
            active = false;
        }

        public virtual void UnloadContent() 
        {
            content.Unload();
            text = String.Empty;
            position = Vector2.Zero;
            sourceRect = Rectangle.Empty;
            image = null;
                
        }

        public virtual void Update(GameTime gameTime) 
        {
            
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            if (image != null) 
            {
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

                spriteBatch.Draw(image, position + origin, sourceRect, Color.White * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }

            if (text != String.Empty) 
            {
                origin = new Vector2(font.MeasureString(text).X, font.MeasureString(text).Y);
                spriteBatch.DrawString(font, text, position + origin, color * alpha, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
        }

    }
}
