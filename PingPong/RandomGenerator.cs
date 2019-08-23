using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    public static class RandomGenerator
    {
        private static Random random = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            return random.Next((max - min) + 1) + min;
        }
    }
}
