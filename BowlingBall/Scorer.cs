using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Scorer
    {
        public int NormalScore(Frame frame, List<Frame> frames)
        {
            return frame.Rolls.Sum();
        }

        public int SpareScore(Frame frame, List<Frame> frames)
        {
            int score = frame.Rolls.Sum();
            var orderedRolls = frames.Where(x => x.Id > frame.Id)
                    .OrderBy(x => x.Id)
                    .SelectMany(x => x.Rolls).ToList();
            if (orderedRolls.Count >= 1)
                score += orderedRolls.First();
            return score;
        }

        public int StrikeScore(Frame frame, List<Frame> frames)
        {
            int score = frame.Rolls.Sum();
            var orderedRolls = frames.Where(x => x.Id > frame.Id)
                        .OrderBy(x => x.Id)
                        .SelectMany(x => x.Rolls).ToList();
            if (orderedRolls.Count >= 2)
                score += orderedRolls.Take(2).Sum();
            return score;
        }
    }
}