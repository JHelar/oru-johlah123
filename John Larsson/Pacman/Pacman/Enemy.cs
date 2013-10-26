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
        Vector2 position,tempCurrentFrame;
        Queue<Vector2> paths = new Queue<Vector2>();
        PathFinding pathFinding;
        Animation enemyAnimation = new Animation();

        float moveSpeed = 1f;
        bool newPath;
        Vector2 velocity;

        public Vector2 EnemyPosition 
        {
            get { return position; }
        }

        public float distanceToDestination
        {
            get { return Vector2.Distance(position, paths.Peek()); }
        }
  
        public void Init(Collision col,Player player,Vector2 position) 
        {
            newPath = true;
            velocity = Vector2.Zero;
            pathFinding = new PathFinding();
            this.position = position;
            enemyAnimation.Init(this.position,new Vector2(1,1));
            tempCurrentFrame = Vector2.Zero;
            pathFinding.Init(col, player.PlayerPosition, this.position);
        }

        public void UnloadContent() 
        {
            enemyImage = null;
            position = Vector2.Zero;
            tempCurrentFrame = Vector2.Zero;
            paths.Clear();
            pathFinding = null;
            enemyAnimation.UnloadContent();
        }

        public void setPath(Queue<Vector2> paths) 
        {
            foreach (Vector2 path in paths)
                this.paths.Enqueue(path);
            if (paths.Count > 0)
                this.position = this.paths.Dequeue();
            else
                newPath = true;
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
            position = enemyAnimation.Position;
            if (newPath)
            {
                pathFinding.ClearPath(col, player.PlayerPosition, position);
                pathFinding.PathFinder();
                paths.Clear();
                setPath(pathFinding.Path);
                newPath = false;
            }
            if (paths.Count > 0)
            {
                if (distanceToDestination < moveSpeed)
                {
                    position = paths.Peek();
                    paths.Dequeue();
                }
                else
                {
                    Vector2 direction = paths.Peek() - position;
                    direction.Normalize();
                    if (direction.X > 0)
                        position.X += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
                    else if (direction.X < 0)
                        position.X -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
                    else if (direction.Y > 0)
                        position.Y += moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
                    else if (direction.Y < 0)
                        position.Y -= moveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 100;
                }
            }
            else
            {
                newPath = true;
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
