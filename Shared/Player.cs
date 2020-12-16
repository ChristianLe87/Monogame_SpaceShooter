using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Player
    {

        Texture2D texture2D;
        Rectangle spriteRectangle;
        Vector2 Origin_centerOfRotation;
        Vector2 spritePosition = new Vector2(100, 100);
        float rotation;


        Vector2 spriteVelocity;
        float tangentalVelocity = 5f; // speed
        float friction = 0.1f;

        public Player()
        {
            texture2D = Tools.GetTexture(WK.Content.Player);
            spriteRectangle = new Rectangle(250, 250, 20, 20);
        }

        public void Update()
        {
            //spriteRectangle = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, texture2D.Width, texture2D.Height);
            spritePosition = spriteVelocity + spritePosition;
            Origin_centerOfRotation = new Vector2(spriteRectangle.Width / 2, spriteRectangle.Height / 2);


            // Thanks to: https://www.youtube.com/watch?v=5q8eF9HPuvs
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                spriteVelocity.X = (float)Math.Cos(rotation);// * tangentalVelocity;
                spriteVelocity.Y = (float)Math.Sin(rotation);// * tangentalVelocity;

                // Rotate
                if (Keyboard.GetState().IsKeyDown(Keys.A)) rotation -= 0.05f;
                if (Keyboard.GetState().IsKeyDown(Keys.D)) rotation += 0.05f;

            }
            else if(spriteVelocity != Vector2.Zero)
            {
                float i = spriteVelocity.X;
                float j = spriteVelocity.Y;

                spriteVelocity.X = i -= friction * i;
                spriteVelocity.Y = j -= friction * j;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            var destinationRectangle = new Rectangle((int)spritePosition.X, (int)spritePosition.Y, 10, 10);
            //spriteBatch.Draw(texture: texture2D, spritePosition, null, Color.White, rotation, Origin_centerOfRotation, 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(texture: texture2D, position: spritePosition, sourceRectangle: null, color: Color.White, rotation: rotation, origin: Origin_centerOfRotation, scale: 1f, effects: SpriteEffects.None, layerDepth: 0f);
            spriteBatch.Draw(texture: texture2D, destinationRectangle: destinationRectangle, sourceRectangle: null, color: Color.White, rotation: rotation, origin: Origin_centerOfRotation, effects: SpriteEffects.None, layerDepth: 0f);

        }
    }
}
