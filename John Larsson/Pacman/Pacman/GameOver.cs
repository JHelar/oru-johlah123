using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class GameOver
    {
        public bool CheckGameState(Player player, Enemy enemy, Layers layer) 
        {
            if(CheckEnemyPlayerCollision(player,enemy,layer) || CheckIfFoodEaten(layer))
                return true;
            return false;
        }

        private bool CheckEnemyPlayerCollision(Player player, Enemy enemy, Layers layer)
        {
            if (new Rectangle((int)player.PlayerPosition.X, (int)player.PlayerPosition.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y).Intersects(new Rectangle((int)enemy.EnemyPosition.X, (int)enemy.EnemyPosition.Y, (int)layer.TileDimensions.X, (int)layer.TileDimensions.Y)))
            {
                return true;
            }
            else
                return false;
        }

        private bool CheckIfFoodEaten(Layers layer) 
        {
            for (int k = 0; k < layer.TileMap.Count; k++) 
            {
                for (int i = 0; i < layer.TileMap[k].Count; i++) 
                {
                    for (int j = 0; j < layer.TileMap[k][i].Count; j++) 
                    {
                        if (layer.TileMap[0][i][j].X == 1 && layer.TileMap[0][i][j].Y == 0) 
                        {
                            return false;
                        }
                    }   
                }
            }
            return true;
        }
    }
}
