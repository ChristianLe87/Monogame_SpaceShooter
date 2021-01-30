using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Spaceship
    {
        Texture2D texture2D;
        public Rectangle rectangle;
        public Point position { get => rectangle.Center; }
        public int Health;
        KeyboardState lastKeyboardState;

        public Spaceship(Point CenterPosition, int Width, int Height)
        {
            this.texture2D = Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Spaceship);
            this.rectangle = new Rectangle(CenterPosition.X - (Width / 2), CenterPosition.Y - (Height / 2), Width, Height);
            this.Health = 100;
            this.lastKeyboardState = Keyboard.GetState();
        }

        public void Update(List<Bullet> bullets, Target target)
        {
            // Implementation
            {
                MoveTowardTarget();
                Shoot();
                ChecIfGameOver();
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

            void Shoot()
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space))
                {
                    bullets.Add(new Bullet(startPoint: position, targetPoint: target.position));
                }

                lastKeyboardState = keyboardState;
            }

            void ChecIfGameOver()
            {
                if (Health <= 0)
                    GameScene.gameState = GameState.GameOver;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
