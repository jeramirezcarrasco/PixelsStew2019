using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    [SerializeField]
    private GameObject first, last;
    [Header("Solved Color")]
    public Color col;

    // Start is called before the first frame update
    void Start()
    {
        first = null;
        last = null;
    }

    // Update is called once per frame
    void Update()
    {
        RayCaster();
    }

   

    void RayCaster()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if(first==null)
                {
                    first = hit.collider.gameObject;
                    // Change First Tile color

                    hit.collider.gameObject.GetComponent<IconIdentity>().ChangeColor();
                }
                else
                {
                    last = hit.collider.gameObject;

                    hit.collider.gameObject.GetComponent<IconIdentity>().ChangeColor();
                    // Call for Solve Check

                    //CheckResult(first,last);
                    StartCoroutine(CallForCheck(first, last));
                    first = null;
                    last = null;
                }
            }
        }
    }

    void CheckResult(GameObject g1,GameObject g2)
    {
        if(g1.GetComponent<IconIdentity>().id==g2.GetComponent<IconIdentity>().id)
        {
            g1.GetComponent<BoxCollider2D>().enabled = false;
            g2.GetComponent<BoxCollider2D>().enabled = false;

            g1.GetComponent<SpriteRenderer>().color = col;
            g2.GetComponent<SpriteRenderer>().color = col;
        }
        else
        {
            g1.GetComponent<IconIdentity>().ResetColor();
            g2.GetComponent<IconIdentity>().ResetColor();
        }
    }

    IEnumerator CallForCheck(GameObject g1,GameObject g2)
    {
        yield return new WaitForSeconds(1);
        if(g1.GetComponent<IconIdentity>().id==g2.GetComponent<IconIdentity>().id)
        {
            g1.GetComponent<BoxCollider2D>().enabled = false;
            g2.GetComponent<BoxCollider2D>().enabled = false;

            g1.GetComponent<SpriteRenderer>().color = col;
            g2.GetComponent<SpriteRenderer>().color = col;
        }
        else
        {
            g1.GetComponent<IconIdentity>().ResetColor();
            g2.GetComponent<IconIdentity>().ResetColor();
        }
        yield return null;
    }

}
