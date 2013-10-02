using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FemtonPussel
{
    public class Form1 : Form
    {
        private List<Button> ButtonList=new List<Button>();
        private int randomMove = 0;
        private Random random = new Random();
        private int WIDTH = 265;
        private int HEIGHT = 310;
        private int count=0;
        private List<Point> OriginPos = new List<Point>();
        public Form1()
        {
            this.Text = "FemtonSpel";
            this.Size = new Size(WIDTH, HEIGHT);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            MenuStrip ms = new MenuStrip();
            ms.Parent = this;

            ToolStripMenuItem file=new ToolStripMenuItem("&File");
            ToolStripMenuItem exit = new ToolStripMenuItem("&Exit",null,new EventHandler(OnExit));
            ToolStripMenuItem newgame = new ToolStripMenuItem("&New Game",null,new EventHandler(OnNewGame));
            newgame.ShortcutKeys = Keys.F2;
            exit.ShortcutKeys = Keys.Control | Keys.X;
            file.DropDownItems.Add(newgame);
            file.DropDownItems.Add(exit);

            ms.Items.Add(file);
            MainMenuStrip = ms;
            Button button = new Button();
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    button = new Button();
                    if (count == 15)
                    {
                        button.Text = null;
                        button.BackColor = Color.HotPink;
                    }
                    else
                    {
                        button.Text = Convert.ToString(count + 1);
                    }
                    button.Font = new Font(button.Font.FontFamily, 15);
                    button.Parent = this;
                    button.Location = new Point(5 + i * 61, 27 + j * 61);
                    button.Size = new Size(55, 55);
                    button.Click += new EventHandler(ButtonClicked);

                    OriginPos.Add(button.Location);
                    ButtonList.Add(button);
                    count++;
                }

            }
            CenterToScreen();
        }
        void OnNewGame(object sender, EventArgs e) 
        { 
            for (int i = 0; i < 1000; i++)
            {
                randomMove = random.Next(1, 5);
                RandomGame(randomMove);
            }  
        }
        void OnExit(object sender, EventArgs e) 
        {
            Close();
        }
        private void RandomGame(int randomMove) 
        {
            if (randomMove==1)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.X == ButtonList[i].Location.X + 61) && (ButtonList[15].Location.Y == ButtonList[i].Location.Y))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
            }
            else if (randomMove == 2)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.X == ButtonList[i].Location.X - 61) && (ButtonList[15].Location.Y == ButtonList[i].Location.Y))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
            }
            else if (randomMove == 3)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.Y == ButtonList[i].Location.Y - 61) && (ButtonList[15].Location.X == ButtonList[i].Location.X))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
            }
            else if (randomMove == 4)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.Y == ButtonList[i].Location.Y + 61) && (ButtonList[15].Location.X == ButtonList[i].Location.X))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
            }
            
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.X == ButtonList[i].Location.X + 61) && (ButtonList[15].Location.Y == ButtonList[i].Location.Y))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
                GameOver();
                return true;
            }
            else if (keyData == Keys.Right)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.X == ButtonList[i].Location.X - 61) && (ButtonList[15].Location.Y == ButtonList[i].Location.Y))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
                GameOver();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.Y == ButtonList[i].Location.Y - 61) && (ButtonList[15].Location.X == ButtonList[i].Location.X))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
                GameOver();
                return true;
            }
            else if (keyData == Keys.Up)
            {
                Point tempPos = new Point();
                for (int i = 0; i < 15; i++)
                {
                    if ((ButtonList[15].Location.Y == ButtonList[i].Location.Y + 61) && (ButtonList[15].Location.X == ButtonList[i].Location.X))
                    {
                        tempPos = ButtonList[15].Location;
                        ButtonList[15].Location = ButtonList[i].Location;
                        ButtonList[i].Location = tempPos;
                        break;
                    }
                }
                GameOver();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void ButtonClicked(object sender, EventArgs e) 
        {
            Button btn = (Button)sender;
            Point tempPos = new Point();
            if ((ButtonList[15].Location.X == (btn.Location.X + 61) || ButtonList[15].Location.X == (btn.Location.X - 61))&&ButtonList[15].Location.Y==btn.Location.Y)  //Horizontal
            {
                tempPos = ButtonList[15].Location;
                ButtonList[15].Location = btn.Location;
                btn.Location = tempPos;
            }
            else if ((ButtonList[15].Location.Y == (btn.Location.Y + 61) || ButtonList[15].Location.Y == (btn.Location.Y - 61))&& ButtonList[15].Location.X == btn.Location.X) //Vertical
            {
                tempPos = ButtonList[15].Location;
                ButtonList[15].Location=btn.Location;
                btn.Location = tempPos;
            }
            GameOver();
        }
        private void GameOver() 
        {
            for (int i = 0; i < 15; i++)
            {
                if (ButtonList[i].Location != OriginPos[i]) 
                {
                    break;
                }
                else if ((ButtonList[i].Location == OriginPos[i]) && i == 14) 
                {
                    MessageBox.Show("YOU WON!");
                }
            }
        }
    }
}
