using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle rect { get; set; }

        public SnakePart(int x, int y)
        {
            X = x;
            Y = y;
            rect = new Rectangle();
            rect.Fill = Brushes.Brown;
            rect.Height = rect.Width = 9;
        }
    }
}
