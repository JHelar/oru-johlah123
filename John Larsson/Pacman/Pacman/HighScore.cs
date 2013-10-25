using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class HighScore
    {
        List<int> score;
        List<string> playerName;
        List<List<string>> attributes, contents;
        int currScore;

        FileManager filemanager;
        SpriteFont PacFont;

        public List<string> PlayerName 
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public List<int> Score 
        {
            get { return score; }
            set { score = value; }
        }

        public int CurrScore 
        {
            get { return currScore;}
            set { currScore = value; }
        }

        public void Init(ContentManager content) 
        {
            score = new List<int>();
            playerName = new List<string>();
            contents = new List<List<string>>();
            attributes = new List<List<string>>();
            filemanager = new FileManager();
            PacFont = content.Load<SpriteFont>("PacGameFont");
        }

        public void addScore(int score)
        {
            this.score.Add(score);
        }

        public void addPlayer(string name) 
        {
            this.playerName.Add(name);
        }

        public void LoadScore(string mapID, ContentManager content) 
        {
            filemanager.LoadContent("Load/" + mapID + ".cme",attributes,contents,"Score");
            for (int i = 0; i < attributes.Count; i++) 
            {
                for (int j = 0; j < attributes[i].Count; j++) 
                {
                    switch (attributes[i][j]) 
                    {
                        case "Name":
                            playerName.Add(contents[i][j]);
                            break;
                        case "Score":
                            score.Add(Convert.ToInt32(contents[i][j]));
                            break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for (int i = 0; i < playerName.Count; i++) 
            {
                spriteBatch.DrawString(PacFont,Convert.ToString(i+1)+"."+playerName[i]+":"+Convert.ToString(score[i]), new Vector2((float)40, (float)i * 12 + 40), Color.White);
            }
        }

        public void DrawGameScore(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(PacFont, "HIGH-SCORE", new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(PacFont, Convert.ToString(currScore), new Vector2(0, 10), Color.White);
        }
    }
}
