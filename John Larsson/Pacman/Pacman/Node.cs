using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    public class Node
    {
        Node parent;
        GridPosition position;
        Vector2 mapPosition;
        int hValue,fValue,gValue,nodeID;
        bool wall;

        #region Properties
        
        public Node Parent
        {
            get { return parent; }
            set
            {
                if (parent == null)
                    parent = new Node();
                parent = value; 
            }
        }

        public Vector2 MapPosition 
        {
            get { return mapPosition; }
            set { mapPosition = value; }
        }

        public GridPosition Position 
        {
            get { return position; }
            set { position = value; }
        }

        public int NodeID 
        {
            get { return nodeID; }
            set { nodeID = value; }
        }
        public int HValue 
        {
            get { return hValue; }
            set { hValue = value; }
        }

        public int FValue 
        {
            get { return fValue; }
            set { fValue = value; }
        }

        public int GValue 
        {
            get { return gValue; }
            set { gValue = value; }
        }

        public bool Wall 
        {
            get { return wall; }
            set { wall = value; }
        }
        #endregion
    }

    class GridPosition 
    {
        int x, y;
        public int X 
        {
            get { return x; }
            set { x = value; }
        }
        public int Y 
        {
            get { return Y; }
            set { y = value; }
        }
    }
}
