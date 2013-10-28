﻿using System;
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
    /// The player class
    /// </summary>
    public class Player
    {
        #region Variables
        Texture2D playerImage;
        Vector2 playerPosition,tempCurrentFrame;

        KeyboardState keyState;
        float moveSpeed = 100f;

        Animation playerAnimation = new Animation();

        Rectangle tempRect,playerTempRect;

        #endregion
        public Vector2 PlayerPosition 
        {
            get { return playerPosition; }
        }
        #region Public methods
        /// <summary>
        /// Sets the start position of the player.
        /// Sets the amount of frames the player animation have.
        /// </summary>
        public void Init() 
        {
            playerPosition = new Vector2(270, 500);
            playerAnimation.Init(playerPosition, new Vector2(8, 4));
            tempCurrentFrame = Vector2.Zero;
        }
        /// <summary>
        /// Loads in the animation image and the position of the animation.
        /// </summary>
        /// <param name="Content"></param>
        public void LoadContent(ContentManager Content) 
        {
            this.playerAnimation.Position = new Vector2(270,500);
            playerImage = Content.Load<Texture2D>("PacEatingAnim");
            this.playerAnimation.AnimationImage = playerImage;
        }
        /// <summary>
        /// Unloads the variables, called when a new screen has been added
        /// </summary>
        public void UnloadContent() 
        {
            playerImage = null;
            playerPosition = tempCurrentFrame = Vector2.Zero;
            moveSpeed = 0.0f;
            playerAnimation = null;
            playerTempRect = Rectangle.Empty;
            tempRect = Rectangle.Empty;
        }

        /// <summary>
        /// Moves the player depending on player input direction, checks collision with walls and food. Increases the highscore by 10 for eatch food eaten.
        /// Sets what animation direction that should be drawn.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="col"></param>
        /// <param name="layer"></param>
        /// <param name="highScore"></param>
        public void Update(GameTime gameTime,Collision col, Layers layer,HighScore highScore) 
        {
            keyState = Keyboard.GetState();
            this.playerAnimation.Active = true;

            this.playerPosition = this.playerAnimation.Position;

            if (keyState.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                tempCurrentFrame.Y = 3;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                tempCurrentFrame.Y = 2;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                playerPosition.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (playerPosition.X >= 560 && playerPosition.Y <= 290 || playerPosition.X >= 560 && playerPosition.Y >= 230)
                    playerPosition.X = -20;
                tempCurrentFrame.Y = 0;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (playerPosition.X <= 0 && playerPosition.Y <= 290 || playerPosition.X <= 0 && playerPosition.Y >= 230)
                    playerPosition.X = 560;
                tempCurrentFrame.Y = 1;
            }

            tempCurrentFrame.X = this.playerAnimation.CurrentFrame.X;

            playerTempRect = new Rectangle((int)playerPosition.X,(int)playerPosition.Y,(int)playerAnimation.FrameWidth -1,(int)playerAnimation.FrameHeight -1);

            this.playerAnimation.CurrentFrame = tempCurrentFrame;
            
            for (int i = 0; i < col.CollisionMap.Count; i++) 
            {
                for (int j = 0; j < col.CollisionMap[i].Count; j++)
                {
                    if (col.CollisionMap[i][j].X == 999 && col.CollisionMap[i][j].Y == 999)
                    {
                        if(tempCurrentFrame.Y == 0 || tempCurrentFrame.Y == 3)
                            tempRect = new Rectangle((int)col.FoodCollisionMap[i][j].X + 13, (int)col.FoodCollisionMap[i][j].Y, (int)layer.TileDimensions.X - 17, (int)layer.TileDimensions.Y - 13);
                        else if(tempCurrentFrame.Y == 1 || tempCurrentFrame.Y == 2)
                            tempRect = new Rectangle((int)col.FoodCollisionMap[i][j].X, (int)col.FoodCollisionMap[i][j].Y, (int)layer.TileDimensions.X - 17, (int)layer.TileDimensions.Y - 13);
                        if (playerTempRect.Intersects(tempRect)) 
                        {
                            if (layer.TileMap[0][i][j].X == 1 && layer.TileMap[0][i][j].Y == 0)
                            {
                                highScore.CurrScore += 10;
                            }
                            layer.TileMap[0][i][j] = new Vector2(2, 0);
                            
                        }
                    }
                    else 
                    {
                        tempRect = new Rectangle((int)col.CollisionMap[i][j].X, (int)col.CollisionMap[i][j].Y, (int)layer.TileDimensions.X -2, (int)layer.TileDimensions.Y -2);
                        if (playerTempRect.Intersects(tempRect))
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
            }
            this.playerAnimation.Position = playerPosition;
            this.playerAnimation.Update(gameTime);
        
        }
        /// <summary>
        /// Draws the player animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) 
        {
            this.playerAnimation.Draw(spriteBatch);
        }
        #endregion
    }
}
