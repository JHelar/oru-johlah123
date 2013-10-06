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
        float moveSpeed = 100f;

        Animation playerAnimation = new Animation();

        public void Init() 
        {
            playerPosition = new Vector2(270, 460);
            playerAnimation.Init(playerPosition, new Vector2(8, 1));
            tempCurrentFrame = Vector2.Zero;
        }

        public void LoadContent(ContentManager Content) 
        {
            this.playerAnimation.Position = new Vector2(270,460);
            playerImage = Content.Load<Texture2D>("PacEatingAnim");
            this.playerAnimation.AnimationImage = playerImage;
        }

        public void Update(GameTime gameTime,Collision col, Layers layer) 
        {
            keyState = Keyboard.GetState();
            this.playerAnimation.Active = true;

            this.playerPosition = this.playerAnimation.Position;

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

            tempCurrentFrame.X = this.playerAnimation.CurrenFrame.X;


            this.playerAnimation.CurrenFrame = tempCurrentFrame;
       
            for (int i = 0; i < col.CollisionMap.Count; i++) 
            {
                for (int j = 0; j < col.CollisionMap[i].Count; j++) 
                {
                    
                    if ((playerPosition.X < col.CollisionMap[i][j].X + 20 /*&& playerPosition.Y == col.CollisionMap[i][j].Y*/)||
                        (playerPosition.X + 20 > col.CollisionMap[i][j].X /*&& playerPosition.Y == col.CollisionMap[i][j].Y*/)||
                        (playerPosition.Y < col.CollisionMap[i][j].Y + 20 /*&& playerPosition.X == col.CollisionMap[i][j].X*/)||
                        (playerPosition.Y + 20 > col.CollisionMap[i][j].Y /*&& playerPosition.X == col.CollisionMap[i][j].X*/))
                    {
                        // Kollission
                        playerPosition = this.playerAnimation.Position;
                    }
                    else 
                    {
                        //Ingen kollission
                           
                    }
                    
                }
                
            }
            this.playerAnimation.Position = playerPosition;
            this.playerAnimation.Update(gameTime);
        
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            this.playerAnimation.Draw(spriteBatch);
        }
    }
}
