using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CompletionCounter : ScoreCounter
{
    public int maxScore;

    public UnityEvent onCompletion;

    public Color32 green;
    public Color32 yellow;
    public Color32 red;

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
        float lerpValue = (float) Score / (float) maxScore;
        if (lerpValue <= 0.5f)
        {
            scoreText.color = Color32.Lerp(red, yellow, lerpValue / 0.5f);
            Debug.Log(lerpValue);
        }
        else
        {
            scoreText.color = Color32.Lerp(yellow, green, (lerpValue - 0.5f) / 0.5f);
            Debug.Log(lerpValue);

        }
        return string.Format("{0}/{1}", Score, maxScore);
    }
}
