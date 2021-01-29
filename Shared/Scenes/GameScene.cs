using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Spaceship spaceship;
        Target target;
        //List<Asteroid> asteroids;
        //List<Bullet> bullets;
        //Label score;
        //Label time;
        //GameOverCanvas gameOverCanvas;
        //AsteroidShooter asteroidShooter;
        GameState gameState;
        //int scoreCount;

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
            //asteroids = new List<Asteroid>();
            //bullets = new List<Bullet>();
            //score = new Label();
            //time = new Label();
            //gameOverCanvas = new GameOverCanvas();
            //asteroidShooter = new AsteroidShooter();
            gameState = GameState.Play;
            //scoreCount = 0;
        }

        public void Update()
        {
            target.Update();
            spaceship.Update(target);

            //foreach(var asteroid in asteroids) asteroid.Update();
            //foreach(var bullet in bullets) bullet.Update();

            //score.Update();
            //time.Update();

            //if(gameState == GameState.GameOver) gameOverCanvas.Update();

            //asteroidShooter.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spaceship.Draw(spriteBatch);
            target.Draw(spriteBatch);

            //foreach(var asteroid in asteroids) asteroid.Draw(spriteBatch);
            //foreach(var bullet in bullets) bullet.Draw(spriteBatch);

            //score.Draw(spriteBatch);
            //time.Draw(spriteBatch);

            //if(gameState == GameState.GameOver) gameOverCanvas.Draw(spriteBatch);
        }
    }

    enum GameState
    {
        Play,
        Pause,
        GameOver
    }
}
