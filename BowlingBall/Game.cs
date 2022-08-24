using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private List<Frame> _frames = new List<Frame>();
        private int _maxFrames;
        private int _frameNumber;
        private Frame currentFrame;
        private Scorer _scorer;
        private FrameFactory _frameFactory;

        public Game() : this(10)
        {
        }

        public Game(int maxFrames)
        {
            _maxFrames = maxFrames;
            _frameNumber = 0;
            _scorer = new Scorer();
            _frameFactory = new FrameFactory(_maxFrames);
        }

        public void Roll(int pins)
        {
            if (IsNewFrameRequired() == true)
            {
                _frameNumber++;
                currentFrame = _frameFactory.GetNewFrame(_frameNumber);
                _frames.Add(currentFrame);
            }
            currentFrame.Knock(pins);
        }

        private bool IsNewFrameRequired()
        {
            return currentFrame == null || currentFrame.IsCompleted() == true;
        }

        public int GetScore()
        {
            var score = 0;
            foreach (var frame in _frames)
            {
                if (frame.GetTypeOfFrame() == "Strike")
                {
                    score += _scorer.StrikeScore(frame, _frames);
                }
                else if (frame.GetTypeOfFrame() == "Spare")
                {
                    score += _scorer.SpareScore(frame, _frames);
                }
                else
                {
                    score += _scorer.NormalScore(frame, _frames);
                }
            }
            return score;
        }
    }
}
