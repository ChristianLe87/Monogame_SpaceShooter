using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Spaceship
    {
        Texture2D texture2D;
        public Rectangle rectangle { get => new Rectangle(position.X - (texture2D.Width / 2), position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }
        private Point position;
        public int Health;
        KeyboardState lastKeyboardState;

        public Spaceship(Point CenterPosition)
        {
            //this.texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Spaceship);
            this.texture2D = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Gray, 50, 50);
            this.position = CenterPosition;
            this.Health = 100;
            this.lastKeyboardState = Keyboard.GetState();
        }

        public void Update(List<Bullet> bullets, Target target)
        {
            // Implementation
            {
                position = Tools.Other.MoveTowards(position, target.rectangle.Center, 20, 1);

                Shoot();
                ChecIfGameOver();
            }
            
            // Helpers
            void Shoot()
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space))
                {
                    bullets.Add(new Bullet(startPoint: position, targetPoint: target.rectangle.Center));
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
