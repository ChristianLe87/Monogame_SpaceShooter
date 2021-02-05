using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Bullet
    {
        Texture2D texture2D;
        Vector2 position;
        TimeSpan autoDestroyTime;
        public bool isActive;
        double x;
        double y;

        public Rectangle rectangle { get => new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        public Bullet(Texture2D texture2D, Vector2 start, Vector2 direction, int steps, TimeSpan autoDestroyTime = new TimeSpan())
        {
            this.texture2D = texture2D;
            this.position = start;
            this.autoDestroyTime = autoDestroyTime;
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
            void Move()
            {
                position.X += (float)x;
                position.Y += (float)y;
            }

            void TimeToDestroy()
            {
                if (autoDestroyTime.TotalMilliseconds != 0)
                {
                    TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)((1f / (WK.Default.FPS)) * 1000));
                    autoDestroyTime = autoDestroyTime.Subtract(timeSpan);

                    if (autoDestroyTime.TotalMilliseconds <= 0) isActive = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == false) return;
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
