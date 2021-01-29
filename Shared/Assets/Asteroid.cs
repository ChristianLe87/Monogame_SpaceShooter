using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Asteroid
    {
        private Point position;
        private Point targetPoint;

        private Texture2D texture2D { get; init; }
        private Rectangle rectangle { get => new Rectangle(position.X - (texture2D.Width / 2), position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        private float timeCount;

        public bool isActive { get; private set; }

        public Asteroid(Point startPoint, Point targetPoint)
        {
            this.position = startPoint;
            this.targetPoint = targetPoint;

            this.texture2D = Tools.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown, 50);

            this.timeCount = 0f;
            this.isActive = true;
        }

        public void Update()
        {
            // Implementation
            {
                MoveToward();

                float maxTime = 15f;
                if (timeCount > maxTime) isActive = false;

                timeCount += 1f / WK.Default.FPS;
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
