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

        public void Init() 
        {
            score = new List<int>();
            playerName = new List<string>();
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
            PacFont = content.Load<SpriteFont>("PacFont");
            filemanager = new FileManager();
            //filemanager.LoadScore("Load/Score/" + mapID + ".cme", score, playerName);
        }

        public void DrawGameScore(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(PacFont, "HIGH-SCORE", new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(PacFont, Convert.ToString(currScore), new Vector2(0, 10), Color.White);
        }
    }
}
