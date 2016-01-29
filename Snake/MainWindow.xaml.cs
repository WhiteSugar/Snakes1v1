using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySnake Snake;
        private readonly int Size = 10;
        private int directionX = 1;
        private int directionY = 0;
        private DispatcherTimer timer;
        private SnakePart Food;

        public MainWindow()
        {
            InitializeComponent();
            CreateBoard();
            CreateSnake();
            CreateFood();
            InitTimer();
          
        }

        #region CreatingMethods
        private void CreateBoard()
        {
            for (int i = 0; i < grid.Width; i++)
            {
                ColumnDefinition columnDefinitions = new ColumnDefinition();
                columnDefinitions.Width = new GridLength(Size);
                grid.ColumnDefinitions.Add(columnDefinitions);
            }
            for (int i = 0; i < grid.Height; i++)
            {
                RowDefinition rowDefinitions = new RowDefinition();
                rowDefinitions.Height = new GridLength(Size);
                grid.RowDefinitions.Add(rowDefinitions);
            }
            Snake = new MySnake();
        }

        private void CreateSnake()
        {
            grid.Children.Add(Snake.Head.rect);
            foreach (SnakePart parts in Snake.Parts)
            {
                grid.Children.Add(parts.rect);
            }
            Snake.DrawSnake();
        }
        #endregion

        #region MoveSnakeMethods
        private void MoveSnake()
        {
            for (int i = Snake.Parts.Count - 1; i >= 1; i--)
            {
                Snake.Parts[i].X = Snake.Parts[i - 1].X;
                Snake.Parts[i].Y = Snake.Parts[i - 1].Y;
            }
            Snake.Parts[0].X = Snake.Head.X;
            Snake.Parts[0].Y = Snake.Head.Y;
            Snake.Head.X += directionX;
            Snake.Head.Y += directionY;
            

            if (CheckCollision())
                EndGame();
            else
                Snake.DrawSnake();
        }

        private void InitTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
        }
        public void TimerTick(object sender, EventArgs e)
        {
            MoveSnake();
        }
        #endregion

        #region ControlMethods
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                directionX = -1;
                directionY = 0;
            }
            if (e.Key == Key.Right)
            {
                directionX = 1;
                directionY = 0;
            }
            if (e.Key == Key.Up)
            {
                directionY = -1;
                directionX = 0;
            }
            if (e.Key == Key.Down)
            {
                directionY = 1;
                directionX = 0;
            }
        }
        #endregion

        #region CreatingFoodMethods
        private void CreateFood()
        {
            Random random = new Random();
            int x = random.Next(5, 100);
            int y = random.Next(5, 100);
            Food = new SnakePart(x, y);
            Food.rect.Height = Food.rect.Width = 10;
            Food.rect.Fill = Brushes.Blue;
            grid.Children.Add(Food.rect);
            Grid.SetColumn(Food.rect, Food.X);
            Grid.SetRow(Food.rect, Food.Y);

        } 
        private void EatFood()
        {

        }
        #endregion

        #region Collision
            private bool CheckCollision()
        {
            if (CheckBoardCollision())
                return true;
            if (CheckItSelfCollision())
                return true;
            return false;
        }
        private bool CheckBoardCollision()
        {
            if (Snake.Head.X < 0 || Snake.Head.X > grid.Width / Size)
                return true;
            if (Snake.Head.Y < 0 || Snake.Head.Y > grid.Height / Size)
                return true;
            return false;
        }
        private bool CheckItSelfCollision()
        {
           foreach(SnakePart part in Snake.Parts)
            {
                if(Snake.Head.X == part.X && Snake.Head.Y == part.Y)
                    return true;
            }
            return false;
        }
        #endregion

        private void EndGame()
        {
            timer.Stop();
            MessageBox.Show("Koniec gry!"); // change latter, when menu will be here!
        }


    } // END OF CLASS
}
