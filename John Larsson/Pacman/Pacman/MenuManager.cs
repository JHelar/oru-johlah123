﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    public class MenuManager
    {
        #region Variabler
        List<string> menuItems, animationTypes, linkType,linkID;
        List<Texture2D> menuImages;
        List<List<ScreenAnimation>> screenAnimation;
        List<List<string>> attributes, contents;
        List<ScreenAnimation> tempAnimation;

        ContentManager content;

        FileManager fileManager;
        KeyboardState keyState,oldKeyState;

        Vector2 position;
        Rectangle source;
        SpriteFont font;

        int axis,itemNumber;
        string align;
        #endregion
        #region Privata metoder
        private void SetMenuItems() 
        {
            for (int i = 0; i < menuItems.Count; i++) 
            {
                if (menuImages.Count == i)
                    menuImages.Add(null);

            }
            for (int i = 0; i < menuImages.Count; i++) 
            {
                if (menuItems.Count == i)
                    menuItems.Add(null);
            }
        }

        private void SetAnimations() 
        {
            Vector2 pos = position;
            Vector2 dimensions = Vector2.Zero;

            for (int i = 0; i < menuImages.Count; i++)
            {
                for (int j = 0; j < animationTypes.Count; j++)
                {
                    switch (animationTypes[j]) 
                    {
                        case "Fade":
                            tempAnimation.Add(new FadeAnimation());
                            tempAnimation[tempAnimation.Count - 1].LoadContent(content, menuImages[i], menuItems[i], pos);
                            break;
                    }
                }
                if(tempAnimation.Count > 0)
                    screenAnimation.Add(tempAnimation);
                tempAnimation = new List<ScreenAnimation>();
                dimensions = new Vector2(font.MeasureString(menuItems[i]).X,font.MeasureString(menuItems[i]).Y);

                if(axis == 1)
                {
                    pos.X += dimensions.X;
                }
                else
                {
                    pos.Y += dimensions.Y;
                }
            }
        }

        #endregion
        #region Huvudmetoder
        public void LoadContent(ContentManager content,string id) 
        {
            this.content = new ContentManager(content.ServiceProvider, "Content");
            menuItems = new List<string>();
            menuImages = new List<Texture2D>();
            screenAnimation = new List<List<ScreenAnimation>>();
            tempAnimation = new List<ScreenAnimation>();
            animationTypes = new List<string>();
            attributes = new List<List<string>>();
            contents = new List<List<string>>();
            linkType = new List<string>();
            linkID = new List<string>();
            itemNumber = 0;
            position = Vector2.Zero;
            fileManager = new FileManager();

            fileManager.LoadContent("Load/PacMenu.cme", attributes, contents, id);

            for (int i = 0; i < attributes.Count; i++) 
            {
                for (int j = 0; j < attributes[i].Count; j++) 
                {
                    switch (attributes[i][j]) 
                    {
                        case "Font":
                            font = content.Load<SpriteFont>(contents[i][j]);
                            break;
                        case "Item":
                            menuItems.Add(contents[i][j]);
                            break;
                        case "Image":
                            menuImages.Add(content.Load<Texture2D>(contents[i][j]));
                            break;
                        case "Axis":
                            axis = int.Parse(contents[i][j]);
                            break;
                        case "Position":
                            string[] temp = contents[i][j].Split(' ');
                            position = new Vector2(float.Parse(temp[0]),float.Parse(temp[1]));
                            break;
                        case "Source":
                            temp= contents[i][j].Split(' ');
                            source = new Rectangle(int.Parse(temp[0]),int.Parse(temp[1]),int.Parse(temp[2]),int.Parse(temp[3]));
                            break;
                        case "Animation":
                            animationTypes.Add(contents[i][j]);
                            break;
                        case "Align":
                            align = contents[i][j];
                            break;
                        case "LinkType":
                            linkType.Add(contents[i][j]);
                            break;
                        case "LinkID":
                            linkID.Add(contents[i][j]);
                            break;
                    }
                }
            }

            SetMenuItems();
            SetAnimations();
        }

        public void UnloadContent()
        {
            fileManager = null;
            content.Unload();
            position = Vector2.Zero;
            animationTypes.Clear();
            screenAnimation.Clear();
            menuImages.Clear();
            menuItems.Clear();
        }

        public void Update(GameTime gameTime) 
        {
            keyState = Keyboard.GetState();
            if (axis == 1)
            {
                if (keyState.IsKeyDown(Keys.Right) && !oldKeyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D) && !oldKeyState.IsKeyDown(Keys .D))
                    itemNumber++;
                else if (keyState.IsKeyDown(Keys.Left) && !oldKeyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A) && !oldKeyState.IsKeyDown(Keys.A))
                    itemNumber--;
            }
            else 
            {
                if (keyState.IsKeyDown(Keys.Down) && !oldKeyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S) && !oldKeyState.IsKeyDown(Keys.S))
                    itemNumber++;
                else if (keyState.IsKeyDown(Keys.Up) && !oldKeyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W) && !oldKeyState.IsKeyDown(Keys.W))
                    itemNumber--;
            }
            if (keyState.IsKeyDown(Keys.Enter) || keyState.IsKeyDown(Keys.Z)) 
            {
                if (linkType[itemNumber] == "NewGame") 
                {
                    Type newClass = Type.GetType("Pacman."+linkID[itemNumber]);
                    ScreenManager.Instance.AddScreen((GameScreen)Activator.CreateInstance(newClass));
                }
            }
            if (itemNumber < 0)
                itemNumber = 0;
            else if (itemNumber > menuItems.Count - 1)
                itemNumber = menuItems.Count - 1;
            oldKeyState = keyState;
            for (int i = 0; i < screenAnimation.Count; i++) 
            {
                for (int j = 0; j < screenAnimation[i].Count; j++) 
                {
                    if (itemNumber == i)
                        screenAnimation[i][j].Active = true;
                    else
                        screenAnimation[i][j].Active = false;
                    screenAnimation[i][j].Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            for (int i = 0; i < screenAnimation.Count; i++)
            {
                for (int j = 0; j < screenAnimation[i].Count; j++)
                {
                    screenAnimation[i][j].Draw(spriteBatch);
                }
            }
        }
        #endregion
    }
}
