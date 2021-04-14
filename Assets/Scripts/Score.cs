﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    private int score = 0;
    private Text text;
    private int scorePoint = 10000;

    public event Action OnScore;
    private Score scoreObject;
    private Life lifeObject;

    private void Start()
    {
        lifeObject = FindObjectOfType<Life>();
        text = GetComponent<Text>();

        scoreObject = FindObjectOfType<Score>();
        scoreObject.OnScore += lifeObject.OnScorePoints;
    }

    public void Eat(int _score)
    {

        score += _score;
        text.text = score.ToString();

        if (score >= scorePoint)
        {
            // event -> add new life to pacman and make scorePoint greater
            scoreObject.OnScore?.Invoke();

            scorePoint *= 2;
        }
    }

}
