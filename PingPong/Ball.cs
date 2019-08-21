
namespace PingPong
{
    class Ball
    {
        private double xPos;
        private double yPos;

        public Ball(double xPos, double yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public double XPos { get => xPos; set => xPos = value; }
        public double YPos { get => yPos; set => yPos = value; }
    }
}
