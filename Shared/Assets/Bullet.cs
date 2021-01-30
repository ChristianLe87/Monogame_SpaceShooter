using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Bullet
    {
        Texture2D texture2D;
        public Rectangle rectangle;
        public Point position { get => rectangle.Center; }
        private Point targetPoint;
        public int Health;
        private float timeCount;
        public bool isActive;

        public Bullet(Point startPoint, Point targetPoint)
        {
            this.texture2D = Tools.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 10);
            this.rectangle = new Rectangle(startPoint.X - texture2D.Width/2, startPoint.Y - texture2D.Height / 2, texture2D.Width, texture2D.Height);
            this.targetPoint = targetPoint;
            this.timeCount = 0f;
            this.isActive = true;
        }

        public void Update()
        {
            // Implementation
            {
                MoveTowardTarget();
                TimeToDestroy();
            }

            // Helpers
            // Helpers
            void MoveTowardTarget()
            {
                int maxDistanceBetweenTargetAndSpaceship = 3;
                int bulletSpeed = 5;

                if (rectangle.Center.X - (targetPoint.X - maxDistanceBetweenTargetAndSpaceship) < 0)
                    rectangle.X += bulletSpeed;
                else if (rectangle.Center.X - (targetPoint.X + maxDistanceBetweenTargetAndSpaceship) > 0)
                    rectangle.X -= bulletSpeed;

                if (rectangle.Center.Y - (targetPoint.Y - maxDistanceBetweenTargetAndSpaceship) < 0)
                    rectangle.Y += bulletSpeed;
                else if (rectangle.Center.Y - (targetPoint.Y + maxDistanceBetweenTargetAndSpaceship) > 0)
                    rectangle.Y -= bulletSpeed;
            }

            void TimeToDestroy()
            {
                timeCount += 1f / WK.Default.FPS;

                int waitTime = 2;
                if (timeCount > waitTime) isActive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
