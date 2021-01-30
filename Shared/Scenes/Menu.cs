using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Menu : IScene
    {
        Button playSceneButton;

        public Menu()
        {
            Game1.isMouseVisible = true;
            Initialize();
        }

        public void Initialize()
        {
            this.playSceneButton = new Button(
                        rectangle: new Rectangle(300, 300, 150, 50),
                        text: "Play!",
                        defaultTexture: Tools.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.LightGray),
                        mouseOverTexture: Tools.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Gray),
                        spriteFont: Tools.GenerateFont(Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Font_16), WK.Default.FontCharacters),
                        fontColor: Color.Black,
                        ButtonID: "playSceneButton");
        }

        public void Update()
        {
            //playSceneButton.Update(playSceneButton_Delegate);
            Game1.isMouseVisible = true;


            playSceneButton.Update(playSceneButton_Delegate);
            void playSceneButton_Delegate()
            {
                Console.WriteLine("Play!");
                Game1.ChangeScene(WK.Scene.GameScene);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playSceneButton.Draw(spriteBatch);
        }
    }
}
