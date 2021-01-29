using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Asteroid
    {
        private Point position;
        private Point targetPoint;

        Texture2D texture2D;
        Rectangle rectangle { get => new Rectangle(position.X - (texture2D.Width / 2), position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        public Asteroid(Point startPoint, Point targetPoint)
        {
            this.position = startPoint;
            this.targetPoint = targetPoint;

            texture2D = Tools.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown, 50);
        }

        public void Update()
        {
            // Implementation
            {
                MoveToward();
            }
            

            // Helpers
            void MoveToward()
            {
                int maxAproximationToTarget = 20;
                if (position.X - (targetPoint.X - maxAproximationToTarget) < 0)
                    position.X++;
                else if (position.X - (targetPoint.X + maxAproximationToTarget) > 0)
                    position.X--;

                if (position.Y - (targetPoint.Y - maxAproximationToTarget) < 0)
                    position.Y++;
                else if (position.Y - (targetPoint.Y + maxAproximationToTarget) > 0)
                    position.Y--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
