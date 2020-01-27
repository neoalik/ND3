using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Gui
{
    sealed class LiveWorld
    {
        private TextLine _liveTextBlock;

        private int _live;

        private char _liveMarker;
        

        public LiveWorld(int x, int y, int width, int maxLive = 3, char liveMarker = '♥')//♥
        {
            _liveMarker = liveMarker;

            _live = maxLive;

            _liveTextBlock = new TextLine(x + 1, y + 1, width - 1, $"Live: {BuildLive(_live, _liveMarker)}");
        }

        private string BuildLive(int live, char liveMarker)
        {
            string lives = "";

            for(int i = 0; i < live; i++)
            {
                lives += liveMarker;
            }

            return lives;
        }

        public void Render()
        {
            _liveTextBlock.Render();

            Console.SetCursorPosition(0, 0);
        }
        
        public int GetLive(int lostlive = 0)
        {
            //lostlive = Math.Abs(lostlive);

            if (lostlive > 0)
            {
                char[] lives = _liveTextBlock.Label.ToCharArray();

                for (int i = 0; i < lostlive; i++)
                {
                    if (_live > 0)
                    {

                        lives[lives.Length - _live] = ' ';

                        _live = _live - 1;
                    }
                }

                _liveTextBlock.Label = new string(lives);
            }

            return _live;
        }
    }
}
