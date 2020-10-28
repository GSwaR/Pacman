using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void Eat(int _score)
    {

        score += _score;
        text.text = score.ToString();
    }


}
