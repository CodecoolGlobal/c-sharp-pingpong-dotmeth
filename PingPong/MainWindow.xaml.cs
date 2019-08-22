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


namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ellipse ball;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void spawnBall(object sender, RoutedEventArgs e)
        {
            if (ball != null)
            {
                return;
            }
            ball = new Ellipse();
            ball.Height = 20;
            ball.Width = 20;
            ball.HorizontalAlignment = HorizontalAlignment.Center;
            ball.VerticalAlignment = VerticalAlignment.Center;
            ball.Stroke = Brushes.Black;
            ball.Fill = Brushes.LightSalmon;
            int posX = RandomGenerator.GetRandomNumber(0, (int)this.ActualWidth);
            int posY = RandomGenerator.GetRandomNumber(0, (int)this.ActualHeight);
            Canvas.SetLeft(ball, posX);
            Canvas.SetTop(ball, posY);
            canvas.Children.Add(ball);
        }

        private void deleteBall(object sender, RoutedEventArgs e)
        {
            canvas.Children.Remove(ball);
            ball = null;
        }
    }
}
