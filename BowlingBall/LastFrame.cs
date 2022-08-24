using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingBall
{
    public class LastFrame : Frame
    {
        public LastFrame(int frameId) : base(frameId)
        {

        }
        public override bool IsCompleted()
        {
            if (Rolls.Count == 3)
                return true;
            if (Rolls.Count == 2)
                if (Rolls.Sum() == 10)
                    return false;
                else if (Rolls[0] != 10)
                    return true;
            return false;
        }
    }
}