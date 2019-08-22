﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCustomMessageBox;

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
            DataContext = viewModel;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            timer.Tick += dispatcherTimer_Tick;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (viewModel.BallYPos <= 0)
                angle = angle + (180 - 2 * angle);
            if (viewModel.BallYPos >= Canvas.ActualHeight - 25)
            {
                //angle = angle + (180 - 2 * angle);
                timer.Stop();
                if (CustomMessageBox.ShowYesNo("Congratulations! You reached " + int.Parse(score.Text.Split(' ')[1]) + "points.",
                                                     "Game Over",
                                                     "New game",
                                                     "Quit") == MessageBoxResult.Yes)
                {
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

            if(CheckCollision())
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
            score = this.FindName("Score") as TextBox;
            pauseInfo = this.FindName("pauseText") as TextBox;
        }

        private void KeyPressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if (viewModel.PaddleXPos > (Canvas.ActualWidth - 197))
                {
                    viewModel.PaddleXPos = (int)Canvas.ActualWidth - 197;
                }
                viewModel.PaddleXPos += paddleSpeed;
            }
            else if (e.Key == Key.Left)
            {
                if (viewModel.PaddleXPos < 0)
                {
                    viewModel.PaddleXPos = 0;
                }
                viewModel.PaddleXPos -= paddleSpeed;
            }

            else if (e.Key == Key.Space)
            {
                Visibility status = pauseInfo.Visibility;
                changePauseTextVisibility(status);
            }
            else if (e.Key == Key.Escape)
            {
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
            score.Text = scoreName + " " + scoreValue.ToString();
        }

        private bool CheckCollision()
        {
            return viewModel.BallYPos > 350 && (viewModel.BallXPos > viewModel.PaddleXPos - 10 && viewModel.BallXPos < viewModel.PaddleXPos + 197);
        }
    }
}

