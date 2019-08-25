using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsFlags : MonoBehaviour
{
    

    [SerializeField] GameComponents[] gameComponents;
    public Dictionary<string, GameObject> gameComponentDictionary;
    private void Start()
    {
        gameComponentDictionary = new Dictionary<string, GameObject>();
        for (int i = 0; i < gameComponents.Length; i++)
        {
            gameComponentDictionary.Add(gameComponents[i].componentName, gameComponents[i].componentObject);
        }
    }
    private void OnEnable()
    {
        EventManager.StartListening("Milk1_1", Milk1_1);
        EventManager.StartListening("Milk1_2", Milk1_2);
        EventManager.StartListening("Milk1_3", Milk1_3);
        EventManager.StartListening("Milk1_4", Milk1_4);
        EventManager.StartListening("Milk1_5", Milk1_5);

    }

    private void OnDisable()
    {
        EventManager.StopListening("Milk1_1", Milk1_1);
        EventManager.StopListening("Milk1_2", Milk1_2);
        EventManager.StopListening("Milk1_3", Milk1_3);
        EventManager.StopListening("Milk1_4", Milk1_4);
        EventManager.StopListening("Milk1_5", Milk1_5);
    }

    void Milk1_1()
    {
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_1", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            StartCoroutine("WaitForBussy", thisObject);
        }
    }

    void Milk1_2()
    {
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_2", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            StartCoroutine("WaitForBussy", thisObject);
        }
    }

    void Milk1_3()
    {
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_3", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            StartCoroutine("WaitForBussy", thisObject);
        }
    }

    void Milk1_4()
    {
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_4", out thisObject))
        {
            thisObject.GetComponent<DialogTrigger>().IncrementIndex();
            StartCoroutine("WaitForBussy", thisObject);
        }
    }

    void Milk1_5()
    {
        GameObject thisObject = null;
        if (gameComponentDictionary.TryGetValue("Milk1_5", out thisObject))
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
