using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class AsteroidShooter
    {
        Texture2D texture2D { get; init; }
        Vector2 position;
        Vector2 target;
        Vector2[] points { get; init; }
        int shootInterval { get; init; }
        float ElapsedTimeOfShootInterval;
        PathPoint targetPathPoint;

        public AsteroidShooter(int IntervalOfShootingAsterodisInSeconds)
        {
            texture2D = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red, 50, 50);
            position = new Vector2(50, 50);
            points = new Vector2[]
            {
                new Vector2(50, 50), // Top left
                new Vector2(50, WK.Default.CanvasHeight - 50), // Down left
                new Vector2(WK.Default.CanvasWidth-50, WK.Default.CanvasHeight-50), // down right
                new Vector2(WK.Default.CanvasWidth-50, 50), // top right
            };
            shootInterval = IntervalOfShootingAsterodisInSeconds;
            ElapsedTimeOfShootInterval = 0;
            targetPathPoint = PathPoint.DownLeft;
        }

        public void Update(List<Asteroid> asteroids, Vector2 asteroidTarget)
        {
            // Implementation
            {
                SetTargetPathPoint();
                position = Tools.Other.MoveTowards(startPoint: position, endPoint: target, maxAproximation: 0, steps: 1);
                ShootAsteroid();
            }

            // Helpers
            void ShootAsteroid()
            {
                if (ElapsedTimeOfShootInterval > shootInterval)
                {
                    asteroids.Add(new Asteroid(startPoint: position, targetPoint: asteroidTarget));
                    ElapsedTimeOfShootInterval = 0;
                }
                else
                {
                    ElapsedTimeOfShootInterval += 1f / WK.Default.FPS;
                }
            }

            void SetTargetPathPoint()
            {
                switch (targetPathPoint)
                {
                    case PathPoint.TopLeft:
                        target = points[0];
                        if (position.X == target.X && position.Y == target.Y)
                        {
                            targetPathPoint = PathPoint.DownLeft;
                        }
                        break;
                    case PathPoint.DownLeft:
                        target = points[1];
                        if (position.X == target.X && position.Y == target.Y)
                        {
                            targetPathPoint = PathPoint.DounRight;
                        }
                        break;
                    case PathPoint.DounRight:
                        target = points[2];
                        if (position.X == target.X && position.Y == target.Y)
                        {
                            targetPathPoint = PathPoint.DownLeft;
                            if (position.X == target.X && position.Y == target.Y)
                            {
                                targetPathPoint = PathPoint.TopRight;
                            }
                        }
                        break;
                    case PathPoint.TopRight:
                        target = points[3];
                        if (position.X == target.X && position.Y == target.Y)
                        {
                            targetPathPoint = PathPoint.TopLeft;
                        }
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, new Rectangle((int)position.X, (int)position.Y, texture2D.Width, texture2D.Height), Color.White);
        }

        private enum PathPoint
        {
            TopLeft,
            DownLeft,
            DounRight,
            TopRight
        }
    }
}
