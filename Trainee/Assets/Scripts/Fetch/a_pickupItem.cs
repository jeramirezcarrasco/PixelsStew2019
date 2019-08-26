using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class a_pickupItem : MonoBehaviour
{

    public string ID = "Sample";
    public Rigidbody2D body;

    void Awake()
    {
        if (ID == "Sample")
        {
            Debug.Log("The component Item requires a valid string");
            gameObject.SetActive(false);
        }

        body = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnDestroy()
    {
        if (transform.parent != null)
        {
            if (transform.parent.GetComponent<Grab>())
            {
                transform.parent.GetComponent<Grab>().DropItem();
            }
        }
    }
}