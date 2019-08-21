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

        private TextBox score;
        public MainWindow()
        {
            InitializeComponent();


        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            score = this.FindName("Score") as TextBox;


        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                IncreaseScore();
            }
        }

        private void IncreaseScore()
        {
            string scoreName = score.Text.Split(' ')[0];
            int scoreValue = int.Parse(score.Text.Split(' ')[1]) + 1;
            score.Text = scoreName + " " + scoreValue.ToString();
        }
    }
}
