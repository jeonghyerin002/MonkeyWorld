using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogueData", menuName = "Game/DialogueData")]
                    
public class DialogueSO : ScriptableObject
{
    [TextArea(2, 5)]
    public string[] sentences;
}
