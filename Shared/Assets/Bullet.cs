using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Bullet
    {
        Texture2D texture2D;
        public Rectangle rectangle { get=> new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }
        Vector2 position;
        private Vector2 targetPoint;
        public int Health;
        private float timeCount;
        public bool isActive;

        public Bullet(Vector2 startPoint, Vector2 targetPoint)
        {
            this.texture2D = Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 10);
            this.position = startPoint;
            this.targetPoint = targetPoint;
            this.timeCount = 0f;
            this.isActive = true;
        }

        public void Update()
        {
            // Implementation
            {
                position = Tools.Other.MoveTowards(position, targetPoint, 3, 5);
                TimeToDestroy();
            }

            // Helpers
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
