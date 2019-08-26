using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuggagePuzzle : MonoBehaviour
{
    public LuggageBag[] bags;
    public Text WinText;

    public void CheckIfBagsOnShelf()
    {
        bool allBagsAreOnShelf = true;

        foreach (LuggageBag bag in bags)
        {
            if (!bag.IsInShelf)
            {
                allBagsAreOnShelf = false;
                break;
            }
        }

        if (allBagsAreOnShelf)
        {
            WinText.enabled = true;
        }
    }
}
