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
            Debug.Log("aaaaaaaaaa");
            Dialog = Dialog.nextSentences[0];
            Debug.Log(Dialog.textDialog);
            StopAllCoroutines();
            nameNpc.text = Dialog.npcName;
            StartCoroutine(TypeSentence(Dialog.textDialog));
        }
    }

    IEnumerator TypeSentence(string Sentence)
    {
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
        Debug.Log("End");
        fadeOut.StartFadeing();
        DialogButton.SetActive(false);

    }

    
}
