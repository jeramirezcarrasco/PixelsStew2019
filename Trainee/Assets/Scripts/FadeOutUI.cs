using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUI : MonoBehaviour
{
    [SerializeField] Image rend;
    [SerializeField] float fadeTimer;
    [SerializeField] bool StartFaded;

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

    public void StartFadeingUI()
    {
        StartCoroutine("FadeOUT");
    }
}
