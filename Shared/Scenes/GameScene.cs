using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class GameScene : IScene
    {
        Spaceship spaceship;
        Target target;
        List<Asteroid> asteroids;
        List<Bullet> bullets;
        Label score;
        HealthBar health;
        //Label time;
        GameOverCanvas gameOverCanvas;
        AsteroidShooter asteroidShooter;
        public static GameState gameState;
        int scoreCount;

        public GameScene()
        {
            Initialize();
        }

        public void Initialize()
        {
            spaceship = new Spaceship(
                                CenterPosition: new Point(350, 350),
                                Width: 50,
                                Height: 50
                                );
            target = new Target(
                                CenterPosition: new Point(550, 350),
                                Width: 50,
                                Height: 50
                                );
            asteroids = new List<Asteroid>();
            bullets = new List<Bullet>();
            score = new Label(
                rectangle: new Rectangle(0, 0, 200, 50),
                spriteFont: Tools.GenerateFont(Tools.GetTexture(Game1.graphicsDeviceManager.GraphicsDevice, Game1.contentManager, WK.Content.Font_16), chars: WK.Default.FontCharacters),
                text: "Score: 0",
                textAlignment: Label.TextAlignment.Midle_Center,
                fontColor: Color.Red,
                lineSpacing: 10
                );
            health = new HealthBar(
                topTexture: Tools.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Green),
                backTexture: Tools.CreateColorTexture(Game1.graphicsDeviceManager.GraphicsDevice, Color.Red),
                rectangle: new Rectangle(WK.Default.CanvasWidth - 225, 25, 200, 25),
                direction: Direction.Right,
                maxVal: (uint)spaceship.Health,
                reduceValue: 10,
                startValue: (uint)spaceship.Health
                );
            //time = new Label();
            gameOverCanvas = new GameOverCanvas(new Rectangle(200, 200, 300, 300));
            asteroidShooter = new AsteroidShooter(5);
            gameState = GameState.GameOver;
            scoreCount = 0;
        }

        public void Update()
        {
            // gameover mode
            /*{
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.P))
                {
                    spaceship.Health -= 10;
                    health.Reduce();
                }
            }*/

            switch (gameState)
            {
                case GameState.Play:
                    target.Update();
                    spaceship.Update(bullets, target);

                    asteroids = asteroids.Where(x => x.isActive == true).ToList();
                    bullets = bullets.Where(x => x.isActive == true).ToList();

                    foreach (var asteroid in asteroids)
                        asteroid.Update();

                    foreach (var bullet in bullets)
                        bullet.Update();


                    foreach (var asteroid in asteroids)
                    {
                        // destroy asteroids when bullet touch
                        foreach (var bullet in bullets)
                        {
                            if (bullet.rectangle.Intersects(asteroid.rectangle))
                            {
                                asteroid.isActive = false;
                                bullet.isActive = false;

                                scoreCount += 15;

                                score.Update($"Score: {scoreCount}");
                            }
                        }


                        // destroy asteroids when spaceship touch
                        if (asteroid.rectangle.Intersects(spaceship.rectangle))
                        {
                            asteroid.isActive = false;

                            scoreCount -= 10;
                            if (scoreCount < 0) scoreCount = 0;

                            spaceship.Health -= 10;
                            if (spaceship.Health < 0) spaceship.Health = 0;

                            score.Update($"Score: {scoreCount}");
                            health.Reduce();
                        }
                    }
                    //time.Update();
                    asteroidShooter.Update(asteroids, spaceship.position);
                    break;
                case GameState.Pause:
                    break;
                case GameState.GameOver:
                    gameOverCanvas.Update();
                    Game1.isMouseVisible = true;
                    break;
                default:
                    Game1.ChangeScene(WK.Scene.Menu);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case GameState.Play:
                    spaceship.Draw(spriteBatch);
                    target.Draw(spriteBatch);

                    foreach (var asteroid in asteroids) asteroid.Draw(spriteBatch);
                    foreach (var bullet in bullets) bullet.Draw(spriteBatch);

                    score.Draw(spriteBatch);
                    health.Draw(spriteBatch);
                    //time.Draw(spriteBatch);
                    asteroidShooter.Draw(spriteBatch);
                    break;
                case GameState.Pause:
                    break;
                case GameState.GameOver:
                    gameOverCanvas.Draw(spriteBatch);
                    break;
                default:
                    break;
            }
        }
    }

    public enum GameState
    {
        Play,
        Pause,
        GameOver
    }
}
