using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    sealed class GameWindow : Window
    {
        private Button _startButton;
        private Button _creditsButton;
        private Button _quitButton;
        private TextBlock _titleTextBlock;

        private List<Button> _buttonsMenu;

        public string GetLabelActiveButton
        {
            get
            {
                for (int i = 0; i < _buttonsMenu.Count; i++)
                {
                    if (_buttonsMenu[i].IsActive) return _buttonsMenu[i].Label;
                }

                return "";
            }
        }


        public GameWindow() : base(0, 0, 120, 30, '#')
        {
            _titleTextBlock = new TextBlock(10, 5, 100, new List<String> {"Super duper zaidimas", "Vardas Pavardaitis kuryba!", "Made in Vilnius Coding School!"});

            _startButton = new Button(20, 13, 18, 5, "Start");
            _startButton.SetActive();

            _creditsButton = new Button(50, 13, 18, 5, "Credits");

            _quitButton = new Button(80, 13, 18, 5, "Quit");

            _buttonsMenu = new List<Button>()
            {
                _startButton,
                _creditsButton,
                _quitButton
            };
        }
        
        public override void Render()
        {
            base.Render();

            _titleTextBlock.Render();

            _startButton.Render();
            _creditsButton.Render();
            _quitButton.Render();

            Console.SetCursorPosition(0, 0);
        }

        public void RenderMenuButtons()
        {
            _startButton.Render();
            _creditsButton.Render();
            _quitButton.Render();
        }

        private int GetIndexActiveButtonMenu()
        {
            for(int i = 0; i < _buttonsMenu.Count; i++)
            {
                if (_buttonsMenu[i].IsActive)
                {
                    return i;
                }
            }

            return -1;
        }
        
        public void SelectMenu(bool right)
        {
            int index = GetIndexActiveButtonMenu();

            int nextMenuButtonIndex = (right)? index + 1 : index - 1;

            int maxMenuButton = _buttonsMenu.Count - 1;

            if (nextMenuButtonIndex < 0)
            {
                nextMenuButtonIndex = maxMenuButton;
            }

            if (nextMenuButtonIndex > maxMenuButton)
            {
                nextMenuButtonIndex = 0;
            }

            _buttonsMenu[index].NoActive();
            _buttonsMenu[nextMenuButtonIndex].SetActive();


            RenderMenuButtons();//Render();
        }
    }
}
