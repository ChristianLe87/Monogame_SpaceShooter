using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Spaceship
    {
        Texture2D texture2D;
        public Rectangle rectangle;
        public Point position { get => rectangle.Center; }

        public Spaceship(Point CenterPosition, int Width, int Height)
        {
            texture2D = Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Spaceship);
            rectangle = new Rectangle(CenterPosition.X - (Width / 2), CenterPosition.Y - (Height / 2), Width, Height);
        }

        public void Update(Target target)
        {
            // Implementation
            {
                MoveTowardTarget();
            }

            // Helpers
            void MoveTowardTarget()
            {
                int maxDistanceBetweenTargetAndSpaceship = 20;

                if (rectangle.Center.X - (target.position.X - maxDistanceBetweenTargetAndSpaceship) < 0)
                    rectangle.X++;
                else if (rectangle.Center.X - (target.position.X + maxDistanceBetweenTargetAndSpaceship) > 0)
                    rectangle.X--;

                if (rectangle.Center.Y - (target.position.Y - maxDistanceBetweenTargetAndSpaceship) < 0)
                    rectangle.Y++;
                else if (rectangle.Center.Y - (target.position.Y + maxDistanceBetweenTargetAndSpaceship) > 0)
                    rectangle.Y--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
