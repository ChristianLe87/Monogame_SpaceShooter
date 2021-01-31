﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Asteroid
    {
        private Vector2 position;
        private Vector2 targetPoint;

        private Texture2D texture2D { get; init; }
        public Rectangle rectangle { get => new Rectangle((int)position.X - (texture2D.Width / 2), (int)position.Y - (texture2D.Height / 2), texture2D.Width, texture2D.Height); }

        private float timeCount;

        public bool isActive { get; set; }

        public Asteroid(Vector2 startPoint, Vector2 targetPoint)
        {
            this.position = startPoint;
            this.targetPoint = targetPoint;

            this.texture2D = Tools.Texture.CreateCircleTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Brown, 50);

            this.timeCount = 0f;
            this.isActive = true;
        }

        public void Update()
        {
            position = Tools.Other.MoveTowards(startPoint: position, endPoint: targetPoint, maxAproximation: 20, steps: 1);

            float maxTime = 15f;
            if (timeCount > maxTime) isActive = false;

            timeCount += 1f / WK.Default.FPS;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }
}