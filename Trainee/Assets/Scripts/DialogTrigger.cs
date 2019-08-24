using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogScriptableObject dialogObject;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialogObject);
    }
}
