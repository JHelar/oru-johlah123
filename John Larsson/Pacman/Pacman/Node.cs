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
        Vector2 parent;
        Vector2 nodePosition,mapPosition;
        int nodeDistanceValue,fValue,gValue,parentGValue;

        #region Properties

        public int ParentGValue 
        {
            get { return parentGValue; }
            set { parentGValue = value; }
        }
        public Vector2 Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Vector2 MapPosition 
        {
            get { return mapPosition; }
            set { mapPosition = value; }
        }

        public Vector2 NodePosition 
        {
            get { return nodePosition; }
            set { nodePosition = value; }
        }

        public int NodeValue 
        {
            get { return nodeDistanceValue; }
            set { nodeDistanceValue = value; }
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
        #endregion
    }
}
