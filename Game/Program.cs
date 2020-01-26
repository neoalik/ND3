using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGame.Game;
using ConsoleGame.Gui;

namespace ConsoleGame
{
    class Program
    {
        static void Main()
        {
            Utils.DisableConsoleQuickEdit.Go();//cia tam kad pele negalima butu statyti zemeklio
            Console.CursorVisible = false;

            Console.OutputEncoding = Encoding.UTF8;

            /*GameWindow gameWindow = new GameWindow();
            gameWindow.Render();

            CreditWindow creditWindow = new CreditWindow();
            creditWindow.Render();*/



            //GameController myGame = new GameController();
            //myGame.StartGame();


            //

            GuiController guiController = new GuiController();

            guiController.ShowMenu();

            //double number = 1.99 + 0.01 + 0.01;

            //long intPart = (long)number;
            //double fractionalPart = number - intPart;

            //Console.WriteLine((int)number);

            //Console.ReadKey();

            //Console.ReadKey();

        }
    }
}
