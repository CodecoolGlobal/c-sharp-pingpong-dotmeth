using System.ComponentModel;

namespace PingPong
{
    class ViewModel : INotifyPropertyChanged
    {
        private Ball _ball = new Ball(RandomGenerator.GetRandomNumber(40, 760), RandomGenerator.GetRandomNumber(40, 120));
        private int paddleXPos = 310;

        public event PropertyChangedEventHandler PropertyChanged;
        //A comment to test my git
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
