// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : January 2018
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Creation of score table methods and replicator equation
// SPECIAL NOTES: PD payoff matrix also goes here
// ===============================
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVOMAL
{
    static class UpdateLogic
    {
        static Random random = new Random();

        /// Returns the score table for all 11 strategies
        /// strategies consists of 11 strategy objects
        static public double[,] scoreTable(int nrrounds, int nrrestarts, Strategy[] strategies, double noise)
        {
            int numberOfStrategies = strategies.Length;
            double[,] scoreTable = new double[numberOfStrategies, numberOfStrategies];

            for (int ownStrategyIndex = 0; ownStrategyIndex < numberOfStrategies; ownStrategyIndex++)
            {
                for (int opponentStrategyIndex = 0; opponentStrategyIndex < numberOfStrategies; opponentStrategyIndex++)
                {
                    double totalPayoff = 0;

                    for (int gameNumber = 0; gameNumber < nrrestarts; gameNumber++)
                    {
                        Strategy ownStrategy = strategies[ownStrategyIndex];
                        Strategy opponentStrategy = strategies[opponentStrategyIndex];
                        double gamePayoff = playGame(nrrounds, ownStrategy, opponentStrategy, noise);
                        totalPayoff += gamePayoff;
                    }
                    scoreTable[ownStrategyIndex, opponentStrategyIndex] = totalPayoff / (nrrestarts * nrrounds);
                }
            }

            return scoreTable;
        }


        // Return total payoff after playing a complete game.
        static private double playGame(int nrrounds, Strategy ownStrategy, Strategy opponentStrategy, double noise)
        {
            List<int> ownHistory = new List<int>();
            List<int> opponentHistory = new List<int>();

            double totalGamePayoff = 0;

            for (int roundNumber = 0; roundNumber < nrrounds; roundNumber++)
            {
                double roundPayoff = playRound(ownStrategy, opponentStrategy, ownHistory, opponentHistory, noise);
                totalGamePayoff += roundPayoff;
            }

            return totalGamePayoff;
        }

        // Return payoff after playing a round.
        static private double playRound(Strategy ownStrategy, Strategy opponentStrategy, List<int> ownHistory, List<int> opponentHistory, double noise)
        {
            int ownAction = selectAction(ownStrategy, ownHistory, opponentHistory, noise);
            int opponentAction = selectAction(opponentStrategy, opponentHistory, ownHistory, noise);

            ownHistory.Add(ownAction);
            opponentHistory.Add(opponentAction);

            double payoff = getPayoff(ownAction, opponentAction);
            return payoff;
        }

        static private int selectAction(Strategy ownStrategy, List<int> ownHistory, List<int> opponentHistory, double noise)
        {
            int ownAction = ownStrategy.getAction(ownHistory, opponentHistory);
            // Select random action with a low noise probability.
            if (random.NextDouble() < noise)
            {
                ownAction = random.Next(0, 2);
            }
            return ownAction;
        }


        // TODO make double payoff type
        static private int getPayoff(int myAction, int yourAction)
        {
            int payoff = 0; 
            if(myAction ==0 && yourAction ==0)
            {
                payoff = 3;
            }
            else if (myAction == 1 && yourAction == 0)
            {
                payoff = 5;
            }
            else if (myAction == 1 && yourAction == 1)
            {
                payoff = 1;
            }
            return payoff;    
        }

        /// Returns the proportions for the next time step
        /// proportions contains the proportions at current time
        /// scoreTable contains the score table created in the scoreTable method
        static public double[] replicator(double[] proportions, double[,] scoreTable, double birthrate)
        {
            double scoreTableAverage = calculateScoreTableAverage(scoreTable);
            int amountOfRows = scoreTable.GetLength(0);
            int amountOfColumns = scoreTable.GetLength(1);

            double[] newProportions = new double[proportions.Length];

            for (int strategyIndex = 0; strategyIndex < amountOfRows; strategyIndex++)
            {
                double proportionStrategy = proportions[strategyIndex];
                //scoreTableStrategy = vector multiplication proportion times row of score table
                double scoreTableStrategy = 0;
                newProportions[strategyIndex] = (proportionStrategy * (1 + birthrate * scoreTableStrategy)) / (1 + birthrate * scoreTableAverage);
            }
            return newProportions;
        }

        static private double calculateScoreTableAverage(double[,] scoreTable)
        {
            double sum = 0;
            int amountOfRows = scoreTable.GetLength(0);
            int amountOfColumns = scoreTable.GetLength(1);

            for (int i = 0; i < amountOfRows; i++)
            {
                for (int j = 0; j < amountOfColumns; j++)
                {
                    sum += scoreTable[i, j];
                }
            }

            double average = sum / (amountOfRows * amountOfColumns);
            return average;
        }

        // TODO make function for vector multiplication proportions with row of score table
        Strategy = i;
        sum = 0;
        for column j in columns
            sum +=  proportion[j] * scoretable[i][j]
    }
}
