using System;
using System.Collections.Generic;
using System.Linq;
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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player();
        Enemy enemy = new Enemy();
        Layers layer;
        Collision collision;
        HighScore highScore;
        GameOver gameOver;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 655;
            graphics.PreferredBackBufferWidth = 560;
        }

        protected override void Initialize()
        {
            gameOver = new GameOver();
            layer = new Layers();
            player = new Player();
            collision = new Collision();
            enemy = new Enemy();
            highScore = new HighScore();
            highScore.Init();
            enemy.Init();
            player.Init();
            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            enemy.LoadContent(Content);
            layer.LoadContent(Content, "PacMap");
            collision.LoadContent(Content, "PacMap");
            highScore.LoadScore("PacScore",Content);

        }

        protected override void UnloadContent()
        {
  
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
           player.Update(gameTime,collision,layer,highScore);
           enemy.Update(player,collision,layer,gameTime);

           if (gameOver.CheckIfFoodEaten(layer))
               highScore.CurrScore = 99999;
           else if (gameOver.CheckEnemyPlayerCollision(player, enemy, layer))
               highScore.CurrScore = 99999;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            layer.Draw(spriteBatch);
            highScore.DrawGameScore(spriteBatch);
            enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
