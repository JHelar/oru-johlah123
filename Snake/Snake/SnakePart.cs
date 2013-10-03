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

namespace Snake
{
    class SnakePart
    {
        Vector2 partPosition;
        Texture2D partTexture;
        Rectangle partRect;
        

        public SnakePart(ContentManager Content, Vector2 partPosition, string textureName) 
        {
            partTexture = Content.Load<Texture2D>(textureName);
            this.partPosition = partPosition;
            partRect = new Rectangle((int)partPosition.X,(int)partPosition.Y,(int)partTexture.Width,(int)partTexture.Height);

        }

        public Vector2 PartPosition 
        {
            get { return this.partPosition; }
            set { this.partPosition = value; }
        }

        public void DrawPart(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(partTexture,partRect,Color.Black);
        }
    }
}
