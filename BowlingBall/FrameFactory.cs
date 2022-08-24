namespace BowlingBall
{
    public class FrameFactory
    {
        private int _maxFrames { get; }

        public FrameFactory(int maxFrames)
        {
            _maxFrames = maxFrames;
        }

        public Frame GetNewFrame(int number)
        {
            if (number == _maxFrames)
                return new LastFrame(number);

            return new Frame(number);
        }
    }
}
