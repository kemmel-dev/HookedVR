using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCounter : ScoreCounter
{

    public override string FormatScore()
    {
        return string.Format("Throws: {0}\nLeast throws: {1}", Score, HighScore);
    }

    public override void IncrementScore(int amount = 1)
    {
        Score += amount;
        UpdateScoreText();
    }

    internal void UpdateHighScore()
    {
        HighScore = Score;
        UpdateScoreText();
    }
}
