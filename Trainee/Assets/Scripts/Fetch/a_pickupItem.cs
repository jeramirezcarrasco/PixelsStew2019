using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a_pickupItem : MonoBehaviour
{

    public string ID = "Sample";

    private Grab ref_owner;

    void Awake()
    {
        if (ID == "Sample")
        {
            Debug.Log("The component Item requires a valid string");
            gameObject.SetActive(false);
        }
    }

}