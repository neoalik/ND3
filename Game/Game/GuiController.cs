using ConsoleGame.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Game
{
    public class GuiController
    {
        private GameWindow gameWindow;
        private CreditWindow creditWindow;
        private GameController gameController;

        private List<Window> gameWindows = new List<Window>();

        public GuiController()
        {
            
            //creditWindow = new CreditWindow();
        }

        public void ShowMenu()
        {
            if (gameWindow == null)
            {
                gameWindow = new GameWindow();
            }

            gameWindow.Render();

            KeyPress();
        }

        private void KeyPress()
        {
            bool needToRender = true;

            do
            {
                // isvalom ekrana
                //Console.Clear();
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            ShowWindow();
                            break;
                        case ConsoleKey.Enter:
                            ShowWindow(true);
                            break;
                        case ConsoleKey.RightArrow:
                            MenuRightMove();
                            break;
                        case ConsoleKey.LeftArrow:
                            MenuLeftMove();
                            break;
                    }
                }
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }

        private Window OpenedWindow()
        {
            for(int i = 0; i < gameWindows.Count; i++)
            {
                if (gameWindows[i].IsOpen) return gameWindows[i];
            }

            return null;
        }

        private void ShowWindow(bool enter = false)
        {
            
            if(OpenedWindow() != null)
            {
                OpenedWindow()?.Close();
                ShowMenu();
            }

            if (!enter) return;
            
            switch (gameWindow.GetLabelActiveButton)
            {
                case "Start":
                    StartGame();
                    break;
                case "Credits":
                    ShowCredit();
                    break;
                case "Quit":
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private void StartGame()
        {
            if (gameController == null)
            {
                gameController = new GameController();
            }

            Console.Clear();

            gameController.StartGame();

            ShowMenu();
        }

        private void ShowCredit()
        {
            if(creditWindow == null)
            {
                creditWindow = new CreditWindow();
                gameWindows.Add(creditWindow);
            }

            creditWindow.Render();
        }

        private void MenuLeftMove()
        {
            gameWindow.SelectMenu(false);
        }

        private void MenuRightMove()
        {
            gameWindow.SelectMenu(true);
        }
    }
}
