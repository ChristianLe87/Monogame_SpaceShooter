﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Game1 : Game
    {
        // a way to access the graphics devices (iPhone, Mac, Pc, PS4, etc)
        public static GraphicsDeviceManager graphicsDeviceManager;

        // Is used to draw sprites (a 2D or 3D images)
        SpriteBatch spriteBatch;

        public static ContentManager contentManager;

        Dictionary<string, IScene> scenes;
        string actualScene = "GameScene";

        public Game1()
        {
            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.CanvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.CanvasHeight;
            graphicsDeviceManager.ApplyChanges();

            // FPS
            base.IsFixedTimeStep = true;
            base.TargetElapsedTime = TimeSpan.FromSeconds(1d / 60);
            //base.TargetElapsedTime = new TimeSpan(days: 0, hours: 0, minutes: 0, seconds: 0, milliseconds: 50); // Every frame is render each 50 milliseconds


            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            base.Content.RootDirectory = absolutePath;
            Game1.contentManager = base.Content;

            //base.Window.ClientBounds
            scenes = new Dictionary<string, IScene>()
            {
                {"GameScene", new GameScene() }
            };

            // others
            if (false)
            {
                base.Window.IsBorderless = true;
                Rectangle gameWindow = base.Window.ClientBounds;
                base.Window.Title = "Hello Window";
                base.IsMouseVisible = true;
            }

            // Initialize objects (scores, values, items, etc)
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Code
        }

        protected override void UnloadContent()
        {
            // TODO: Code
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Code
            scenes[actualScene].Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // is graphicsDeviceManager
            //Game1.graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            base.GraphicsDevice.Clear(Color.CornflowerBlue);


            this.spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront, blendState: BlendState.AlphaBlend);
            //this.spriteBatch.Begin();

            // TODO: Code
            this.scenes[actualScene].Draw(spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
