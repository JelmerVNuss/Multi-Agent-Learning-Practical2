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
            return new double[11, 11];
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
