using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog")]
public class DialogScriptableObject : ScriptableObject
{
    [SerializeField] public string npcName;
    [TextArea(10, 14)] [SerializeField] public string textDialog;
    [SerializeField] public DialogScriptableObject[] nextSentences;


}
