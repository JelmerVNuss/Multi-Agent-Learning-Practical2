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
        /// TODO STUDENT
        /// Returns the score table for all 11 strategies
        /// strategies consists of 11 strategy objects
        static public double[,] scoreTable(int nrrounds, int nrrestarts, Strategy[] strategies, double noise)
        {
            int numberOfStrategies = strategies.Length;
            double[,] scoreTable = new double[numberOfStrategies, numberOfStrategies];


            double totalPayoff = 0;
            // TODO for all strategy combinations
            for (int i = 0; i < nrrestarts; i++)
            {
                for (int j = 0; j < nrrounds; j++)
                {
                    ownAction = ;// strategy1 action + noise
                    if randomnumber < noise, choose random
                        else use strategy action
                    opponentsAction = ;// strategy2 action + noise

                    double payoff = getPayoff(ownAction, opponentsAction);

                    totalPayoff += payoff;
                }
            }
            // TODO add payoff to row/column scoretable, take average
            scoreTable[ownStrategy, opponentsStrategy] = totalPayoff/(nrrestarts * nrrounds);

            return scoreTable;
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
