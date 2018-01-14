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
            int action = 0;

            int nrOfRounds = myhistory.Count();
            List<int> cooperationOnly = new List<int>(nrOfRounds);
            List<int> defectOnly = new List<int>(nrOfRounds);
            for (int i = 0; i < nrOfRounds; i++)
            {
                cooperationOnly[i] = 0;
                defectOnly[i] = 1;
            }

            double trueReward = getReward(myhistory, yourhistory);
            double cooperationReward = getReward(cooperationOnly, yourhistory);
            double defectionReward = getReward(defectOnly, yourhistory);

            double regretCoorperation = (cooperationReward - trueReward) / nrOfRounds;
            double regretDefection = (defectionReward - trueReward) / nrOfRounds;

            Random random = new Random();
            double randomValue = random.NextDouble();
            if (regretDefection <= 0 && regretCoorperation <= 0)
            {
                action = random.Next(0, 2);
            }
            else if (randomValue < (Math.Max(0, regretDefection) / (Math.Max(0, regretDefection) + Math.Max(0, regretCoorperation))))
            {
                action = 1;
            }
            return action;
        }

        private double getReward(List<int> myActions, List<int> yourActions)
        {
            int nrOfRounds = myActions.Count();

            double reward = 0;

            for (int i = 0; i < nrOfRounds; i++)
            {
                reward += UpdateLogic.getPayoff(myActions[i], yourActions[i]);
            }
            return reward;
        }
    }

    class Majority : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;
            int timesDefected = yourhistory.FindAll(x => x == 1).Count();
            int timesCooperated = yourhistory.FindAll(x => x == 0).Count();

            if (timesDefected > timesCooperated)
            {
                action = 1;
            }
            else if (timesDefected < timesCooperated)
            {
                action = 0;
            }
            else if (timesDefected == timesCooperated)
            {
                Random random = new Random();
                action = random.Next(0, 2);
            }
            return action;
        }
    }

    class RL : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;

            double valueDefect = getValue(myhistory, yourhistory, 1);
            double valueCooperate = getValue(myhistory, yourhistory, 0);

            Random random = new Random();
            double randomValue = random.NextDouble();
            if (randomValue < (valueDefect / (valueDefect + valueCooperate)))
            {
                action = 1;
            }
            return action;
        }

        public double getValue(List<int> myhistory, List<int> yourhistory, int action)
        {

            int nrOfRounds = myhistory.Count();
            int roundsAction = 0;
            double rewardAction = 0;

            for (int i = 0; i < nrOfRounds; i++)
            {
                if (myhistory[i] == action)
                {
                    rewardAction += UpdateLogic.getPayoff(myhistory[i], yourhistory[i]);
                    roundsAction += 1;
                }
            }
            return rewardAction / roundsAction;
        }
    }
}