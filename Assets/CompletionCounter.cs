using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CompletionCounter : ScoreCounter
{
    public int maxScore;

    public UnityEvent onCompletion;

    internal override void Start()
    {
        base.Start();
    }

    public override void IncrementScore(int amount = 1)
    {
        base.IncrementScore(amount);
        if (Score >= maxScore)
        {
            onCompletion.Invoke();
        }
    }

    public override string FormatScore()
    {
        scoreText.color = Color32.Lerp(Color.red, Color.green, Score / maxScore);
        return string.Format("{0}/{1}", Score, maxScore);
    }
}
