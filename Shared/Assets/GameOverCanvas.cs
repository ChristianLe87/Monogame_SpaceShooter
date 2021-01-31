using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameOverCanvas
    {
        Rectangle rectangle;
        Texture2D background;
        Label text;
        Button goToMenu;
        Button playAgain;

        public GameOverCanvas(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.background = Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Pink);
            this.text = new Label(
                rectangle: rectangle,
                spriteFont: Tools.Font.GenerateFont(
                    texture2D: Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Font_16),
                    chars: WK.Default.FontCharacters),
                text: "Game Over!",
                textAlignment: Label.TextAlignment.Top_Center,
                fontColor: Color.White,
                //texture: Tools.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Transparent, Width: rectangle.Width, Height: rectangle.Height),
                lineSpacing: 10);
            this.goToMenu = new Button(
                                    rectangle: new Rectangle(300, 300, 150, 50),
                                    text: "Go to Menu",
                                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.LightGray),
                                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Gray),
                                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Font_16), WK.Default.FontCharacters),
                                    fontColor: Color.Black,
                                    ButtonID: "goToMenu");

            this.playAgain = new Button(
                                    rectangle: new Rectangle(300, 400, 150, 50),
                                    text: "Play again",
                                    defaultTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.LightGray),
                                    mouseOverTexture: Tools.Texture.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Gray),
                                    spriteFont: Tools.Font.GenerateFont(Tools.Texture.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Font_16), WK.Default.FontCharacters),
                                    fontColor: Color.Black,
                                    ButtonID: "playAgain");


        }

        public void Update()
        {
            // Implementation
            {
                goToMenu.Update(goToMenu_Delegate);
                playAgain.Update(playAgain_Delegate);
            }

            // Helpers
            void goToMenu_Delegate()
            {
                Console.WriteLine("Go to menu");
                Game1.ChangeScene(WK.Scene.Menu);
            }

            void playAgain_Delegate()
            {
                Console.WriteLine("Play again");
                Game1.ChangeScene(WK.Scene.GameScene);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, rectangle, Color.White);
            goToMenu.Draw(spriteBatch);
            playAgain.Draw(spriteBatch);
            text.Draw(spriteBatch);
        }
    }
}
