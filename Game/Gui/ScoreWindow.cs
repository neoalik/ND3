using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    sealed class ScoreWindow
    {
        private TextBlock _scoreTextBlock;

        private int _score = 0;

        private List<String> scoreData;

        public int Score
        {
            get
            {
                return _score;
            }
        }

        public ScoreWindow(int x, int y, int width)
        {
            scoreData = new List<string>();
            
            scoreData.Add($"Score: {_score}");

            _scoreTextBlock = new TextBlock(x + 1, y + 1, width - 1, scoreData);

        }

        public void Render()
        {
            _scoreTextBlock.Render();

            Console.SetCursorPosition(0, 0);
        }

        public void SetScore(int score)
        {
            _score += score;
            
            scoreData[0] = $"Score: {_score}";

            _scoreTextBlock = new TextBlock(_scoreTextBlock.X, _scoreTextBlock.Y, _scoreTextBlock.Width, scoreData);

            _scoreTextBlock.Render();
        }
    }
}
