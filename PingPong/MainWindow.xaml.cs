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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TextBox score;
        private TextBox pauseInfo;
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Paddle_Move);

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            score = this.FindName("Score") as TextBox;
            pauseInfo = this.FindName("pauseText") as TextBox;
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IncreaseScore();
            }
            else if (e.Key == Key.Space)
            {
                Visibility status = pauseInfo.Visibility;
                PauseGame();
                changePauseTextVisibility(status);
            }
        }

        private void changePauseTextVisibility(Visibility status)
        {
            if (status == Visibility.Visible)
            {
                pauseInfo.Visibility = Visibility.Collapsed;
            }
            else if (status == Visibility.Collapsed)
            {
                pauseInfo.Visibility = Visibility.Visible;
            }

        }

        private void IncreaseScore()
        {
            string scoreName = score.Text.Split(' ')[0];
            int scoreValue = int.Parse(score.Text.Split(' ')[1]) + 1;
            score.Text = scoreName + " " + scoreValue.ToString();
        }

        public void Paddle_Move(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                //var trs = new TranslateTransform();
                //var anim3 = new DoubleAnimation(0, -20, TimeSpan.FromSeconds(2));
                //trs.BeginAnimation(TranslateTransform.XProperty, anim3);
                //MyPaddle.RenderTransform = trs;
                Canvas.SetLeft(Paddle, Canvas.GetLeft(Paddle) - 10);
            }
            if (e.Key == Key.Right)
            {
                Canvas.SetLeft(Paddle, Canvas.GetLeft(Paddle) + 10);
            }
        }

        private void PauseGame()
        {
            throw new NotImplementedException();
        }

    }
}

