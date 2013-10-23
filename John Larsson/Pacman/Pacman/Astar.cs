using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Astar
    {
        public class Astar
        {
            public enum Direction
            {
                None = 0,
                South = 1,
                SouthWest = 2,
                SouthEast = 3,
                North = 4,
                NorthWest = 5,
                NorthEast = 6,
                West = 7,
                East = 8
            }

            // Map, start position and goal position
            public int Rows;
            public int Columns;
            public Square[,] Map;
            public Position Start;
            public Position Goal;

            //Search objects
            private List<Position> OpenList = new List<Position>();
            private List<Position> ClosedList = new List<Position>();
            private List<Position> PathList = new List<Position>();

            /// <summary>
            /// Default constructor
            /// </summary>
            public Astar()
            {
                Init();
            }

            /// <summary>
            /// Init of the map for test purposes
            /// </summary>
            public void Init()
            {
                TestMap01();
            }

            public void TestMap01()
            {
                Rows = 20;
                Columns = 20;
                Map = new Square[Rows, Columns];

                ResetMap();

                Start = new Position(3, 2);
                Goal = new Position(3, 8);

                Map[2, 4].Fence = true;
                Map[3, 4].Fence = true;
                Map[4, 4].Fence = true;
                Map[5, 4].Fence = true;
            }


            /// <summary>
            /// Look for minimal cost F
            /// </summary>
            /// <returns></returns>
            private Position OpenListGetLowestCostF()
            {
                int min = int.MaxValue;
                Position minPos = new Position(-1, -1);

                foreach (var p in OpenList)
                {
                    if (min > Map[p.R, p.C].F)
                    {
                        min = Map[p.R, p.C].F;
                        minPos = p;
                    }
                }
                return minPos;
            }

            /// <summary>
            /// Reset of the map.
            /// </summary>
            public void ResetMap()
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        Map[i, j].State = StateSquare.NotVisited;
                        Map[i, j].Fence = false;
                        Map[i, j].Parent = new Position(-1, -1); ;
                        Map[i, j].G = 0;
                        Map[i, j].H = 0;
                    }
                }
            }

            /// <summary>
            /// Main method to find a path. 
            /// </summary>
            public void PathFinder()
            {
                PathFindInit();
                while (PathFindStep())
                {
                }

                if (Map[Goal.R, Goal.C].State == StateSquare.PathToGoalNodeFound)
                {
                    if (CalculatePath())
                    {

                    }
                }
            }

            /// <summary>
            /// Init of the search for a path
            /// </summary>
            public void PathFindInit()
            {
                OpenList.Clear();
                ClosedList.Clear();
                OpenList.Add(Start);
                Map[Start.R, Start.C].State = StateSquare.Open;
            }

            /// <summary>
            /// Remove of one node from the open list
            /// </summary>
            /// <returns></returns>
            public bool PathFindStep()
            {
                if (OpenList.Count == 0) return false;

                Position p = OpenListGetLowestCostF();

                if (p.R == Goal.R && p.C == Goal.C)
                {
                    Map[p.R, p.C].State = StateSquare.PathToGoalNodeFound;
                    return false;
                }

                OpenList.Remove(p);
                //Position p = OpenList[0];
                //OpenList.RemoveAt(0);
                ClosedList.Add(p);
                Map[p.R, p.C].State = StateSquare.Closed;

                PathFindVisitNode(p, Direction.East);
                PathFindVisitNode(p, Direction.North);
                PathFindVisitNode(p, Direction.NorthEast);
                PathFindVisitNode(p, Direction.NorthWest);
                PathFindVisitNode(p, Direction.South);
                PathFindVisitNode(p, Direction.SouthEast);
                PathFindVisitNode(p, Direction.SouthWest);
                PathFindVisitNode(p, Direction.West);

                return true;
            }

            /// <summary>
            /// Check of a node
            /// </summary>
            /// <param name="p"></param>
            /// <param name="d"></param>
            private void PathFindVisitNode(Position p, Direction d)
            {
                int dr = 0;
                int dc = 0;
                int r = -1, c = -1;
                int g = 0;
                int h = 0;

                switch (d)
                {
                    case Direction.West: dr = 0; dc = -1; break;
                    case Direction.East: dr = 0; dc = +1; break;
                    case Direction.North: dr = -1; dc = 0; break;
                    case Direction.NorthWest: dr = -1; dc = -1; break;
                    case Direction.NorthEast: dr = -1; dc = +1; break;
                    case Direction.South: dr = +1; dc = 0; break;
                    case Direction.SouthWest: dr = +1; dc = -1; break;
                    case Direction.SouthEast: dr = +1; dc = +1; break;
                }
                r = p.R + dr;
                c = p.C + dc;
                g = PathFindCostG(dr, dc);

                if (r >= 0 && c >= 0 && r < Rows && c < Columns)
                {
                    if (Map[r, c].Fence) return;

                    h = PathFindCostH(new Position(r, c));

                    switch (Map[r, c].State)
                    {
                        case StateSquare.NotVisited:

                            bool ok = true;
                            if (dr == -1 && dc == +1 && (Map[r + 1, c].Fence || Map[r, c - 1].Fence)) ok = false;
                            else if (dr == +1 && dc == +1 && (Map[r, c - 1].Fence || Map[r - 1, c].Fence)) ok = false;
                            else if (dr == -1 && dc == -1 && (Map[r, c + 1].Fence || Map[r + 1, c].Fence)) ok = false;
                            else if (dr == +1 && dc == -1 && (Map[r, c + 1].Fence || Map[r - 1, c].Fence)) ok = false;

                            if (ok)
                            {
                                Map[r, c].State = StateSquare.Open;
                                OpenList.Add(new Position(r, c));
                                Map[r, c].G = g;
                                Map[r, c].H = h;
                                Map[r, c].Parent.R = p.R; Map[r, c].Parent.C = p.C;
                            }
                            break;
                        case StateSquare.Open:
                            Position parentP, parentRC, grandParentRC;
                            parentP = Map[p.R, p.C].Parent;
                            parentRC = Map[r, c].Parent;
                            grandParentRC = Map[parentRC.R, parentRC.C].Parent;
                            if ((grandParentRC.R != -1) && (grandParentRC.C != -1))
                            {
                                if (Map[r, c].G > g)
                                {
                                    Map[r, c].G = g;
                                    Map[r, c].Parent = p;
                                }
                            }

                            break;
                        case StateSquare.Closed:
                            break;

                    }
                }
            }

            /// <summary>
            /// Direction to the parent node from the node with coordinates (r,c).
            /// </summary>
            /// <param name="r"></param>
            /// <param name="c"></param>
            /// <returns></returns>
            public Direction ParentDirection(int r, int c)
            {
                Direction d = Direction.None;
                int dr = r - Map[r, c].Parent.R;
                int dc = c - Map[r, c].Parent.C;

                if (dc == 1) //West
                {
                    if (dr == 0) d = Direction.West;
                    else if (dr == 1) d = Direction.NorthWest;
                    else if (dr == -1) d = Direction.SouthWest;
                }
                else if (dc == -1) //East
                {
                    if (dr == 0) d = Direction.East;
                    else if (dr == 1) d = Direction.NorthEast;
                    else if (dr == -1) d = Direction.SouthEast;
                }
                else
                {
                    if (dr == 1) d = Direction.North;
                    else if (dr == -1) d = Direction.South;
                }

                return d;
            }

            /// <summary>
            /// Calculate cost G
            /// </summary>
            /// <param name="dr"></param>
            /// <param name="dc"></param>
            /// <returns></returns>
            private int PathFindCostG(int dr, int dc)
            {
                if (Math.Abs(dr) == Math.Abs(dc))
                    return 14;
                else
                    return 10;
            }

            /// <summary>
            /// Calculate path.
            /// </summary>
            /// <returns></returns>
            public bool CalculatePath()
            {
                Boolean pathExist = true;

                PathList.Clear();

                int r = Goal.R;
                int c = Goal.C;
                Position p;

                if (Map[r, c].State == StateSquare.PathToGoalNodeFound)
                {
                    PathList.Insert(0, new Position(r, c));

                    do
                    {
                        Map[r, c].State = StateSquare.PathToGoalNodeFound;
                        p = Map[r, c].Parent;
                        PathList.Insert(0, p);
                        r = p.R; c = p.C;
                    }
                    while (!(r == Start.R && c == Start.C));
                }

                return pathExist;
            }

            /// <summary>
            /// Calculate heuristic cost H with the Manhattan algorithm.
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            private int PathFindCostH(Position n)
            {
                int manhattan = Math.Abs(n.R - Goal.R) + Math.Abs(n.C - Goal.C);
                return 10 * manhattan;
            }

            /// <summary>
            /// State of this square
            /// </summary>
            public enum StateSquare
            {
                NotVisited = 0,
                Open = 1,
                Closed = 2,
                Start = 3,  //Not used yet
                Goal = 4,  //Not used yet
                Wall = 5,  //Not used yet
                PathToGoalNodeFound = 6
            }

            /// <summary>
            /// A position in the map.
            /// </summary>
            public struct Position
            {
                public int R;
                public int C;

                /// <summary>
                /// Constructor with paramneters
                /// </summary>
                /// <param name="x"></param>
                /// <param name="y"></param>
                public Position(int r, int c)
                {
                    R = r;
                    C = c;
                }
            }

            /// <summary>
            /// Contains all info neede in a square to be used by the Astar algorithm.
            /// </summary>
            public struct Square
            {
                public StateSquare State;

                public bool Fence;  //This square is it not possible to walk 

                public Position Parent; //Unused X=-1 and Y=-1

                public int F { get { return G + H; } private set { ; } }

                public int G;

                public int H;

                /// <summary>
                /// Init
                /// </summary>
                public void Init()
                {
                    Fence = false;
                    Parent.R = -1;
                    Parent.C = -1;
                    G = 0;
                    H = 0;
                }
            }

            /// <summary>
            /// Class used to save a map with xml-serialization.
            /// </summary>
                public void Convert(Astar astar)
                {
                    List.Clear();
                    Rows = astar.Rows;
                    Columns = astar.Columns;
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            List.Add(astar.Map[i, j]);
                        }
                    }
                }
            }
        }
    }
}
