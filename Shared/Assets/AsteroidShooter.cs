using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class AsteroidShooter
    {
        Texture2D texture2D;
        Point position;
        Point target;
        Point[] points;
        int shootInterval { get; init; }
        float ElapsedTimeOfShootInterval;

        public AsteroidShooter(int IntervalOfShootingAsterodisInSeconds)
        {
            texture2D = Tools.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red, 50, 50);
            position = new Point(50, 50);
            points = new Point[]
            {
                new Point(50, 50), // Top left
                new Point(50, WK.Default.CanvasHeight - 50), // Down left
                new Point(WK.Default.CanvasWidth-50, WK.Default.CanvasHeight-50), // down right
                new Point(WK.Default.CanvasWidth-50, 50), // top right
            };
            shootInterval = IntervalOfShootingAsterodisInSeconds;
            ElapsedTimeOfShootInterval = 0;
        }

        public void Update(List<Asteroid> asteroids, Point asteroidTarget)
        {
            // Implementation
            {
                target = points[1];
                MoveTowardTarget();

                if (ElapsedTimeOfShootInterval > shootInterval)
                {
                    asteroids.Add(new Asteroid(
                                        startPoint: position,
                                        targetPoint: asteroidTarget
                                        ));

                    ElapsedTimeOfShootInterval = 0;
                }
                else
                {
                    ElapsedTimeOfShootInterval += 1f / WK.Default.FPS;
                }
            }
            

            void MoveTowardTarget()
            {
                int maxDistanceBetweenTargetAndSpaceship = 20;

                if (position.X - (target.X - maxDistanceBetweenTargetAndSpaceship) < 0)
                    position.X++;
                else if (position.X - (target.X + maxDistanceBetweenTargetAndSpaceship) > 0)
                    position.X--;

                if (position.Y - (target.Y - maxDistanceBetweenTargetAndSpaceship) < 0)
                    position.Y++;
                else if (position.Y - (target.Y + maxDistanceBetweenTargetAndSpaceship) > 0)
                    position.Y--;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, new Rectangle(position.X, position.Y, texture2D.Width, texture2D.Height), Color.White);
        }
    }
}
