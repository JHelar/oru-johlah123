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
        Enemy enemy;
        Layers layer;
        Collision collision;
        HighScore highScore;
        GameOver gameOver;

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            player = new Player();
            enemy = new Enemy();
            layer = new Layers();
            collision = new Collision();
            highScore = new HighScore();
            gameOver = new GameOver();
            highScore.Init();
            enemy.Init();
            player.Init();
            player.LoadContent(Content);
            enemy.LoadContent(Content);
            layer.LoadContent(Content, "PacMap");
            collision.LoadContent(Content, "PacMap");
            highScore.LoadScore("PacScore",Content);
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime,collision,layer,highScore);
            enemy.Update(player,collision,layer,gameTime);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            layer.Draw(spriteBatch);
            highScore.DrawGameScore(spriteBatch);
            enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
