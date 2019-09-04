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
    private FadeInUI fadeInUI;
    private FadeOutUI fadeOutUI;
    private CameraZoom cameraZoom;
    public GameObject DialogButton;
    bool nextSentenceActive = false;
    bool firstZoom = true;
    bool writing = false;
    [SerializeField] GameObject Player;

    void Start()
    {
        fadeInUI = gameObject.GetComponent<FadeInUI>();
        fadeOutUI = gameObject.GetComponent<FadeOutUI>();
        cameraZoom = gameObject.GetComponent<CameraZoom>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && nextSentenceActive)
        {
            if (writing)
                writing = false;
            else
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
        fadeInUI.StartFadeingUI();
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
        writing = true;
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
            if (writing = false)
            {
                sentenceBox.text = Sentence;
                break;
            }
            sentenceBox.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        writing = false;
    }

    private void EndDialod()
    {
        sentenceBox.text = "";
        nameNpc.text = "";
        fadeOutUI.StartFadeingUI();
        nextSentenceActive = false;
        DialogButton.SetActive(nextSentenceActive);
        Player.GetComponent<PlayerBehavior>().enabled = true;
        EventManager.TriggerEvent(Dialog.EventTrigger);
        StopAllCoroutines();
        cameraZoom.StartOriginalZoom();
        firstZoom = true;

    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(1);
    }


}
