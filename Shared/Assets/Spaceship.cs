﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Spaceship
    {
        Texture2D texture2D;
        public Rectangle rectangle { get => new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }
        private Vector2 position;
        public int Health;
        KeyboardState lastKeyboardState;

        public Spaceship(Vector2 CenterPosition)
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
                position = Tools.Other.MoveTowards(position, target.rectangle.Center.ToVector2(), 20, 1);

                Shoot();
                ChecIfGameOver();
            }

            // Helpers
            void Shoot()
            {
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space))
                {
                    bullets.Add(new Bullet(
                                        texture2D: Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 10),
                                        start: position,
                                        direction: target.rectangle.Center.ToVector2(),
                                        steps: 1
                                        )
                    );
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
