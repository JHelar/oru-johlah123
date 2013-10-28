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
    /// <summary>
    /// Enemy calss, with pathfinding AI
    /// </summary>
    public class Enemy
    {
        #region Variables
        Texture2D enemyImage;
        Vector2 position,tempCurrentFrame;
        Queue<Vector2> paths = new Queue<Vector2>();
        PathFinding pathFinding;
        Animation enemyAnimation = new Animation();

        float moveSpeed = 1f;
        bool newPath;
        Vector2 velocity;

        int reCalculate, reCalculateValue;
        #endregion
        #region Properties
        public Vector2 EnemyPosition 
        {
            get { return position; }
        }

        public float distanceToDestination
        {
            get { return Vector2.Distance(position, paths.Peek()); }
        }
        #endregion
        #region Public mathods
        /// <summary>
        /// Gets the current posisiton of the player, the start position of the enemy, and a value that will determine when the enemy should recalculate the path to the player.
        /// Also Initializes the pathfinding for the enemy.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="player"></param>
        /// <param name="position"></param>
        /// <param name="reCalculate"></param>
        public void Init(Collision col,Player player,Vector2 position,int reCalculate) 
        {
            this.reCalculate = reCalculate;
            reCalculateValue = 0;
            newPath = true;
            velocity = Vector2.Zero;
            pathFinding = new PathFinding();
            this.position = position;
            enemyAnimation.Init(this.position,new Vector2(1,1));
            tempCurrentFrame = Vector2.Zero;
            pathFinding.Init(col, player.PlayerPosition, this.position);
        }
        /// <summary>
        /// Unloads the enemy class, called when a new screen has been added
        /// </summary>
        public void UnloadContent() 
        {
            enemyImage = null;
            position = Vector2.Zero;
            tempCurrentFrame = Vector2.Zero;
            paths.Clear();
            pathFinding = null;
            enemyAnimation.UnloadContent();
        }
        /// <summary>
        /// Sets the path given from the pathfinding class.
        /// Forces a recalculation if the queue returns empty.
        /// </summary>
        /// <param name="paths"></param>
        public void setPath(Queue<Vector2> paths) 
        {
            foreach (Vector2 path in paths)
                this.paths.Enqueue(path);
            if (paths.Count > 0)
                this.position = this.paths.Dequeue();
            else
                reCalculateValue++;
                newPath = true;
        }
        /// <summary>
        /// Loads the enemy texture and enemy animation.
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content) 
        {
            enemyImage = content.Load<Texture2D>("PacEnemyAnim");
            enemyAnimation.Position = position;
            enemyAnimation.AnimationImage = enemyImage;
        }
        /// <summary>
        /// Recalculates a new pathfinding path and sets it, calculates it's movement in the right direction and updates it's position and gives that to the enemy animation.
        /// Dequeues a waypoint if the enemy has reached it.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="col"></param>
        /// <param name="layer"></param>
        /// <param name="gameTime"></param>
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
                newPath = true;
            if (reCalculateValue >= reCalculate)
            {
                reCalculateValue = 0;
                newPath = true;
            }
            else
                reCalculateValue++;
            enemyAnimation.CurrentFrame = tempCurrentFrame;
            enemyAnimation.Position = position;
            enemyAnimation.Update(gameTime);
        }
        /// <summary>
        /// Calls the draw function from the animation class
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) 
        {
            enemyAnimation.Draw(spriteBatch);
        }
        #endregion
    }
}
