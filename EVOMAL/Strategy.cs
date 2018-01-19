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
            // Always cooperate
            return 0;
        }
    }

    class All_D : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            // Always Defect
            return 1;
        }
    }

    class Randomly : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            // Get a random action
            int action = randomAction.fullyRandomAction();
            return action;
        }
    }

    class TFT : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            // Play cooperate, unless the last action of your opponent was to defect.
            int action = 0;
            if (yourhistory.Count > 0)
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
            // Play cooperate, unless the last two actions of your opponent were to defect.
            int action = 0;
            if (yourhistory.Count > 1)
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
            if (myhistory.Count > 0 && yourhistory.Count > 0)
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

            if (myhistory.Count > 0 && yourhistory.Count > 0)
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
            int action = 0;

            // Find the number of times the opponent defected and the total number of played rounds.
            int timesOpponentDefect = yourhistory.FindAll(x => x == 1).Count();
            int nrOfPlayedRounds = yourhistory.Count();

            if (nrOfPlayedRounds > 0)
            {
                // Calculate the mixed strategy of your opponent. 
                double[] opponentStrategy = { 1 - (timesOpponentDefect / nrOfPlayedRounds), (timesOpponentDefect / nrOfPlayedRounds) };

                // Calculate the expected reward of your actions, given the strategy of the opponent.
                double expectedRewardDefect = opponentStrategy[0] * UpdateLogic.getPayoff(1, 0) + opponentStrategy[1] * UpdateLogic.getPayoff(1, 1);
                double expectedRewardCooperate = opponentStrategy[0] * UpdateLogic.getPayoff(0, 0) + opponentStrategy[1] * UpdateLogic.getPayoff(0, 1);

                // Choose an action proportional to the expected reward of that action. 
                double probabilityDefect = expectedRewardDefect / (expectedRewardDefect + expectedRewardCooperate);
                action = randomAction.proportionalAction(probabilityDefect);
            }

            return action;
        }
    }

    class PropNR : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            int action = 0;

            int nrOfRounds = myhistory.Count();
            if (nrOfRounds > 0)
            {
                // Make a list of actions consisting of only zeros or ones, as if you only cooperated or defected in the game history. 
                List<int> cooperationOnly = new List<int>(nrOfRounds);
                List<int> defectOnly = new List<int>(nrOfRounds);
                for (int i = 0; i < nrOfRounds; i++)
                {
                    cooperationOnly.Add(0);
                    defectOnly.Add(1);
                }

                // Calculate the earned reward and the reward you would have earned by only cooperating or only defecting.
                double trueReward = getReward(myhistory, yourhistory);
                double cooperationReward = getReward(cooperationOnly, yourhistory);
                double defectionReward = getReward(defectOnly, yourhistory);

                // Calculate the regret of each action
                double regretCooperation = (cooperationReward - trueReward) / nrOfRounds;
                double regretDefection = (defectionReward - trueReward) / nrOfRounds;

                // This picks each action with a probability proportional to its regret, or a random action if the regret of both actions is negative. 
                if (regretDefection <= 0 && regretCooperation <= 0)
                {
                    action = randomAction.fullyRandomAction();
                }
                else
                {
                    double probabilityDefect = Math.Max(0, regretDefection) / (Math.Max(0, regretDefection) + Math.Max(0, regretCooperation));
                    action = randomAction.proportionalAction(probabilityDefect);
                }
            }

            return action;
        }

        public double getReward(List<int> myActions, List<int> yourActions)
        {
            int nrOfRounds = myActions.Count();
            double reward = 0;

            // This calculates the sum of the rewards earned in each round in history. 
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

            // Find the number of times your opponent defected or cooperated in history. 
            int timesDefected = yourhistory.FindAll(x => x == 1).Count();
            int timesCooperated = yourhistory.FindAll(x => x == 0).Count();

            // Choose the action you opponent played most, or a random action if the opponent played defect and cooperate equally often. 
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
                action = randomAction.fullyRandomAction();
            }

            return action;
        }
    }

    class RL : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            // Calculate the average of the rewards you gained in history when you played defect, and when you played cooperate. 
            double valueDefect = getValue(myhistory, yourhistory, 1);
            double valueCooperate = getValue(myhistory, yourhistory, 0);

            // This picks each action with a probability proportional to the value of that action.
            double probabilityDefect = 0;
            if (valueDefect + valueCooperate > 0)
            {
                probabilityDefect = valueDefect / (valueDefect + valueCooperate);
            }
            int action = randomAction.proportionalAction(probabilityDefect);
            return action;
        }

        public double getValue(List<int> myhistory, List<int> yourhistory, int action)
        {
            int nrOfRounds = myhistory.Count();
            int roundsAction = 0;
            double rewardAction = 0;

            // Calculate the sum of payoffs, earned when playing action.  
            for (int i = 0; i < nrOfRounds; i++)
            {
                if (myhistory[i] == action)
                {
                    rewardAction += UpdateLogic.getPayoff(myhistory[i], yourhistory[i]);
                    roundsAction += 1;
                }
            }

            // Returns the average payoff of action.
            if(roundsAction == 0)
            {
                return 6;
            }
            else
            {
                return rewardAction / roundsAction;
            }
        }
    }


    static class randomAction
    {
        static Random random = new Random();

        public static int proportionalAction(double probabilityDefect)
        {
            // Gives defect as action with probability probabilityDefect, and cooperate with probabbility 1-probabilityDefect
            int action = 0;
            double randomValue = random.NextDouble();
            if (randomValue < (probabilityDefect))
            {
                action = 1;
            }
            return action;
        }

        public static int fullyRandomAction()
        {
            // Return 0 or 1 with equal probability. 
            return random.Next(0, 2);
        }
    }
}