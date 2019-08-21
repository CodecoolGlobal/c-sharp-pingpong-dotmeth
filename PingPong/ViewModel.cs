using System.ComponentModel;

namespace PingPong
{
    class ViewModel : INotifyPropertyChanged
    {
        private Ball ball = new Ball(40, 200);
        private int paddleXPos = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public double BallXPos
        {
            get { return ball.XPos; }
            set
            {
                ball.XPos = value;
                OnPropertyRaised("BallXPos");
            }
        }

        public double BallYPos
        {
            get { return ball.YPos; }
            set
            {
                ball.YPos = value;
                OnPropertyRaised("BallYPos");
            }
        }

        public int PaddleXPos
        {
            get { return paddleXPos; }
            set
            {
                paddleXPos = value;
                OnPropertyRaised("PaddleXPos");
            }
        }
    }
}
