using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogScriptableObject[] dialogObject;
    bool activated = false;
    public bool bussy = false;
    public int index = 0;

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (activated && !bussy)
            {
                FindObjectOfType<DialogManager>().StartDialog(dialogObject[index]);
                bussy = true;
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialogObject[index]);
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

    public void IncrementIndex()
    {
        index += 1;
    }

}
