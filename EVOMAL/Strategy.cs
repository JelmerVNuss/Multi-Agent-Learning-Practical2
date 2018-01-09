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
            return 0;
        }
    }

    class Randomly : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class TFT : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class TFT2 : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class Pavlov : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
        }
    }

    class Unforgiving : Strategy
    {
        public int getAction(List<int> myhistory, List<int> yourhistory)
        {
            return 0;
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
            return 0;
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