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
    /// A highscore class that loads and saves the highscore
    /// </summary>
    public class HighScore
    {
        #region Variables
        List<int> score;
        List<string> playerName;
        int currScore;
        string currName;

        FileManager filemanager;
        SpriteFont PacFont;
        #endregion
        #region Properties
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

        public string CurrName
        {
            get { return currName; }
            set { currName = value; }
        }

        public int CurrScore 
        {
            get { return currScore;}
            set { currScore = value; }
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Loads the font and initializes the lists.
        /// </summary>
        /// <param name="content"></param>
        public void Init(ContentManager content) 
        {
            score = new List<int>();
            playerName = new List<string>();
            filemanager = new FileManager();
            PacFont = content.Load<SpriteFont>("PacGameFont");
        }
        /// <summary>
        /// Clears the lists, called when a new screen has been added
        /// </summary>
        public void UnloadContent() 
        {
            score.Clear();
            playerName.Clear();
        }
        /// <summary>
        /// adds a score to the score list
        /// </summary>
        /// <param name="score"></param>
        public void addScore(int score)
        {
            this.score.Add(score);
        }
        /// <summary>
        /// adds a playername to the playername list
        /// </summary>
        /// <param name="name"></param>
        public void addPlayer(string name) 
        {
            this.playerName.Add(name);
        }
        /// <summary>
        /// Loads in the highscore list from a XML file, adds the scores and player names to the two lists.
        /// </summary>
        /// <param name="mapID"></param>
        /// <param name="content"></param>
        public void LoadScore(string mapID, ContentManager content) 
        {
            filemanager.ReadScore("Load/PacScore.xml", score, playerName);
        }
        /// <summary>
        /// Saves and adds a score and playername to the highscore XML file
        /// </summary>
        public void saveScore() 
        {
            score.Add(currScore);
            filemanager.WriteScore("Load/PacScore.xml", currScore, currName);
        }
        /// <summary>
        /// Draws the highscore list on the screen.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) 
        {
            for (int i = 0; i < playerName.Count; i++) 
            {
                if (playerName[i] != "Dummy")
                    spriteBatch.DrawString(PacFont, Convert.ToString(i) + ". " + playerName[i] + ":" + Convert.ToString(score[i]), new Vector2((float)40, (float)i * 12 + 40), Color.White);        
            }
            if(playerName.Count == 1 && playerName[0] == "Dummy")
                spriteBatch.DrawString(PacFont, "No score found", new Vector2((float)40, (float)40), Color.White);
        }
        /// <summary>
        /// Draws the current sessions score to the game screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawGameScore(SpriteBatch spriteBatch) 
        {
            spriteBatch.DrawString(PacFont, "HIGH-SCORE", new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(PacFont, Convert.ToString(currScore), new Vector2(0, 10), Color.White);
        }
        #endregion
    }
}
