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
    public class Collision
    {
        FileManager fileManager;
        List<List<string>> attributes, contents;
        List<Vector2> row;
        List<List<Vector2>> collisionMap;

        public List<List<Vector2>> CollisionMap 
        {
            get { return collisionMap; }
        }

        public void LoadContent(ContentManager content, string mapID) 
        {
            fileManager = new FileManager();
            attributes = new List<List<string>>();
            contents = new List<List<string>>();
            collisionMap = new List<List<Vector2>>();
            row = new List<Vector2>();

            fileManager.LoadContent("Load/Map/" + mapID + ".cme", attributes, contents, "Collision");

            for (int i = 0; i < contents.Count; i++) 
            {
                for (int j = 0; j < contents[i].Count; j++) 
                {
                    if (contents[i][j] == "x")
                    {
                        row.Add(new Vector2(j * 20, i * 20));
                    }
                    else 
                    {
                        row.Add(new Vector2(999, 999));
                    }
                }
                collisionMap.Add(row);
                row = new List<Vector2>();
            }
        }
    }
}
