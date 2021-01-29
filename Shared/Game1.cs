using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static ContentManager contentManager;
        public static SpriteBatch spriteBatch;

        Player player;

        public Game1()
        {
            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            this.Content.RootDirectory = absolutePath;
            contentManager = this.Content;

            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.CanvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.CanvasHeight;
            graphicsDeviceManager.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // FPS
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / WK.Default.FPS);

            // Scenes
            /*scenes = new Dictionary<string, IScene>()
            {
                {WK.Scene.GameScene, new GameScene() },
                {WK.Scene.House_1, new House_1() },
                {WK.Scene.Cave, new Cave() }
            };
            scenes[actualScene].Initialize(new Point(10, 15));*/

            player = new Player(new Point(WK.Default.CanvasWidth / 2, WK.Default.CanvasHeight / 2));

            base.Initialize();
        }



        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Code
            player.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Code
            player.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }



    public class Tools
    {
        internal static Texture2D CreateColorTexture(Color color)
        {
            Texture2D newTexture = new Texture2D(Game1.graphicsDeviceManager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData(new Color[] { color });
            return newTexture;
        }

        public static Texture2D GetTexture(string imageName, string folder = "")
        {
            string absolutePath = new DirectoryInfo(Path.Combine(Path.Combine(Game1.contentManager.RootDirectory, folder), $"{imageName}.png")).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(Game1.graphicsDeviceManager.GraphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }
    }
}
