using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EatPacdot : MonoBehaviour
{
    public event Action<int> EatDot;
    private EatPacdot eatPacdot;
    private Score score;

    public AudioSource audio;
    public AudioSource audio2;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        eatPacdot = new EatPacdot();
        eatPacdot.EatDot += score.Eat;
        //eatPacdot.Invoke("eatPacdot", 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("pacdot"))
        {
            Destroy(collision.gameObject);
            // event invoking for add score points;
            eatPacdot.EatDot?.Invoke(10);
            if (audio.isPlaying)
            {

            }
            else
            {
                audio.Play();
            }

        }
        else if (collision.gameObject.CompareTag("energizer"))
        {
            Destroy(collision.gameObject);
            // event invoking for add score points and superpower
            eatPacdot.EatDot?.Invoke(10);
            if (audio2.isPlaying)
            {

            }
            else
            {
                audio2.Play();
            }
        }
    }

}
