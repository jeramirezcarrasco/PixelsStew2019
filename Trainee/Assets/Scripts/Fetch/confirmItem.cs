using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class confirmItem : MonoBehaviour
{

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>

    // [SerializeField] GameObject requiredGameObj;

    [SerializeField] string _ItemID;

    public bool Solved = false;

    void Awake()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<a_pickupItem>())
        {
            if (other.gameObject.GetComponent<a_pickupItem>().ID == _ItemID)
            {
                Solved = true;
                //display text and destroy obj
                Destroy(other.gameObject);
                //Correct item!
            }

            else
            {
                //Text, I told you to bring me a _itemID! not other.gameObject.GetComponent<a_pickupItem>().ID
                //play wrong sound
            }

        }
    }

}
