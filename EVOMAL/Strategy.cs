// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : January 2018
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : PD Strategies
// SPECIAL NOTES: All Strategies should implement the interface
// ===============================
using System;
using System.Collections.Generic;
using System.Linq;


/// TODO STUDENT
namespace EVOMAL
{
    interface Strategy
    {
        /// Return 0 for cooperate and 1 for defect
        /// myhistory contains previous actions of the player
        /// yourhistory contains previous actions of the opponent
        int getAction(List<int> myhistory, List<int> yourhistory);
    }

    class All_C : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class All_D : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 1;
        }
    }

    class Randomly : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            Random random = new Random();
            return random.Next(0, 2);
        }
    }

    class TFT : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;
            if (yourhistory.Count != 0)
            {
                int lastOpponentAction = yourhistory.Last();
                if (lastOpponentAction == 1)
                {
                    action = 1;
                }
            }
            return action;
        }
    }

    class TFT2 : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;
            if (yourhistory.Count != 0)
            {
                int lastOpponentAction = yourhistory.Last();
                int secondLastOpponentAction = yourhistory[yourhistory.Count - 2];
                if (lastOpponentAction == 1 && secondLastOpponentAction == 1)
                {
                    action = 1;
                }
            }
            return action;
        }
    }

    class Pavlov : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;
            if (myhistory.Count != 0 && yourhistory.Count != 0)
            {
                int lastOwnAction = myhistory.Last();
                int lastOpponentAction = yourhistory.Last();

                // Repeat last action.
                action = lastOwnAction;

                // Change action if you lose (you cooperate, opponent defects, or both defect).
                if (lastOwnAction == 0 && lastOpponentAction == 1 ||
                    lastOwnAction == 1 && lastOpponentAction == 1)
                {
                    // Flip action from cooperate to defect or defect to cooperate.
                    action = 1 - action;
                }
            }
            return action;
        }
    }

    class Unforgiving : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;

            if (myhistory.Count != 0 && yourhistory.Count != 0)
            {
                // Find first defect of opponent, then defect yourself.
                int lastOpponentAction = yourhistory.Last();
                if (lastOpponentAction == 1)
                {
                    action = 1;
                }

                // Keep defecting if your opponent defected once.
                // This is checked in your own history: if you defected the previous round, the opponent must have defected once.
                // This calculation is more optimal than checking the whole opponent's history.
                int lastOwnAction = myhistory.Last();
                if (lastOwnAction == 1)
                {
                    action = 1;
                }
            }

            return action;
        }
    }

    class SmoothFP : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class PropNR : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class Majority : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            // Select the most occurring opponent action.
            int action = yourhistory.GroupBy(s => s)
                                    .OrderByDescending(s => s.Count())
                                    .First().Key;
            return action;
        }
    }

    class RL : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }
}