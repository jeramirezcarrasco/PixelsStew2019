using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    int index = 0;
    [SerializeField] Grab grab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Trash" && grab.b_holding == false)
        {
            index += 1;
            Destroy(collision.gameObject);
            if (index > 1)
            {
                EventManager.TriggerEvent("Tutorial2");
                gameObject.SetActive(false);
            }
        }
    }
}
