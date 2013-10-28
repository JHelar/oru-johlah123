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
    /// Colliation class for tile collision
    /// </summary>
    public class Collision
    {
        #region Variables
        FileManager fileManager;
        List<List<string>> attributes, contents;
        List<Vector2> row,foodRow;
        List<List<Vector2>> collisionMap,foodCollisionMap;
        #endregion
        #region Properties
        public List<List<string>> Contents
        {
            get { return contents; }
        }
        public List<List<Vector2>> CollisionMap 
        {
            get { return collisionMap; }
        }

        public List<List<Vector2>> FoodCollisionMap 
        {
            get { return foodCollisionMap; }
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Loads in the tile map from the collision text file. Sets the coordiantes for foodtiles and walls.
        /// Everything is loaded into their own two dimensional lists.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="mapID"></param>
        public void LoadContent(ContentManager content, string mapID) 
        {
            fileManager = new FileManager();
            attributes = new List<List<string>>();
            contents = new List<List<string>>();
            collisionMap = new List<List<Vector2>>();
            foodCollisionMap = new List<List<Vector2>>();
            row = new List<Vector2>();
            foodRow = new List<Vector2>();

            fileManager.LoadContent("Load/Map/" + mapID + ".cme", attributes, contents, "Collision");

            for (int i = 0; i < contents.Count; i++) 
            {
                for (int j = 0; j < contents[i].Count; j++) 
                {
                    if (contents[i][j] == "x")
                    {
                        row.Add(new Vector2(j * 20, i * 20));
                        foodRow.Add(new Vector2(999, 999));
                    }
                    else 
                    {
                        row.Add(new Vector2(999, 999));
                        foodRow.Add(new Vector2(j * 20, i * 20));
                    }
                }
                foodCollisionMap.Add(foodRow);
                collisionMap.Add(row);
                foodRow = new List<Vector2>();
                row = new List<Vector2>();
            }
        }
        /// <summary>
        /// Clears the lists, called when a new screen has been added
        /// </summary>
        public void UnloadContent() 
        {
            attributes.Clear();
            contents.Clear();
            row.Clear();
            foodRow.Clear();
            collisionMap.Clear();
            foodCollisionMap.Clear();
        }
        #endregion
    }
}
