using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashing : MonoBehaviour
{
    public float Time;
    public Color TransparentColor;
    public Color Color;

    private bool isTransparent = false;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        Color = text.color;
        StartCoroutine(FlashObject(Time));
    }

    IEnumerator FlashObject(float Time)
    {
        yield return new WaitForSeconds(Time);

        if (isTransparent)
        {
            text.color = Color;
        }
        else
        {
            text.color = TransparentColor;
        }

        isTransparent = !isTransparent;
        StartCoroutine(FlashObject(Time));
    }
}
