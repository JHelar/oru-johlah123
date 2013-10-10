using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    public class Ghost
    {
        protected float speed;
        protected Vector2 position;
        protected Vector2 veloctity;

        public Vector2 Position 
        {
            get { return position; }
        }

        public Ghost(Vector2 position, float speed) 
        {
            this.speed = speed;
            this.position = position;
            veloctity = Vector2.Zero;
        }

        Queue<Vector2> waypoints = new Queue<Vector2>();

        public void SetWaypoints(Queue<Vector2> waypoints) 
        {
            foreach (var waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            position = this.waypoints.Dequeue();
        }

        float DistanceToWaypoint
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }
        }

        public void Update() 
        {
            if (waypoints.Count > 0) 
            {
                if (DistanceToWaypoint < 1f)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }
                else 
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();

                    veloctity = Vector2.Multiply(direction, speed);
                    position += veloctity;
                }
            }
        }
    }
}
