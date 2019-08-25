using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grab : MonoBehaviour
{
    public bool b_holding = false;
    public a_pickupItem _item;
    private bool _locked;
    [SerializeField] Transform _holdspot;

    public LayerMask m_LayerMask;

    // possible place the item beside the player

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hitcolliders2d = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale * 2, 0.0f, m_LayerMask);

            int distance = 999;

            for (int i = 0; i < hitcolliders2d.Length; i++)
            {
                //so long as obj is contains a pickup item
                if (hitcolliders2d[i].GetComponent<a_pickupItem>())
                {
                    if (distance < Vector3.Magnitude(hitcolliders2d[i].gameObject.transform.position - gameObject.transform.position))
                    {
                        _item = hitcolliders2d[i].GetComponent<a_pickupItem>();
                    }
                }
            }

            if (_item != null)
            {
                Debug.Log("Yo");

                b_holding = true;
                _locked = true;
            }
        }

        // if (Input.GetKeyDown(KeyCode.E) && b_holding)
        // {
        //     Debug.Log("Yu");
        //     b_holding = false;
        // }

        if (b_holding)
        {
            _item.gameObject.transform.position = _holdspot.position;
        }
    }
}
