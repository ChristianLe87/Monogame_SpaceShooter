﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Target
    {
        Texture2D texture2D;
        public Rectangle rectangle { get => new Rectangle(position.X - (texture2D.Width / 2), position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }
        Point position;

        public Target(Point CenterPosition)
        {
            //texture2D = Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Target);
            texture2D = Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Black, 25);
            position = CenterPosition;
        }

        public void Update()
        {
            // Implementation
            {
                Move();
            }

            // Helpers
            void Move()
            {
                KeyboardState keyboardState = Keyboard.GetState();

                int targetMove = 3;

                if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
                    position.Y -= targetMove;
                else if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
                    position.Y += targetMove;

                if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
                    position.X -= targetMove;
                else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
                    position.X += targetMove;

                position.X = Tools.Other.Clamp(0, WK.Default.CanvasWidth, position.X);
                position.Y = Tools.Other.Clamp(0, WK.Default.CanvasHeight, position.Y);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
