using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Texture2D enemyImage;
        Vector2 position,goalPosition,distanceToGoal,tempCurrentFrame;
        Rectangle enemyRect;

        Animation enemyAnimation = new Animation();

        enum EnemyCurrentDirection
        {
            Up, Down, Left, Right
        };

        public Vector2 EnemyPosition 
        {
            get { return position; }
        }

        EnemyCurrentDirection enemyDirection;
        bool goDown;
        bool goRight;
        bool goalReached;
        bool moveMade;
        bool reCalculate;

        float moveSpeed = 150f;

        public void Init() 
        {
            position = new Vector2(220, 260);
            enemyAnimation.Init(position,new Vector2(1,1));
            tempCurrentFrame = Vector2.Zero;
            goalReached = true;
        }

        public void LoadContent(ContentManager content) 
        {
            enemyImage = content.Load<Texture2D>("PacEnemyAnim");
            enemyAnimation.Position = position;
            enemyAnimation.AnimationImage = enemyImage;
        }

        public void Update(Player player,Collision col,Layers layer,GameTime gameTime) 
        {
            enemyAnimation.Active = true;
            
            if (position == goalPosition)
                goalReached = true;
            if (goalReached)
            {
                goalPosition = player.PlayerPosition;
                distanceToGoal = new Vector2(goalPosition.X - position.X, goalPosition.Y - position.Y);
                if (distanceToGoal.X > 0)
                {
                    goRight = true;
                    enemyDirection = EnemyCurrentDirection.Right;
                    if (distanceToGoal.Y > 0)
                        goDown = true;
                    else
                        goDown = false;

                }
                if (distanceToGoal.X < 0)
                {
                    goRight = false;
                    enemyDirection = EnemyCurrentDirection.Left;
                    if (distanceToGoal.Y > 0)
                        goDown = true;
                    else
                        goDown = false;
                }
                goalReached = false;

            }
            #region Enemy movement and collision
            moveMade = false;
            reCalculate = false;
            moveMade = false;
            if (enemyDirection == EnemyCurrentDirection.Right && !moveMade)
            {
                position.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                goalPosition.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enemyRect = new Rectangle((int)position.X, (int)position.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y);
                for (int i = 0; i < col.CollisionMap.Count; i++)
                {
                    for (int j = 0; j < col.CollisionMap[i].Count; j++)
                    {
                        if (enemyRect.Intersects(new Rectangle((int)col.CollisionMap[i][j].X, (int)col.CollisionMap[i][j].Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y)))
                        {
                            position = enemyAnimation.Position;
                            if (goDown)
                            {
                                enemyDirection = EnemyCurrentDirection.Down;
                                if (col.Contents[i + 1][j - 1] == "x")
                                {
                                    reCalculate = true;
                                }
                            }
                            else if (!goDown)
                            {
                                if (col.Contents[i - 1][j - 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Up;
                                }
                                else 
                                {
                                    reCalculate = true;
                                }
                            }
                        }
                    }
                }
                moveMade = true;
            }
            if (enemyDirection == EnemyCurrentDirection.Left && !moveMade)
            {
                position.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enemyRect = new Rectangle((int)position.X, (int)position.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y);
                for (int i = 0; i < col.CollisionMap.Count; i++)
                {
                    for (int j = 0; j < col.CollisionMap[i].Count; j++)
                    {
                        if (enemyRect.Intersects(new Rectangle((int)col.CollisionMap[i][j].X, (int)col.CollisionMap[i][j].Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y)))
                        {
                            position = enemyAnimation.Position;
                            if (goDown)
                            {

                                if (col.Contents[i + 1][j + 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Down;
                                }
                                else 
                                {
                                    reCalculate = true;
                                }
                            }
                            else if (!goDown)
                            {
                                if (col.Contents[i - 1][j + 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Up;
                                }
                                else
                                {
                                    reCalculate = true;
                                }
                            }
                        }
                    }
                }
                moveMade = true;
            }
            if (enemyDirection == EnemyCurrentDirection.Down && !moveMade)
            {
                position.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enemyRect = new Rectangle((int)position.X, (int)position.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y);
                for (int i = 0; i < col.CollisionMap.Count; i++)
                {
                    for (int j = 0; j < col.CollisionMap[i].Count; j++)
                    {
                        if (enemyRect.Intersects(new Rectangle((int)col.CollisionMap[i][j].X, (int)col.CollisionMap[i][j].Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y)))
                        {
                            position = enemyAnimation.Position;
                            if (goRight)
                            {
                                if (col.Contents[i - 1][j + 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Right;
                                }
                                else
                                {
                                    reCalculate = true;
                                }
                            }
                            else if (!goRight)
                            {
                                if (col.Contents[i - 1][j - 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Left;
                                }
                                else
                                {
                                    reCalculate = true;
                                }
                            }
                        }
                    }
                }
                moveMade = true;
            }
            if (enemyDirection == EnemyCurrentDirection.Up && !moveMade)
            {
                position.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enemyRect = new Rectangle((int)position.X, (int)position.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y);
                for (int i = 0; i < col.CollisionMap.Count; i++)
                {
                    for (int j = 0; j < col.CollisionMap[i].Count; j++)
                    {
                        if (enemyRect.Intersects(new Rectangle((int)col.CollisionMap[i][j].X, (int)col.CollisionMap[i][j].Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y)))
                        {
                            position = enemyAnimation.Position;
                            if (goRight)
                            {
                                if (col.Contents[i + 1][j + 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Right;
                                }
                                else
                                {
                                    reCalculate = true;
                                }
                            }
                            else if (!goRight)
                            {
                                enemyDirection = EnemyCurrentDirection.Left;
                                if (col.Contents[i + 1][j - 1] == "o")
                                {
                                    enemyDirection = EnemyCurrentDirection.Left;
                                }
                                else
                                {
                                    reCalculate = true;
                                }
                            }

                        }
                    }
                }
                moveMade = true;
            }
            #endregion
            if (reCalculate) 
            {
                distanceToGoal = new Vector2(goalPosition.X - position.X, goalPosition.Y - position.Y);
                if (distanceToGoal.X > 0 && distanceToGoal.X <= 0)
                {
                    goRight = true;
                    enemyDirection = EnemyCurrentDirection.Right;
                    if (distanceToGoal.Y > 0)
                        goDown = true;
                    else
                        goDown = false;

                }
                if (distanceToGoal.X < 0 && distanceToGoal.X >= 0)
                {
                    goRight = false;
                    enemyDirection = EnemyCurrentDirection.Left;
                    if (distanceToGoal.Y > 0)
                        goDown = true;
                    else
                        goDown = false;
                }
                else 
                {
                    if (distanceToGoal.Y > 0)
                    {
                        enemyDirection = EnemyCurrentDirection.Up;
                        goDown = false;
                        goRight = true;
                    }
                    else
                    {
                        enemyDirection = EnemyCurrentDirection.Down;
                        goDown = true;
                        goRight = false;
                    }
                }
            }
            enemyAnimation.CurrentFrame = tempCurrentFrame;
            enemyAnimation.Position = position;
            enemyAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            enemyAnimation.Draw(spriteBatch);
        }
    }
}
