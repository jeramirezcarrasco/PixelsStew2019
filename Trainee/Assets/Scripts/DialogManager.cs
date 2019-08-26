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
    private CameraZoom cameraZoom;
    public GameObject DialogButton;
    bool nextSentenceActive = false;
    bool firstZoom = true;
    [SerializeField] GameObject Player;

    void Start()
    {
        fadeIn = gameObject.GetComponent<FadeIn>();
        fadeOut = gameObject.GetComponent<FadeOut>();
        cameraZoom = gameObject.GetComponent<CameraZoom>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && nextSentenceActive)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialog(DialogScriptableObject dialogScriptableObject)
    {
        Player.GetComponent<PlayerBehavior>().enabled = false;
        StopAllCoroutines();
        nextSentenceActive = true;
        DialogButton.SetActive(nextSentenceActive);
        Dialog = dialogScriptableObject;
        fadeIn.StartFadeing();
        StartCoroutine(TypeSentence(Dialog.textDialog));
        cameraZoom.StartNewZoom();
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
        if (firstZoom)
        {
            yield return new WaitForSeconds(1.5f);
            firstZoom = false;
        }
        nameNpc.text = Dialog.npcName;
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
        nextSentenceActive = false;
        DialogButton.SetActive(nextSentenceActive);
        Debug.Log(Dialog.EventTrigger);
        EventManager.TriggerEvent(Dialog.EventTrigger);
        StopAllCoroutines();
        cameraZoom.StartOriginalZoom();
        firstZoom = true;
        Player.GetComponent<PlayerBehavior>().enabled = true;

    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1);
    }


}
