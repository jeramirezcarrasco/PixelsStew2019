using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsFlags : MonoBehaviour
{
    

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
    }
    private void OnEnable()
    {
        EventManager.StartListening("Tutorial1", Tutorial1);
        EventManager.StartListening("Tutorial2", Tutorial2);
        EventManager.StartListening("Tutorial3", Tutorial3);

    }

    private void OnDisable()
    {
        Debug.Log("aaaaaaaaaaaaaaaa");

        EventManager.StopListening("Tutorial1", Tutorial1);
        EventManager.StopListening("Tutorial2", Tutorial2);
        EventManager.StopListening("Tutorial3", Tutorial3);


    }

    void Tutorial1()
    {
        Debug.Log("Tutorial1");
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Tutorial1", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            thisObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void Tutorial2()
    {
        Debug.Log("INCREMNETAL");
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_1", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            StartCoroutine("WaitForBussy", thisObject);
        }
    }

    void Tutorial3()
    {
        Debug.Log("INCREMNETAL");
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_1", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            StartCoroutine("WaitForBussy", thisObject);
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
