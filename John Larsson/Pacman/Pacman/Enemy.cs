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
    public class Enemy
    {
        enum EnemyState
        {
            Normal, Run, Right, Left, Up, Down
        };

        EnemyState enemyState;
        Texture2D EnemyImage;
        Vector2 tempCurrentFrame,enemyPosition;

        float moveSpeed;
        bool active;

        Animation enemyAnimation = new Animation();
        Rectangle tempRect, enemyTempRect, tempRect2, tempRect3, tempRect4;

        public bool Active 
        {
            get { return active; }
            set { active = value; }
        }

        public void Init() 
        {
            enemyState = EnemyState.Right;
            moveSpeed = 100f;
            enemyPosition = new Vector2(220, 220);
            tempCurrentFrame = Vector2.Zero;
            enemyAnimation.Init(enemyPosition, new Vector2(1, 1));
            active = true;

        }

        public void LoadContent(ContentManager Content) 
        {
            enemyAnimation.Position = new Vector2(560, 550);
            EnemyImage = Content.Load<Texture2D>("PacEnemyAnim");
            enemyAnimation.AnimationImage = EnemyImage;
        }

        public void Update(GameTime gameTime, Player player, Collision col, Layers layer) 
        {
            enemyAnimation.Active = true;
            if (active) 
            {
                if (enemyPosition.X < player.PlayerPosition.X) 
                {
                    enemyState = EnemyState.Right;
                }
                else if (enemyPosition.X > player.PlayerPosition.X) 
                {
                    enemyState = EnemyState.Left;
                }
                else if (enemyPosition.Y < player.PlayerPosition.Y) 
                {
                    enemyState = EnemyState.Down;
                }
                else if (enemyPosition.Y > player.PlayerPosition.Y) 
                {
                    enemyState = EnemyState.Up;
                }
                if (enemyState == EnemyState.Right) 
                {
                    enemyPosition.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    tempCurrentFrame.X = 0;
                }
                else if (enemyState == EnemyState.Left) 
                {
                    enemyPosition.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    tempCurrentFrame.X = 0;
                }
                else if (enemyState == EnemyState.Down) 
                {
                    enemyPosition.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    tempCurrentFrame.X = 0;
                }
                else if (enemyState == EnemyState.Up) 
                {
                    enemyPosition.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    tempCurrentFrame.X = 0;
                }
                tempCurrentFrame.Y = enemyAnimation.CurrentFrame.Y;
                enemyAnimation.CurrentFrame = tempCurrentFrame;

                enemyTempRect = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, (int)enemyAnimation.FrameWidth,(int)enemyAnimation.FrameHeight);
                for (int i = 0; i < col.CollisionMap.Count; i++)
                {
                    for (int j = 0; j < col.CollisionMap[i].Count; j++)
                    {
                        if (col.CollisionMap[i][j].X == 999 && col.CollisionMap[i][j].Y == 999)
                        {
                            
                        }
                        else
                        {
                            tempRect = new Rectangle((int)col.CollisionMap[i][j].X, (int)col.CollisionMap[i][j].Y, (int)layer.TileDimensions.X - 2, (int)layer.TileDimensions.Y - 2);
                            if (enemyTempRect.Intersects(tempRect))
                            {
                                // Kollission
                                enemyPosition = enemyAnimation.Position;

                                if (col.CollisionMap[i][j+1].X == 999 && enemyState != EnemyState.Right) 
                                {
                                    enemyState = EnemyState.Right;
                                }
                                else if (col.CollisionMap[i+1][j].X == 999 && enemyState != EnemyState.Down) 
                                {
                                    enemyState = EnemyState.Down;
                                }
                                else if (col.CollisionMap[i-1][j].X == 999 && enemyState != EnemyState.Up) 
                                {
                                    enemyState = EnemyState.Up;
                                }
                                else if (col.CollisionMap[i][j-1].X == 999 && enemyState != EnemyState.Left) 
                                {
                                    enemyState = EnemyState.Left;
                                }
                            }
                            else
                            {
                                //Ingen kollission

                            }
                        }
                    }
                }
                enemyAnimation.Position = enemyPosition;
                enemyAnimation.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            enemyAnimation.Draw(spriteBatch);
        }
    }
}
