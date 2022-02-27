using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    internal TextMeshPro scoreText;

    internal virtual void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        UpdateScoreText();
    }

    public int Score { get; internal set; }

    private int _highScore = 0;

    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            if (value > _highScore)
            {

                _highScore = value;
            }
        }
    }


    public virtual void IncrementScore(int amount = 1)
    {
        Score += amount;
        HighScore = Score;
        UpdateScoreText();
    }

    public virtual void Reset()
    {
        Score = 0;
        UpdateScoreText();
    }

    public virtual void UpdateScoreText()
    {
        scoreText.text = FormatScore();
    }

    public virtual string FormatScore()
    {
        return Score.ToString();
    }
}
