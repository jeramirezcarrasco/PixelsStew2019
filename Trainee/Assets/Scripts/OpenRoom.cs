using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoom : MonoBehaviour
{

    [SerializeField] GameObject Walls;
    private FadeIn fadeIn;
    private FadeOut fadeOut;
    private bool activated = false;
    private bool cooldown = false;

    private void Start()
    {
        fadeIn = gameObject.GetComponent<FadeIn>();
        fadeOut = gameObject.GetComponent<FadeOut>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (activated && !cooldown)
            {
                if (Walls.activeSelf)
                {
                    Walls.SetActive(false);
                    fadeIn.StartFadeing();
                    cooldown = true;
                    StartCoroutine("Cooldown");
                }
                else
                {
                    Walls.SetActive(true);
                    fadeOut.StartFadeing();
                    cooldown = true;
                    StartCoroutine("Cooldown");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activated = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activated = false;
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
        cooldown = false;

    }
}
