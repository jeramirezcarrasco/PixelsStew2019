using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsFlags : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameComponents[] gameComponents;
    public Dictionary<string, GameObject> gameComponentDictionary;
    private void Start()
    {
        Debug.Log("STARTT");
        gameComponentDictionary = new Dictionary<string, GameObject>();
        for (int i = 0; i < gameComponents.Length; i++)
        {
            gameComponentDictionary.Add(gameComponents[i].componentName, gameComponents[i].componentObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        EventManager.StartListening("Tutorial1", Tutorial1);
        EventManager.StartListening("Tutorial2", Tutorial2);
        EventManager.StartListening("Tutorial3", Tutorial3);
        EventManager.StartListening("Sheep1", Sheep1);

    }

    private void OnDisable()
    {

        EventManager.StopListening("Tutorial1", Tutorial1);
        EventManager.StopListening("Tutorial2", Tutorial2);
        EventManager.StopListening("Tutorial3", Tutorial3);
        EventManager.StopListening("Sheep1", Sheep1);


    }

    void Tutorial1()
    {
        Debug.Log("Tutorial1");
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("BranchManeger", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            thisObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void Tutorial2()
    {
        Debug.Log("Tutorial2");
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("BranchManeger", out thisObject))
        {
            thisObject.transform.GetChild(1).gameObject.SetActive(true);
            thisObject.GetComponent<DialogTrigger>().TriggerDialogue();
        }
    }

    void Tutorial3()
    {
        Debug.Log("Tutorial3");
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("BranchManeger", out thisObject))
        {
            thisObject.transform.GetChild(4).gameObject.SetActive(false);
            player.transform.GetChild(0).gameObject.SetActive(true);
            thisObject.GetComponent<FadeOut>().StartFadeing();
            thisObject.transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    void Sheep1()
    {
        GameObject thisObject = null;
        Debug.Log("Sheep1");

        if (gameComponentDictionary.TryGetValue("Sheep", out thisObject))
        {

            thisObject.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log(thisObject.name);
            Debug.Log(thisObject.transform.GetChild(0).gameObject.name);
            player.GetComponent<PlayerBehavior>().enabled = false;
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
        }
    }



    IEnumerator WaitForBussy(GameObject thisObject)
    {
        yield return new WaitForSeconds(2f);
        thisObject.GetComponent<DialogTrigger>().bussy = false;
    }
}

[System.Serializable]
public class GameComponents
{
    public string componentName;
    public GameObject componentObject;
}
