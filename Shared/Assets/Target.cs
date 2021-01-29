using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Target
    {
        Texture2D texture2D;
        Rectangle rectangle;
        public Point position { get => rectangle.Center; }

        public Target(Point CenterPosition, int Width, int Height)
        {
            texture2D = Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Target);
            rectangle = new Rectangle(CenterPosition.X - (Width / 2), CenterPosition.Y - (Height / 2), Width, Height);
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            int targetMove = 3;

            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
                rectangle.Y-= targetMove;
            else if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
                rectangle.Y+= targetMove;

            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
                rectangle.X-= targetMove;
            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
                rectangle.X+= targetMove;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
