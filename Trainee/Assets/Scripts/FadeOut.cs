using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] float fadeTimer;

    // Start is called before the first frame update
    void Start()
    {
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

    }

    IEnumerator FadeOUT()
    {
        for (float f = 1f; f >= -0.05; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(fadeTimer);
        }

    }

    public void StartFadeing()
    {
        StartCoroutine("FadeOUT");
    }
}
