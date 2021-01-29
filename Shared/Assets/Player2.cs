using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Player2
    {

        Texture2D texture2D;
        Rectangle rectangle;
        Vector2 centerOfRotation { get => new Vector2(texture2D.Width / 2, texture2D.Height / 2); }
        float rotationDegree = 0f;



        public Player2(Point position)
        {
            texture2D = Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Spaceship);
            rectangle = new Rectangle(position.X, position.Y, 100, 100);
        }

        public void Update()
        {
            // Rotate
            if (Keyboard.GetState().IsKeyDown(Keys.A)) rotationDegree -= 5f;
            if (Keyboard.GetState().IsKeyDown(Keys.D)) rotationDegree += 5f;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                rectangle = new Rectangle(rectangle.X + 5, rectangle.Y, rectangle.Width, rectangle.Height);

                // rectangle = new Rectangle((int)Math.Cos(rotationDegree), (int)Math.Sin(rotationDegree), rectangle.Width, rectangle.Height);

            }else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                rectangle = new Rectangle(rectangle.X - 5, rectangle.Y, rectangle.Width, rectangle.Height);

            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                            texture: texture2D,
                            destinationRectangle: rectangle,
                            sourceRectangle: null,
                            color: Color.White,
                            rotation: DegreeToRadian(rotationDegree),
                            origin: centerOfRotation,
                            effects: SpriteEffects.None,
                            layerDepth: 0f);

        }

        private float DegreeToRadian(float degree)
        {
            return (float)((Math.PI / 180) * degree);
        }
    }
}
