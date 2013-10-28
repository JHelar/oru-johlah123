using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    /// <summary>
    /// Class that checks if a gameover criteria has been met.
    /// </summary>
    public class GameOver
    {
        /// <summary>
        /// calls the two private mathods and return a true if the citeria has been met or false if not
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public bool CheckGameState(Player player, Enemy enemy, Layers layer) 
        {
            if(CheckEnemyPlayerCollision(player,enemy,layer) || CheckIfFoodEaten(layer))
                return true;
            return false;
        }
        #region Private methods
        /// <summary>
        /// Gets the player and enemy position checks if the two collides with eatchother
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        private bool CheckEnemyPlayerCollision(Player player, Enemy enemy, Layers layer)
        {
            if (new Rectangle((int)player.PlayerPosition.X, (int)player.PlayerPosition.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y).Intersects(new Rectangle((int)enemy.EnemyPosition.X, (int)enemy.EnemyPosition.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y)))
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Check to see if all the food tiles has been eaten
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private bool CheckIfFoodEaten(Layers layer) 
        {
            for (int k = 0; k < layer.TileMap.Count; k++) 
            {
                for (int i = 0; i < layer.TileMap[k].Count; i++) 
                {
                    for (int j = 0; j < layer.TileMap[k][i].Count; j++) 
                    {
                        if (layer.TileMap[k][i][j].X == 1 && layer.TileMap[k][i][j].Y == 0) 
                        {
                            return false;
                        }
                    }   
                }
            }
            return true;
        }
        #endregion
    }
}
