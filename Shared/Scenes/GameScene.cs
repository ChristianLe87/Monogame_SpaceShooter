using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        //GameOverCanvas gameOverCanvas;
        AsteroidShooter asteroidShooter;
        GameState gameState;
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
                fontColor: Color.Red
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
            //gameOverCanvas = new GameOverCanvas();
            asteroidShooter = new AsteroidShooter(5);
            gameState = GameState.Play;
            scoreCount = 0;
        }

        public void Update()
        {
            target.Update();
            spaceship.Update(bullets, target);

            asteroids = asteroids.Where(x => x.isActive == true).ToList();
            bullets = bullets.Where(x => x.isActive == true).ToList();

            foreach (var asteroid in asteroids) asteroid.Update();
            foreach(var bullet in bullets) bullet.Update();


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

            //if(gameState == GameState.GameOver) gameOverCanvas.Update();

            asteroidShooter.Update(asteroids, spaceship.position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spaceship.Draw(spriteBatch);
            target.Draw(spriteBatch);

            foreach (var asteroid in asteroids) asteroid.Draw(spriteBatch);
            foreach(var bullet in bullets) bullet.Draw(spriteBatch);

            score.Draw(spriteBatch);
            health.Draw(spriteBatch);
            //time.Draw(spriteBatch);

            //if(gameState == GameState.GameOver) gameOverCanvas.Draw(spriteBatch);
            asteroidShooter.Draw(spriteBatch);
        }
    }

    enum GameState
    {
        Play,
        Pause,
        GameOver
    }
}
