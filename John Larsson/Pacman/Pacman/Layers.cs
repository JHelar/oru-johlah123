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
    /// A dynamic tilemap reader
    /// </summary>
    public class Layers
    {
        #region Variables
        List<List<List<Vector2>>> tileMap;
        List<List<Vector2>> layer;
        List<Vector2> tile;

        FileManager fileManager;

        Texture2D tileSet;
        Vector2 tileDimensions;

        int layerNumber;

        List<List<string>> attributes, contents;
        #endregion
        #region Properties
        public int LayerNumber
        {
            set{ layerNumber = value; }
        }

        public Vector2 TileDimensions
        {
            get { return tileDimensions; }
        }

        public List<List<List<Vector2>>> TileMap 
        {
            get { return tileMap; }
            set { tileMap = value; }
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Loads the tile map from the tilemap text file, adds the single tiles to a layer in which then is added to the tile map. 
        /// This adds the abillity to read in multiple maps into a single variable. 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="mapID"></param>
        public void LoadContent(ContentManager content, string mapID)
        {
            fileManager = new FileManager();

            tile = new List<Vector2>();
            layer = new List<List<Vector2>>();
            tileMap = new List<List<List<Vector2>>>();
            attributes = new List<List<string>>(); 
            contents = new List<List<string>>();
            layerNumber = 0;

            fileManager.LoadContent("Load/Map/" + mapID + ".cme", attributes, contents, "Map");

            for (int i = 0; i < attributes.Count; i++)
            {
                for (int j = 0; j < attributes[i].Count; j++)
                {
                    switch (attributes[i][j])
                    {
                        case "TileSet":
                            tileSet = content.Load<Texture2D>("PacTiles");
                            break;
                        case "TileDimensions":
                            string[] split = contents[i][j].Split(',');
                            tileDimensions = new Vector2(int.Parse(split[0]), int.Parse(split[1]));
                            break;
                        case "StartLayer":
                            for (int k = 0; k < contents[i].Count; k++)
                            {
                                split = contents[i][k].Split(',');
                                tile.Add(new Vector2(int.Parse(split[0]), int.Parse(split[1])));
                            }

                            if (tile.Count > 0)
                                layer.Add(tile);
                            tile = new List<Vector2>();
                            break;
                        case "EndLayer":
                            if (layer.Count > 0)
                                tileMap.Add(layer);
                            layer = new List<List<Vector2>>();
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Clears the lists, called when a new screen has been added
        /// </summary>
        public void UnloadContent()
        {
            tileMap.Clear();
            layer.Clear();
            tile.Clear();
            attributes.Clear();
            contents.Clear();
            fileManager = null;
        }
        /// <summary>
        /// Draws out the map tiles to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int k = 0; k < tileMap.Count; k++)
            {
                for (int i = 0; i < tileMap[k].Count; i++)
                {
                    for (int j = 0; j < tileMap[k][i].Count; j++)
                    {
                        spriteBatch.Draw(tileSet, new Vector2(j * tileDimensions.X, i * tileDimensions.Y),
                            new Rectangle((int)tileMap[k][i][j].X * (int)tileDimensions.X,
                                (int)tileMap[k][i][j].Y * (int)tileDimensions.Y,
                                (int)tileDimensions.X, (int)tileDimensions.Y), Color.White);
                    }
                }
            }
        }
        #endregion
    }
}
