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
    /// A* Pathfinding implemented and variable changes, taken from another source. 
    /// </summary>
    public class PathFinding
    {
        #region Variables
        List<Position> openList;
        List<Position> closedList;
        List<Position> gridPathList;
        Queue<Vector2> mapPathQueue;

        int rows;
        int collumns;

        public Node[,] map;
        public Position startPosition;
        public Position goalPosition;
        #endregion
        #region Properties and enumerators
        public Queue<Vector2> Path
        {
            get { return mapPathQueue; }
        }

        public enum NodeState
        {
            NotVisited = 0,
            Open = 1,
            Closed = 2,
            Start = 3,  //Not used yet
            Goal = 4,  //Not used yet
            Wall = 5,  //Not used yet
            PathToGoalNodeFound = 6
        }

        public enum Direction
        {
            None = 0,
            South = 1,
            North = 4,
            West = 7,
            East = 8
        }
        #endregion
        #region Structs
        public struct Node
        {
            public NodeState State;

            public bool wall;

            public Position Parent;

            public int fValue { get { return gValue + hValue; } private set { ; } }

            public int gValue;

            public int hValue;

            public void Init()
            {
                wall = false;
                Parent.x = -1;
                Parent.y = -1;
                gValue = 0;
                hValue = 0;
            }
        }

        public struct Position
        {
            public int x;
            public int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        #endregion
        #region Public methods
        /// <summary>
        /// Sets the maps rows and collumns, sets the goal and startposition and which nodes have a wall
        /// </summary>
        /// <param name="col"></param>
        /// <param name="goalPosition"></param>
        /// <param name="startPosition"></param>
        public void Init(Collision col, Vector2 goalPosition, Vector2 startPosition)
        {
            rows = col.FoodCollisionMap.Count;
            collumns = col.FoodCollisionMap[0].Count;
            openList = new List<Position>();
            closedList = new List<Position>();
            gridPathList = new List<Position>();
            mapPathQueue = new Queue<Vector2>();
            map = new Node[rows, collumns];
            resetMap();
            this.startPosition = new Position((int)startPosition.Y / 20, ((int)startPosition.X / 20));
            this.goalPosition = new Position((int)goalPosition.Y / 20, ((int)goalPosition.X / 20));
            for (int i = 2; i < col.FoodCollisionMap.Count; i++)
            {
                for (int j = 0; j < col.FoodCollisionMap[i].Count; j++)
                {
                    if (col.FoodCollisionMap[i][j].X == 999)
                    {
                        map[i, j].wall = true;
                    }
                }
            }
        }
        /// <summary>
        /// Clears the path
        /// </summary>
        /// <param name="col"></param>
        /// <param name="goalPosition"></param>
        /// <param name="startPosition"></param>
        public void ClearPath(Collision col, Vector2 goalPosition, Vector2 startPosition) 
        {
            openList = new List<Position>();
            closedList = new List<Position>();
            mapPathQueue = new Queue<Vector2>();
            map = new Node[rows, collumns];
            resetMap();
            this.startPosition = new Position((int)startPosition.Y / 20, ((int)startPosition.X / 20));
            this.goalPosition = new Position((int)goalPosition.Y / 20, ((int)goalPosition.X / 20));
            for (int i = 2; i < col.FoodCollisionMap.Count; i++)
            {
                for (int j = 0; j < col.FoodCollisionMap[i].Count; j++)
                {
                    if (col.FoodCollisionMap[i][j].X == 999)
                    {
                        map[i, j].wall = true;
                    }
                }
            }
        }
        public void PathFinder()
        {
            startPathFinding();
            while (PathFindStep())
            {
            }

            if (map[goalPosition.x, goalPosition.y].State == NodeState.PathToGoalNodeFound && goalPosition.x >=0 && goalPosition.x <= 560)
            {
                if (calculatePath())
                {

                }
            }
        }
        #endregion
        #region Private methods
        /// <summary>
        /// resets the nodes in the map
        /// </summary>
        private void resetMap()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < collumns; j++)
                {
                    map[i, j].State = NodeState.NotVisited;
                    map[i, j].wall = false;
                    map[i, j].Parent = new Position(-1, -1); ;
                    map[i, j].gValue = 0;
                    map[i, j].hValue = 0;
                }
            }
        }
        /// <summary>
        /// Sets the H value of a node position
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int setHvalue(Position n)
        {
            int manhattan = Math.Abs(n.x - goalPosition.x) + Math.Abs(n.y - goalPosition.y);
            return 10 * manhattan;
        }
        /// <summary>
        /// Finds the lowest F value in the openList and sets it as the current search node
        /// </summary>
        /// <returns></returns>
        private Position findLowestF()
        {
            int min = int.MaxValue;
            Position minPos = new Position(-1, -1);

            foreach (var p in openList)
            {
                if (min > map[p.x, p.y].fValue)
                {
                    min = map[p.x, p.y].fValue;
                    minPos = p;
                }
            }
            return minPos;
        }
        /// <summary>
        /// Starts the pathfinding by seting the startposition as the start node 
        /// </summary>
        private void startPathFinding()
        {
            openList.Clear();
            closedList.Clear();
            openList.Add(startPosition);
            map[startPosition.x, startPosition.y].State = NodeState.Open;
        }
        /// <summary>
        /// Searches the horizontal and vertical directions and see if they are not walls, and checks if the current search node is the goal node
        /// </summary>
        /// <returns></returns>
        public bool PathFindStep()
        {
            if (openList.Count == 0) return false;

            Position tempPos = findLowestF();

            if (tempPos.x == goalPosition.x && tempPos.y == goalPosition.y)
            {
                map[tempPos.x, tempPos.y].State = NodeState.PathToGoalNodeFound;
                return false;
            }

            openList.Remove(tempPos);
            closedList.Add(tempPos);
            map[tempPos.x, tempPos.y].State = NodeState.Closed;

            visitNode(tempPos, Direction.East);
            visitNode(tempPos, Direction.North);
            visitNode(tempPos, Direction.South);
            visitNode(tempPos, Direction.West);

            return true;
        }
        /// <summary>
        /// Checks the horizontal and vertical nodes around the current search node to see if they are walls and or allready on the openlist, or if they are on the closed list.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="d"></param>
        private void visitNode(Position p, Direction d)
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
                case Direction.South: dr = +1; dc = 0; break;
            }
            r = p.x + dr;
            c = p.y + dc;
            g = PathFindCostG(dr, dc);

            if (r >= 0 && c >= 0 && r < rows && c < collumns)
            {
                if (map[r, c].wall) return;

                h = PathFindCostH(new Position(r, c));

                switch (map[r, c].State)
                {
                    case NodeState.NotVisited:

                        bool ok = true;
                        if (dr == -1 && dc == +1 && (map[r + 1, c].wall || map[r, c - 1].wall)) ok = false;
                        else if (dr == +1 && dc == +1 && (map[r, c - 1].wall || map[r - 1, c].wall)) ok = false;
                        else if (dr == -1 && dc == -1 && (map[r, c + 1].wall || map[r + 1, c].wall)) ok = false;
                        else if (dr == +1 && dc == -1 && (map[r, c + 1].wall || map[r - 1, c].wall)) ok = false;

                        if (ok)
                        {
                            map[r, c].State = NodeState.Open;
                            openList.Add(new Position(r, c));
                            map[r, c].gValue = g;
                            map[r, c].hValue = h;
                            map[r, c].Parent.x = p.x;
                            map[r, c].Parent.y = p.y;
                        }
                        break;
                    case NodeState.Open:
                        Position parentP, parentRC, grandParentRC;
                        parentP = map[p.x, p.y].Parent;
                        parentRC = map[r, c].Parent;
                        grandParentRC = map[parentRC.x, parentRC.y].Parent;
                        if ((grandParentRC.x != -1) && (grandParentRC.y != -1))
                        {
                            if (map[r, c].gValue > g)
                            {
                                map[r, c].gValue = g;
                                map[r, c].Parent = p;
                            }
                        }

                        break;
                    case NodeState.Closed:
                        break;

                }
            }
        }
        /// <summary>
        /// The parent direction
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public Direction ParentDirection(int r, int c)
        {
            Direction d = Direction.None;
            int dr = r - map[r, c].Parent.x;
            int dc = c - map[r, c].Parent.y;

            if (dc == 1) //West
            {
                if (dr == 0) d = Direction.West;
            }
            else if (dc == -1) //East
            {
                if (dr == 0) d = Direction.East;
            }
            else
            {
                if (dr == 1) d = Direction.North;
                else if (dr == -1) d = Direction.South;
            }

            return d;
        }
        /// <summary>
        /// Returns the G value of the movement cost horizontaly and vertically
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        private int PathFindCostG(int dr, int dc)
        {
            return 10;
        }
        /// <summary>
        /// If we found our goal node set the path to it
        /// </summary>
        /// <returns></returns>
        public bool calculatePath()
        {
            Boolean pathExist = true;

            gridPathList.Clear();

            int r = goalPosition.x;
            int c = goalPosition.y;
            Position p;
            if (r <= rows || c <= collumns || r > 0 || c > 0)
            {
                if (map[r, c].State == NodeState.PathToGoalNodeFound)
                {
                    gridPathList.Insert(0, new Position(r, c));

                    do
                    {
                        map[r, c].State = NodeState.PathToGoalNodeFound;
                        p = map[r, c].Parent;
                        gridPathList.Insert(0, p);
                        r = p.x; c = p.y;
                    }
                    while (!(r == startPosition.x && c == startPosition.y));
                }
            }
            createMapPath();
            return pathExist;
        }
        /// <summary>
        /// Sets the H cost of the node
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int PathFindCostH(Position n)
        {
            int manhattan = Math.Abs(n.x - goalPosition.x) + Math.Abs(n.y - goalPosition.y);
            return 10 * manhattan;
        }
        /// <summary>
        /// creates a queue of real map waypoint coordinates for the enemy to walk to
        /// </summary>
        private void createMapPath()
        {
            mapPathQueue = new Queue<Vector2>();
            for (int i = 0; i < gridPathList.Count; i++)
            {
                mapPathQueue.Enqueue(new Vector2(gridPathList[i].y * 20, gridPathList[i].x * 20));
            }
        }
        #endregion
    }
}
