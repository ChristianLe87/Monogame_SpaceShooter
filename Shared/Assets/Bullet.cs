using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Bullet
    {
        Texture2D texture2D;
        Vector2 position;
        int steps;
        TimeSpan autoDestroyTime;
        public bool isActive;
        Dir dir;
        double x;
        double y;

        public Rectangle rectangle { get => new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        public Bullet(Texture2D texture2D, Vector2 start, Vector2 direction, int steps, TimeSpan autoDestroyTime = new TimeSpan())
        {
            this.texture2D = texture2D;
            this.position = start;
            //this.b = Tools.MyMath.B(position.X, position.Y, m);
            this.steps = steps;
            this.autoDestroyTime = autoDestroyTime;

            float m = Tools.MyMath.M(start, direction);
            this.dir = GetDir(direction, m);

            this.isActive = true;

            double radAngle = Tools.MyMath.GetAngleInRadians(
                                                        Point1_Start: start.ToPoint(),
                                                        Point_1_End: new Point(WK.Default.CanvasWidth, (int)start.Y),
                                                        Point2_Start: start.ToPoint(),
                                                        Pount2_End: direction.ToPoint()
            );

            this.x = steps * Math.Cos(radAngle);
            this.y = steps * Math.Sin(radAngle);
        }

        public void Update()
        {
            // Implementation
            {
                if (isActive == false) return;

                Move();
                TimeToDestroy();
            }

            // Helpers
            void TimeToDestroy()
            {
                if (autoDestroyTime.TotalMilliseconds != 0)
                {
                    var bla = new TimeSpan(0, 0, 0, 0, (int)((1f / (WK.Default.FPS)) * 1000));
                    autoDestroyTime = autoDestroyTime.Subtract(bla);

                    if (autoDestroyTime.TotalMilliseconds <= 0) isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;

            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        private void Move()
        {
            switch (dir)
            {
                case Dir.Up:
                    position.Y -= steps;
                    break;
                case Dir.Down:
                    position.Y += steps;
                    break;
                case Dir.Right:
                    position.X += steps;
                    break;
                case Dir.Left:
                    position.X -= steps;
                    break;
                case Dir.UpLeft:
                    position.X += (float)x;
                    position.Y += (float)y;
                    break;
                case Dir.DownLeft:
                    position.X += (float)x;
                    position.Y += (float)y;
                    break;
                case Dir.UpRight:
                    position.X += (float)x;
                    position.Y += (float)y;
                    break;
                case Dir.DownRight:
                    position.X += (float)x;
                    position.Y += (float)y;
                    break;
            }
        }

        private Dir GetDir(Vector2 direction, float m)
        {
            // is inclined
            if (m != 0)
            {
                // Go left
                if (direction.X - position.X < 0)
                {
                    // go up
                    if (direction.Y - position.Y < 0)
                    {
                        return Dir.UpLeft;
                    }
                    // go down
                    else if (direction.Y - position.Y > 0)
                    {
                        return Dir.DownLeft;
                    }
                }

                // go right
                else if (direction.X - position.X > 0)
                {
                    // go up
                    if (direction.Y - position.Y < 0)
                    {
                        return Dir.UpRight;
                    }
                    // go down
                    else if (direction.Y - position.Y > 0)
                    {
                        return Dir.DownRight;
                    }
                }
            }

            // is horizontal or vertical
            else if (m == 0)
            {
                // go up
                if (direction.X == position.X && direction.Y - position.Y < 0)
                {
                    return Dir.Up;
                }
                // go down
                else if (direction.X == position.X && direction.Y - position.Y > 0)
                {
                    return Dir.Down;
                }
                // go right
                else if (direction.Y == position.Y && direction.X - position.X > 0)
                {
                    return Dir.Right;
                }
                // go left
                else if (direction.Y == position.Y && direction.X - position.X < 0)
                {
                    return Dir.Left;
                }
            }
            return Dir._;
        }

        enum Dir
        {
            Up,
            Down,
            Right,
            Left,
            UpLeft,
            DownLeft,
            UpRight,
            DownRight,
            _
        }
    }
}
