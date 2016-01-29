using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Snake
{
    class MySnake
    {
        public SnakePart Head { get; set; }
        public List<SnakePart> Parts { get; set; }

        public MySnake()
        {
            Head = new SnakePart(20, 0);
            Head.rect.Height = Head.rect.Width = 10;
            Head.rect.Fill = Brushes.Black;
            Parts = new List<SnakePart>();
            CreatDefaultParts();
        }
        
        public void CreatDefaultParts() 
        {
            
            Parts.Add(new SnakePart(19, 0));
            Parts.Add(new SnakePart(18, 0));
            Parts.Add(new SnakePart(17, 0));
            Parts.Add(new SnakePart(16, 0));
            Parts.Add(new SnakePart(15, 0));
            Parts.Add(new SnakePart(14, 0));
            Parts.Add(new SnakePart(13, 0));
            Parts.Add(new SnakePart(12, 0));
            Parts.Add(new SnakePart(11, 0));
            Parts.Add(new SnakePart(10, 0));
        }

        public void DrawSnake() 
        { 
            Grid.SetColumn(Head.rect, Head.X);
            Grid.SetRow(Head.rect, Head.Y);
            foreach(SnakePart part in Parts)
            {
                Grid.SetColumn(part.rect, part.X);
                Grid.SetRow(part.rect, part.Y);
            }
           
        }
    }
}
