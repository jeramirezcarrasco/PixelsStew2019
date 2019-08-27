using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollContent : MonoBehaviour
{
    RectTransform currentTransform;
    float Target1 = 183f;  // setting rect transform's y component manually one for artist section and other for musician
    float Target2 = 351f;
    float newTarget;
    int phase = 1;          // phase variable to keep track of 
    bool coroutineCalled = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTransform = GetComponent<RectTransform>();
        Debug.Log(currentTransform.anchoredPosition.y);
        currentTransform.anchoredPosition = new Vector3(currentTransform.anchoredPosition.x, 0f);
        StartCoroutine(WaitForTwoSecs());
    }

    // Update is called once per frame
    void Update()
    {
        if(phase > 1 && phase < 4)
        {
            currentTransform.anchoredPosition = new Vector3(currentTransform.anchoredPosition.x, Mathf.Lerp(currentTransform.anchoredPosition.y, newTarget, Time.deltaTime));
            if(newTarget == Mathf.Ceil(currentTransform.anchoredPosition.y) && !coroutineCalled)
            {
                StartCoroutine(WaitForTwoSecs());
                coroutineCalled = true;
            }
        }
    }

    private IEnumerator WaitForTwoSecs()
    {
        yield return new WaitForSecondsRealtime(2f);
        switch(phase)
        {
            case 1:
                phase = 2;
                newTarget = Target1;
                coroutineCalled = false;
                break;
            case 2:
                phase = 3;
                newTarget = Target2;
                coroutineCalled = false;
                break;
            case 3:
                phase = 4;
                
                break;
        }
    }
}
