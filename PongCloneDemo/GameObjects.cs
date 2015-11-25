using System.Xml.Schema;

namespace PongCloneDemo
{
    public class GameObjects
    {
        public Paddle PlayerPaddle { get; set; }
        public Paddle ComputerPaddle { get; set; }
        public Ball Ball { get; set; }

        public Score Score { get; set; }
    }
}
