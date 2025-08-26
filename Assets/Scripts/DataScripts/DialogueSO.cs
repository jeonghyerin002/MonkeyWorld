using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogueData", menuName = "Game/DialogueData")]
                    
public class DialogueSO : ScriptableObject
{
    [TextArea]
    public List<string> dialogues = new List<string>();
}
