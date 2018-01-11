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

        /// TODO STUDENT
        /// Returns the proportions for the next time step
        /// proportions contains the proportions at current time
        /// scoreTable contains the score table created in the scoreTable method
        static public double[] replicator(double[] proportions, double[,] scoreTable, double birthrate)
        {
            return proportions;
        }
    }
}
