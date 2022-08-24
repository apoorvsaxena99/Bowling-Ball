using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class Frame
    {
        public int Score { get; set; }
        public int Id { get; }
        public List<int> Rolls = new List<int>();

        public Frame(int frameId)
        {
            Id = frameId;
        }
        public void Knock(int pins)
        {
            Rolls.Add(pins);
        }

        public virtual bool IsCompleted()
        {
            if (Rolls.Count > 0)
                if (Rolls[0] == 10)
                    return true;
                else if (Rolls.Count == 2)
                    return true;
            return false;

        }
        public virtual string GetTypeOfFrame()
        {
            if (Rolls.Count > 0)
                if (Rolls[0] == 10)
                    return "Strike";
                else if (Rolls.Take(2).Sum() == 10)
                    return "Spare";
            return "Normal";
        }
    }
}
