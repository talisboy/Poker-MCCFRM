﻿using System;

namespace Poker_MCCFRM
{
    [Serializable]
    public class Infoset
    {
        public float[] regret;
        public float[] actionCounter;

        public Infoset()
        {
        }
        public Infoset(int actions)
        {
            if (actions != 0)
            {
                // chance node
                regret = new float[actions];
                actionCounter = new float[actions];
            }
        }
        public float[] CalculateStrategy()
        {
            float sum = 0;
            float[] moveProbs = new float[regret.Length];
            for (int a = 0; a < regret.Length; ++a)
            {
                sum += Math.Max(0, regret[a]);
            }
            for (int a = 0; a < regret.Length; ++a)
            {
                if (sum > 0)
                {
                    moveProbs[a] = Math.Max(0, regret[a]) / sum;
                }
                else
                {
                    moveProbs[a] = 1.0f / regret.Length;
                }
            }
            return moveProbs;
        }
        public float[] GetFinalStrategy()
        {
            float sum = 0;
            float[] moveProbs = new float[regret.Length];
            for (int a = 0; a < regret.Length; ++a)
            {
                sum += actionCounter[a];
            }
            for (int a = 0; a < regret.Length; ++a)
            {
                if (sum > 0)
                {
                    moveProbs[a] = actionCounter[a] / sum;
                }
                else
                {
                    moveProbs[a] = 1.0f / regret.Length;
                }
            }
            return moveProbs;
        }
    }
}
