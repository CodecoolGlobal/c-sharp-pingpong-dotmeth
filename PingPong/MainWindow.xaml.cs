using System;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCustomMessageBox;
using System.Threading;


namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox score;
        private TextBox pauseInfo;
        private DispatcherTimer timer;
        private ViewModel viewModel = new ViewModel();
        private double angle = 150;
        private double speed = 4;
        private int paddleSpeed = 20;

        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            score = this.FindName("Score") as TextBox;
            score.Text = "Score: 0";
            speed = 4;
            paddleSpeed = 20;
            angle = RandomGenerator.GetRandomNumber(120, 240);
            viewModel = new ViewModel();
            DataContext = viewModel;

            SetupTimer();
        }

        private void SetupTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += dispatcherTimer_Tick;
        }

        /// <summary>
        ///     Ez egy nagyon jó meth()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (viewModel.BallYPos <= 0)
                angle = angle + (180 - 2 * angle);
            if (viewModel.BallYPos >= Canvas.ActualHeight - 25)
            {
                timer.Stop();
                if (CustomMessageBox.ShowYesNo("Congratulations! You reached " + int.Parse(score.Text.Split(' ')[1]) + " points.",
                                                     "Game Over",
                                                     "New game",
                                                     "Quit") == MessageBoxResult.Yes)
                {
                    StartGame();
                }
                else
                {
                    this.Close();
                }
            }
            if (viewModel.BallXPos <= 0)
                angle = angle + (360 - 2 * angle);
            if (viewModel.BallXPos >= Canvas.ActualWidth - 35)
                angle = angle + (360 - 2 * angle);

            if (CheckCollision())
            {
                IncreaseScore();
                angle = angle + (180 - 2 * angle);
                speed += 0.1;
            }

            double radians = (Math.PI / 180) * angle;
            Vector vector = new Vector { X = Math.Sin(radians), Y = -Math.Cos(radians) };
            viewModel.BallXPos += vector.X * speed;
            viewModel.BallYPos += vector.Y * speed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pauseInfo = this.FindName("pauseText") as TextBox;
        }



        private void KeyPressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    if (viewModel.PaddleXPos < (Canvas.ActualWidth - 192))
                    {
                        viewModel.PaddleXPos += paddleSpeed;
                    }
                    break;

                case Key.Left:
                    if (!(viewModel.PaddleXPos < 0))
                    {
                        viewModel.PaddleXPos -= paddleSpeed;
                    }
                    break;

                case Key.Space:
                    Visibility status = pauseInfo.Visibility;
                    changePauseTextVisibility(status);
                    break;
                case Key.Escape:
                    timer.Stop();
                    if (CustomMessageBox.ShowYesNo("Are you sure to quit from the best game ever?",
                                                         "",
                                                         "Yes",
                                                         "Hell NO") == MessageBoxResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        timer.Start();
                    }
                    break;
            }

        }

        private void changePauseTextVisibility(Visibility status)
        {
            if (status == Visibility.Visible)
            {
                pauseInfo.Visibility = Visibility.Collapsed;
                timer.Start();
            }
            else if (status == Visibility.Collapsed)
            {
                pauseInfo.Visibility = Visibility.Visible;
                timer.Stop();
            }

        }

        private void IncreaseScore()
        {
            string scoreName = score.Text.Split(' ')[0];
            int scoreValue = int.Parse(score.Text.Split(' ')[1]) + 1;
            score.Text = $"{scoreName} {scoreValue.ToString()}";
        }

        private bool CheckCollision()
        {
            return viewModel.BallYPos > 350
                && (viewModel.BallXPos > viewModel.PaddleXPos - 10
                && viewModel.BallXPos < viewModel.PaddleXPos + 197);
        }
    }
}

