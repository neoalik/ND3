using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Gui;
using ConsoleGame.Units;

namespace ConsoleGame.Game
{
    class GameController
    {
        private GameScreen myGame;

        private ScoreWindow myScore;

        private LiveWorld worldLive;

        private GameOver gameOver;

        private Random rnd = new Random();

        private const int MAX_RANDOM_APPEND_ENEMY = 3;

        private const char ENEMY_MARKER = 'Ω';
        private const char HERO_MARKER = '▲';
        private const char BULLET_MARKER = '.';

        private int _enemysCounter;
        private int _bulletsCounter;
        private bool stopGame = false;

        public void StartGame()
        {
            // init game
            InitGame();

            // render loop
            StartGameLoop();

            /*gameOver = new GameOver(28, 10, 60, 10, '@', myScore.Score, "Jus nuzude enemy.");
            gameOver.Render();
            Console.ReadKey();*/
        }

        private void InitGame()
        {
            stopGame = false;
            _enemysCounter = 0;
            _bulletsCounter = 0;

            myGame = new GameScreen(50, 30, '#');

            myScore = new ScoreWindow(myGame.ScreenWidth, myGame.ScreenHeight / 3, 30);
            myScore.Render();

            worldLive = new LiveWorld(myGame.ScreenWidth, myGame.ScreenHeight / 3 + 1, 30);
            worldLive.Render();
            
            myGame.SetHero(new Hero(myGame.ScreenWidth / 2, myGame.ScreenHeight - 2, "HERO", HERO_MARKER));
            
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy(_enemysCounter, rnd.Next(1, myGame.ScreenWidth - 2), rnd.Next(1, 5), "enemy" + _enemysCounter, ENEMY_MARKER));
                _enemysCounter++;
            }
        }


        private void StartGameLoop()
        {
            bool needToRender = true;

            do
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            if (!stopGame)
                            {
                                needToRender = false;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (!stopGame)
                            {
                                myGame.MoveHeroRight();
                            }
                            else
                            {
                                gameOver?.SelectMenu(true);
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (!stopGame)
                            {
                                myGame.MoveHeroLeft();
                            }
                            else
                            {
                                gameOver?.SelectMenu(false);
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (stopGame)
                            {
                                switch (gameOver?.GetMenuLabel())
                                {
                                    case "Restart":
                                        Console.Clear();
                                        StartGame();
                                        break;
                                    case "Menu":
                                        needToRender = false;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            int id = _bulletsCounter++;
                            myGame.AddBullet(new Bullet(id, myGame.GetHeroX(), myGame.Height - 3, "Bullet" + id, BULLET_MARKER));
                            break;
                    }
                }

                if (!stopGame)
                {
                    int killBulletEnemysTime = myGame.CheckEnemyPositionWithBullet();

                    if (killBulletEnemysTime > 0)
                    {
                        myScore.SetScore(killBulletEnemysTime * 100);

                        int enemyGenerate = rnd.Next(1, MAX_RANDOM_APPEND_ENEMY);

                        for (int i = 0; i < enemyGenerate; i++)
                        {
                            myGame.AddEnemy(new Enemy(_enemysCounter, rnd.Next(1, myGame.ScreenWidth - 2), rnd.Next(1, 5), "enemy" + _enemysCounter, ENEMY_MARKER, GenerateSpeed(0.02, 0.05)));
                            _enemysCounter++;
                        }
                    }
                    

                    if (myGame.CheckEnemyWithHeroPosition() > -1)
                    {
                        stopGame = true;

                        gameOver = new GameOver(28, 10, 60, 10, '#', myScore.Score, "Jus nuzude enemy.");
                        gameOver.Render();

                        continue;
                    }

                    int killWorldEnemy = myGame.CheckEnemyWorldPosition();

                    if (killWorldEnemy > 0)
                    {
                        if (worldLive.GetLive(killWorldEnemy) <= 0)
                        {
                            stopGame = true;

                            gameOver = new GameOver(28, 10, 60, 10, '#', myScore.Score, "Miestas sugriautas");
                            gameOver.Render();

                            continue;
                        }
                    }
                    
                    myGame.MoveAllEnemiesDown();
                    myGame.MoveAllBulletsUp();

                    myGame.Render();
                }
                System.Threading.Thread.Sleep(20);
            } while (needToRender);
        }

        public double GenerateSpeed(double minimum, double maximum)
        {
            return rnd.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
