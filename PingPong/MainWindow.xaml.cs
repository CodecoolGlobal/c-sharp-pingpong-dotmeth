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
        public MainWindow()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Paddle_Move);
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
    }
}

