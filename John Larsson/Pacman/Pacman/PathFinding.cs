using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class PathFinding
    {
        #region Variabler
        List<Node> closedList, openList;
        List<Node> nodeRow;
        Node tempNode,currentSearchNode,goalNode;
        List<List<Node>> nodes;
        Vector2 tempDistance, PositionInGrid;
        Queue<Vector2> path;
        int gValue;
        int goalFound;
        #endregion

        public Queue<Vector2> Path 
        {
            get { return path; }
        }
        #region Huvud-metod
        public void FindPath(Vector2 goalPosition, Vector2 currentPosition, Collision col)
        {
            nodes = new List<List<Node>>();
            nodeRow = new List<Node>();
            closedList = new List<Node>();
            openList = new List<Node>();
            path = new Queue<Vector2>();
            currentSearchNode = new Node();
            goalNode = new Node();
            gValue = 10;
            for (int i = 0; i < col.FoodCollisionMap.Count; i++)
            {
                for (int j = 0; j < col.FoodCollisionMap[i].Count; j++)
                {
                    if (col.FoodCollisionMap[i][j].X != 999)
                    {
                        tempNode = new Node();
                        tempDistance = new Vector2((goalPosition.X - col.FoodCollisionMap[i][j].X) / 20, (goalPosition.Y - col.FoodCollisionMap[i][j].Y) / 20);
                        if (tempDistance.X < 0)
                            tempDistance.X = tempDistance.X * -1;
                        if (tempDistance.Y < 0)
                            tempDistance.Y = tempDistance.Y * -1;
                        tempNode.MapPosition = col.FoodCollisionMap[i][j];
                        tempNode.NodeValue = ((int)tempDistance.X + (int)tempDistance.Y) * 10;
                        tempNode.NodePosition = new Vector2((float)i, (float)j);
                    }
                    else
                    {
                        tempNode.MapPosition = col.FoodCollisionMap[i][j];
                        tempNode.NodePosition = new Vector2((float)i, (float)j);
                        tempNode.NodeValue = 999;
                    }
                    nodeRow.Add(tempNode);
                }
                nodes.Add(nodeRow);
                nodeRow = new List<Node>();
            }
            findStartingNode(currentPosition, col);
            findGoalNode(goalPosition, col);
            startPathing();
            createPath();
        }
        #endregion
        #region Privata metoder
        /// <summary>
        /// Letar och hittar noden som enemy är på
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="col"></param>
        private void findStartingNode(Vector2 currentPosition, Collision col)
        {
            bool loopBreak = false;
            Rectangle tempRect = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 20, 20);
            for (int i = 0; i < col.FoodCollisionMap.Count; i++)
            {
                for (int j = 0; j < col.FoodCollisionMap[i].Count; j++)
                {
                    if (tempRect.Intersects(new Rectangle((int)col.FoodCollisionMap[i][j].X, (int)col.FoodCollisionMap[i][j].Y, 20, 20)))
                    {
                        PositionInGrid = new Vector2((float)i, (float)j);
                        loopBreak = true;
                        break;
                    }
                }
                if (loopBreak)
                    break;
            }
            loopBreak = false;
            for (int i = 0; i < nodes.Count; i++) 
            {
                for (int j = 0; j < nodes[i].Count; j++) 
                {
                    if (nodes[i][j].NodePosition == PositionInGrid)
                    {
                        currentSearchNode = nodes[i][j];
                        loopBreak = true;
                        break;
                    }
                }
                if (loopBreak)
                    break;
            }
        }
        /// <summary>
        /// Letar och hittar noden som spelaren är på
        /// </summary>
        /// <param name="goalPosition"></param>
        /// <param name="col"></param>
        private void findGoalNode(Vector2 goalPosition, Collision col) 
        {
            bool loopBreak = false;
            Rectangle tempRect = new Rectangle((int)goalPosition.X, (int)goalPosition.Y, 20, 20);
            for (int i = 0; i < col.FoodCollisionMap.Count; i++)
            {
                for (int j = 0; j < col.FoodCollisionMap[i].Count; j++)
                {
                    if (tempRect.Intersects(new Rectangle((int)col.FoodCollisionMap[i][j].X, (int)col.FoodCollisionMap[i][j].Y, 20, 20)))
                    {
                        PositionInGrid = new Vector2((float)i, (float)j);
                        loopBreak = true;
                        break;
                    }
                }
                if (loopBreak)
                    break;
            }
            loopBreak = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[i].Count; j++)
                {
                    if (nodes[i][j].NodePosition == PositionInGrid)
                    {
                        goalNode = nodes[i][j];
                        loopBreak = true;
                        break;
                    }
                }
                if (loopBreak)
                    break;
            }
        }
        /// <summary>
        /// Startar pathfinding
        /// </summary>
        private void startPathing()
        {
            goalFound = 0;
            openList.Add(currentSearchNode);
            while (goalFound != 200)
            {
                findLowest();
                openList.Remove(currentSearchNode);
                closedList.Add(currentSearchNode);
                checkAdjacent();
                goalFound++;
            }
        }
        /// <summary>
        /// Tittar på närliggande noder
        /// </summary>
        private void checkAdjacent() 
        {
            //Noden Över
            if (nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y].NodeValue != 999 && !closedList.Contains(nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y])) 
            {
                if (!openList.Contains(nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y]))
                {
                    openList.Add(nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y]);
                    nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y].Parent = currentSearchNode.NodePosition;
                    nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y].ParentGValue = currentSearchNode.GValue;
                    nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y].GValue = nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y].ParentGValue + gValue;
                    setFValue(nodes[(int)currentSearchNode.NodePosition.X - 1][(int)currentSearchNode.NodePosition.Y]);
                }
            }

            //Noden under
            if (nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y].NodeValue != 999 && !closedList.Contains(nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y]))
            {
                if (!openList.Contains(nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y]))
                {
                    openList.Add(nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y]);
                    nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y].Parent = currentSearchNode.NodePosition;
                    nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y].ParentGValue = currentSearchNode.GValue;
                    nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y].GValue = nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y].ParentGValue + gValue;
                    setFValue(nodes[(int)currentSearchNode.NodePosition.X + 1][(int)currentSearchNode.NodePosition.Y]);
                }
            }

            //Noden till Höger
            if (nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1].NodeValue != 999 && !closedList.Contains(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1]))
            {
                if (!openList.Contains(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1]))
                {
                    openList.Add(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1]);
                    nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1].Parent = currentSearchNode.NodePosition;
                    nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1].ParentGValue = currentSearchNode.GValue;
                    nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1].GValue = nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1].ParentGValue + gValue;
                    setFValue(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y + 1]);
                }
            }

            //Noden till Vänster
            if (nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1].NodeValue != 999 && !closedList.Contains(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1]))
            {
                if (!openList.Contains(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1]))
                {
                    openList.Add(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1]);
                    nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1].Parent = currentSearchNode.NodePosition;
                    nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1].ParentGValue = currentSearchNode.GValue;
                    nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1].GValue = nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1].ParentGValue + gValue;
                    setFValue(nodes[(int)currentSearchNode.NodePosition.X][(int)currentSearchNode.NodePosition.Y - 1]);
                }
            }
        }
        /// <summary>
        /// Sätter dit closedList's noders fValue
        /// </summary>
        private void setFValue(Node node) 
        {
            node.FValue = node.GValue + node.NodeValue;
        }
        /// <summary>
        /// Letar efter noden med minsta fValue
        /// </summary>
        private void findLowest() 
        {
            Node tempNode = new Node();
            bool change = true;
            for (int i = 0; i < openList.Count; i++) 
            {
                if (change)
                {
                    currentSearchNode = new Node();
                    currentSearchNode = openList[i];
                }
                for (int j = 0; j < openList.Count; j++) 
                {
                    if (currentSearchNode.FValue > openList[j].FValue)
                    {
                        change = true;
                        break;
                    }
                    else
                        change = false;
                }
                if (!change)
                    break;
            }
        }

        private void createPath() 
        {
            for (int i = 0; i < closedList.Count; i++) 
            {
                path.Enqueue(closedList[i].MapPosition);
            }
        }
        #endregion
    }
}
