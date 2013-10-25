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
    public class SplashScreen : GameScreen
    {
        KeyboardState keyState;
        SpriteFont font;
        List<FadeAnimation> fade;
        List<Texture2D> images;

        FileManager fileManager;

        int imageNumber;

        public override void LoadContent(ContentManager Content) 
        {
            base.LoadContent(Content);
            if (font == null)
                font = content.Load<SpriteFont>("PacFont");

            imageNumber = 0;
            fileManager = new FileManager();
            fade = new List<FadeAnimation>();
            images = new List<Texture2D>();

            fileManager.LoadContent("Load/SplashScreen.cme", attributes, contents);

            for (int i = 0; i < attributes.Count; i++) 
            {
                for (int j = 0; j < attributes[i].Count; j++) 
                {
                    switch (attributes[i][j]) 
                    {
                        case "Image":
                            images.Add(content.Load<Texture2D>(contents[i][j]));
                            fade.Add(new FadeAnimation());
                            break;
                        
                    }
                }
            }

            for (int i = 0; i < fade.Count; i++) 
            {
                fade[i].FadeSpeed = 0.5f;
                fade[i].LoadContent(content, images[i], "", Vector2.Zero);
                fade[i].Scale = 1.0f;
                fade[i].Active = true;
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            fileManager = null;
        }

        public override void Update(GameTime gameTime)
        {
            
            fade[imageNumber].Update(gameTime);

            if (fade[imageNumber].Alpha == 0.0f && imageNumber != fade.Count)
                imageNumber++;
            if (imageNumber == fade.Count)
                ScreenManager.Instance.AddScreen(new TitelScreen(), fade[imageNumber -1].Alpha);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (imageNumber == fade.Count)
                fade[imageNumber - 1].Draw(spriteBatch);
            else
                fade[imageNumber].Draw(spriteBatch);
        }
    }
}
