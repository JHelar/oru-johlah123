using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    /// <summary>
    /// The main game screen
    /// </summary>
    public class MainGame : GameScreen
    {
        #region Variables
        Player player;
        List<Enemy> enemy;
        Enemy tempEnemy;
        Layers layer;
        Collision collision;
        HighScore highScore;
        GameOver gameOver;
        #endregion
        #region Public methods
        /// <summary>
        /// Loads and initializes all the variables, adds three enemies with different "smart levels"
        /// </summary>
        /// <param name="Content"></param>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            player = new Player();
            enemy = new List<Enemy>();
            layer = new Layers();
            collision = new Collision();
            highScore = new HighScore();
            gameOver = new GameOver();
            highScore.Init(Content);
            player.Init();
            player.LoadContent(Content);
            layer.LoadContent(Content, "PacMap");
            collision.LoadContent(Content, "PacMap");
            for(int i = 0; i < 3; i++)
            {
                tempEnemy = new Enemy();
                tempEnemy.Init(collision,player,new Vector2(240 +20 *i,300),i*20 + 50);
                tempEnemy.LoadContent(Content);
                enemy.Add(tempEnemy);
            }
            
        }
        /// <summary>
        /// Updates the enemy and player, checks if the gameover criteria is met, if it is then add the score to the highscore and transition to the gameover screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (!gameOver.CheckGameState(player, enemy[0], layer) || gameOver.CheckGameState(player, enemy[1], layer) || gameOver.CheckGameState(player, enemy[2], layer))
            {
                player.Update(gameTime,collision,layer,highScore);
                for (int i = 0; i < 3; i++ )
                    enemy[i].Update(player, collision, layer, gameTime);
            }
            else
            {
                highScore.addScore(highScore.CurrScore);
                ScreenManager.Instance.AddScreen(new GameOverScreen(highScore));
            }
        }
        /// <summary>
        /// Unloads everything, called when a new screen is added
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            for (int i = 0; i < 2; i++) 
            {
                enemy[i].UnloadContent();
            }
            highScore.UnloadContent();
            layer.UnloadContent();
            collision.UnloadContent();
        }
        /// <summary>
        /// Calls the draw function of the map,in-game highscore,enemies and player
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            layer.Draw(spriteBatch);
            highScore.DrawGameScore(spriteBatch);
            for (int i = 0; i < 3; i++ )
                enemy[i].Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
        #endregion
    }
}
