using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Spaceship
    {
        Texture2D texture2D;
        Rectangle rectangle;

        public Spaceship(Point CenterPosition, int Width, int Height)
        {
            texture2D = Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Spaceship);
            rectangle = new Rectangle(CenterPosition.X - (Width / 2), CenterPosition.Y - (Height / 2), Width, Height);
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}
