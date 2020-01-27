using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Gui;
using ConsoleGame.Units;

namespace ConsoleGame.Game
{
    class GameScreen : Window
    {
        private int _width;
        private int _height;

        private Hero _hero;

        private List<Enemy> _enemies = new List<Enemy>();
        private List<Bullet> _bullets = new List<Bullet>();

        public int ScreenWidth
        {
            get
            {
                return _width;
            }
        }

        public int ScreenHeight
        {
            get
            {
                return _height;
            }
        }

        public GameScreen(int width, int height, char frame) : base(0, 0, width, height, frame)
        {
            _width = width;
            _height = height;
            base.Render();
        }

        public void SetHero(Hero hero)
        {
            this._hero = hero;
        }

        public int GetHeroX()
        {
            return this._hero.GetX();
        }
        
        public void MoveHeroLeft()
        {
            if (_hero.GetX() > 1)
            {
                _hero.MoveLeft();
            }
        }

        public void MoveHeroRight()
        {
            if (_hero.GetX() < _width - 2)//-2 because frame
            {
                _hero.MoveRight();
            }
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.GetY() < _height - 2)
                {
                    enemy.MoveDown();
                }
            }
        }

        public Enemy GetEnemyById(int id)
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.GetId() == id)
                {
                    return enemy;
                }
            }

            return null;
        }

        public void AddBullet(Bullet bullet)
        {
            _bullets.Add(bullet);
        }

        public void MoveAllBulletsUp()
        {
            for (int i = _bullets.Count; i > 0; i--)
            {
                if(_bullets[_bullets.Count - i].GetY() > 1)
                {
                    _bullets[_bullets.Count - i].MoveUp();
                }
                else
                {
                    _bullets[_bullets.Count - i].Clear();
                    _bullets.Remove(_bullets[_bullets.Count - i]);
                }
            }
        }

        public int CheckEnemyWorldPosition()
        {
            int killWorldEnemy = 0;

            for (int i = _enemies.Count; i > 0; i--)
            {
                if (_enemies[_enemies.Count - i].GetY() >= _height - 2)
                {
                    int indexEnemy = _enemies[_enemies.Count - i].GetId();

                    _enemies[_enemies.Count - i].Clear();

                    _enemies.Remove(_enemies[_enemies.Count - i]);

                    killWorldEnemy++;
                    i--;
                    //continue;
                }
            }

            return killWorldEnemy;
        }

        public int CheckEnemyWithHeroPosition()
        {
            //Console.SetCursorPosition(_width + 5, 5);

            for (int i = _enemies.Count; i > 0; i--)
            {
                
                //Console.WriteLine(_enemies[_enemies.Count - i].GetId() + ": "+ _enemies[_enemies.Count - i].GetY());

                if (_enemies[_enemies.Count - i].GetY() >= _height - 2 && _enemies[_enemies.Count - i].GetX() == _hero.GetX())
                {
                    int indexEnemy = _enemies[_enemies.Count - i].GetId();

                    return indexEnemy;
                }
            }

            return -1;
        }

        public override void Render()
        {
            //_hero.PrintInfo();
            _hero.Render();
            foreach (Enemy enemy in _enemies)
            {
                //enemy.PrintInfo();
                enemy.Render();
            }

            foreach (Bullet bullet in _bullets)
            {
                bullet.Render();
            }
        }

        public int CheckEnemyPositionWithBullet()
        {
            //patikrinsim bullet pataike i enemey or not

            int killBulletEnemy = 0;

            for(int j = _bullets.Count; j > 0; j--)
            {
                List<Enemy> _enemysOnlyByX = _enemies.Where(item => item.GetX() == _bullets[_bullets.Count - j].GetX()).ToList();
                
                for (int i = _enemysOnlyByX.Count; i > 0; i--)
                {
                     if (_enemysOnlyByX[_enemysOnlyByX.Count - i].GetY() == _bullets[_bullets.Count - j].GetY())
                    {
                        int indexEnemy = _enemysOnlyByX[_enemysOnlyByX.Count - i].GetId();

                        _enemysOnlyByX[_enemysOnlyByX.Count - i].Clear();

                        _enemies.Remove(_enemysOnlyByX[_enemysOnlyByX.Count - i]);

                        //remove bullets
                        _bullets[_bullets.Count - j].Clear();
                        _bullets.Remove(_bullets[_bullets.Count - j]);
                        j--;
                        killBulletEnemy++;
                        //continue;
                        //return indexEnemy;
                        break;
                    }
                }

            }

            return killBulletEnemy;
        }
        
    }
}
