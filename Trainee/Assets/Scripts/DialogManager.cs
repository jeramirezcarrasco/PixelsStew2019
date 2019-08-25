using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogManager : MonoBehaviour
{

    public Text nameNpc;
    public Text sentenceBox;
    private DialogScriptableObject Dialog;
    private FadeIn fadeIn;
    private FadeOut fadeOut;
    public GameObject DialogButton;

    void Start()
    {
        fadeIn = gameObject.GetComponent<FadeIn>();
        fadeOut = gameObject.GetComponent<FadeOut>();
    }

    public void StartDialog(DialogScriptableObject dialogScriptableObject)
    {
        StopAllCoroutines();
        DialogButton.SetActive(true);
        Dialog = dialogScriptableObject;
        fadeIn.StartFadeing();
        nameNpc.text = Dialog.npcName;
        StartCoroutine(TypeSentence(Dialog.textDialog));
    }

    public void DisplayNextSentence()
    {
        if (Dialog.nextSentences.Length < 1)
        {
            EndDialod();
            return;
        }
        else
        {
            Dialog = Dialog.nextSentences[0];
            StopAllCoroutines();
            nameNpc.text = Dialog.npcName;
            StartCoroutine(TypeSentence(Dialog.textDialog));
        }
    }

    IEnumerator TypeSentence(string Sentence)
    {
        Debug.Log(Sentence);
        yield return new WaitForSeconds(0.1f);
        sentenceBox.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            sentenceBox.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void EndDialod()
    {
        sentenceBox.text = "";
        nameNpc.text = "";
        fadeOut.StartFadeing();
        DialogButton.SetActive(false);
        EventManager.TriggerEvent(Dialog.EventTrigger);
        StopAllCoroutines();


    }


}
