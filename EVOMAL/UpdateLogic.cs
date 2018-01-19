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

       
        static public int getPayoff(int myAction, int yourAction)
        {
            // get the payoff corresponding to myAction and yourAction
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
            double scoreTableAverage = calculateScoreTableAverage(scoreTable, proportions);
            int amountOfRows = scoreTable.GetLength(0);
            int amountOfColumns = scoreTable.GetLength(1);

            double[] newProportions = new double[proportions.Length];

            for (int strategyIndex = 0; strategyIndex < amountOfRows; strategyIndex++)
            {
                double proportionStrategy = proportions[strategyIndex];
                double[] scoreTableRow = getRow(scoreTable, strategyIndex);
                double scoreTableStrategy = vectorMultiplication(scoreTableRow, proportions);
                newProportions[strategyIndex] = (proportionStrategy * (1 + birthrate * scoreTableStrategy)) / (1 + birthrate * scoreTableAverage);
            }
            return newProportions;
        }

        static private double calculateScoreTableAverage(double[,] scoreTable, double[] proportions)
        {
            // Calculate the average fitness of the whole population. 
            int amountOfRows = scoreTable.GetLength(0);
            int amountOfColumns = scoreTable.GetLength(1);

            // First calculate the average fitness per row
            double[] averageRow = new double[amountOfRows];
            for (int i = 0; i < amountOfRows; i++)
            {
                double[] scoreTableRow = getRow(scoreTable, i);
                averageRow[i] = vectorMultiplication(scoreTableRow, proportions);
            }

            // Now calculate the average over the averages of the rows.
            double average = vectorMultiplication(proportions, averageRow);
            return average;
        }

        static private double[] getRow(double[,] scoreTable, int row)
        {
            // get one row of a matrix
            int amountOfColumns = scoreTable.GetLength(1);
            double[] scoreTableRow = new double[amountOfColumns];

            for (int col = 0; col < amountOfColumns; col++)
            {
                scoreTableRow[col] = scoreTable[row, col];
            }
            return scoreTableRow;
        }

        // function for vector multiplication proportions with row of score table
        static private double vectorMultiplication(double[] scoreTableRow, double[] proportion)
        {
            double sum = 0;
            for (int j = 0; j < proportion.Count(); j++)
            {
                sum += proportion[j] * scoreTableRow[j];
            }
            return sum;
        }
    }
}
