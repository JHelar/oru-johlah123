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
    public class Player
    {
        Texture2D playerImage;
        Vector2 playerPosition,tempCurrentFrame;

        KeyboardState keyState;
        float moveSpeed = 500f;

        Animation playerAnimation = new Animation();

        public void Init() 
        {
            playerPosition = new Vector2(100, 100);
            playerAnimation.Init(playerPosition, new Vector2(4, 1));
            tempCurrentFrame = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content) 
        {
            playerImage = Content.Load<Texture2D>("PacEatingAnim");
            playerAnimation.AnimationImage = playerImage;
        }

        public void Update(GameTime gameTime) 
        {
            keyState = Keyboard.GetState();
            playerAnimation.Active = true;

            playerPosition = playerAnimation.Position;

            if (keyState.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                tempCurrentFrame.Y = 0;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                tempCurrentFrame.Y = 0;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                playerPosition.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                tempCurrentFrame.Y = 0;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                tempCurrentFrame.Y = 0;
            }

            tempCurrentFrame.X = playerAnimation.CurrenFrame.X;

            playerAnimation.Position = playerPosition;
            playerAnimation.CurrenFrame = tempCurrentFrame;
            playerAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            playerAnimation.Draw(spriteBatch);
        }
    }
}
