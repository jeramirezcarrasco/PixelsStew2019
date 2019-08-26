﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] float fadeTimer;
    [SerializeField] bool StartFaded;
    [SerializeField] bool completeFadeIN;

    // Start is called before the first frame update
    void Start()
    {
        if (StartFaded)
        {
            Color c = rend.material.color;
            c.a = 0f;
            rend.material.color = c;
        }
        else
        {
            Color c = rend.material.color;
        }
    }

    IEnumerator FadeIN()
    {
        if (completeFadeIN)
        {
            for (float f = 0.05f; f <= 1.1; f += 0.05f)
            {
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                yield return new WaitForSeconds(fadeTimer);
            }
        }
        else
        {
            for (float f = 0.05f; f <= 1; f += 0.05f)
            {
                Color c = rend.material.color;
                c.a = f;
                rend.material.color = c;
                yield return new WaitForSeconds(fadeTimer);
            }
        }
        

    }

    public void StartFadeing()
    {
        StartCoroutine("FadeIN");
    }
}
