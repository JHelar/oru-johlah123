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
    public class MainGame : GameScreen
    {
        Player player;
        List<Enemy> enemy;
        Enemy tempEnemy;
        Layers layer;
        Collision collision;
        HighScore highScore;
        GameOver gameOver;

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
            for(int i = 0; i < 2; i++)
            {
                tempEnemy = new Enemy();
                tempEnemy.Init(collision,player,new Vector2(240 +20 *i,300));
                tempEnemy.LoadContent(Content);
                enemy.Add(tempEnemy);
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            if(!gameOver.CheckGameState(player,enemy[0],layer))
            {
                player.Update(gameTime,collision,layer,highScore);
                for (int i = 0; i < 2; i++ )
                    enemy[i].Update(player, collision, layer, gameTime);
            }
            else
            {
                highScore.addScore(highScore.CurrScore);
                ScreenManager.Instance.AddScreen(new GameOverScreen(highScore));
            }
        }

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

        public override void Draw(SpriteBatch spriteBatch)
        {
            layer.Draw(spriteBatch);
            highScore.DrawGameScore(spriteBatch);
            for (int i = 0; i < 2; i++ )
                enemy[i].Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
