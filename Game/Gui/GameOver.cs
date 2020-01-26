using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    sealed class GameOver : Window
    {
        private Button _menuButton;
        private Button _restartGameButton;

        private TextBlock _gameOverTextBlock;

        private List<Button> _gameOverButtonList = new List<Button>();

        public GameOver(int x, int y, int width, int height, char frame, int score, string conditionGameOver) : base(x, y, width, height, frame)//28, 10, 60, 18, '@'
        {
            List<String> creditData = new List<string>();

            creditData.Add("");
            creditData.Add("Game over: " + conditionGameOver);
            creditData.Add("Score: " + score);
            creditData.Add("");
            

            _gameOverTextBlock = new TextBlock(x + 1, y + 1, width - 1, creditData);


            _restartGameButton = new Button(x + 8, y + 5, 18, 3, "Restart");
            _restartGameButton.SetActive();

            _gameOverButtonList.Add(_restartGameButton);

            _menuButton = new Button(x + 35, y + 5, 18, 3, "Menu");

            _gameOverButtonList.Add(_menuButton);
            //_menuButton.SetActive();
        }

        public override void Render()
        {
            base.Render();
            _gameOverTextBlock.Render();

            _restartGameButton.Render();
            _menuButton.Render();

            Console.SetCursorPosition(0, 0);
        }

        public void SelectMenu(bool right)
        {
            int selectedIndex = GetSelectedButton();
            int index = -1;

            if (right)
            {
                int nextSelect = GetSelectedButton() + 1;
                index = (nextSelect > (_gameOverButtonList.Count - 1))? 0 : nextSelect;
            }
            else
            {
                int previuosSelect = GetSelectedButton() - 1;
                index = (previuosSelect < 0) ? _gameOverButtonList.Count - 1 : previuosSelect;
            }

            _gameOverButtonList[selectedIndex].NoActive();
            _gameOverButtonList[index].SetActive();

            RenderButtons();
        }

        private int GetSelectedButton()
        {
            for (int i = 0; i < _gameOverButtonList.Count; i++)
            {
                if (_gameOverButtonList[i].IsActive)
                {
                    return i;
                }
            }

            return 0;
        }

        private void RenderButtons()
        {
            foreach(Button button in _gameOverButtonList)
            {
                button.Render();
            }
        }

        public string GetMenuLabel()
        {
            for (int i = 0; i < _gameOverButtonList.Count; i++)
            {
                if (_gameOverButtonList[i].IsActive)
                {
                    return _gameOverButtonList[i].Label;
                }
            }

            return "";
        }
    }
}
