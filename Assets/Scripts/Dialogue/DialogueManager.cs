using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    //[Header("UI")]
    //public GameObject dialogueUI;   // 대사 패널 (Canvas 안 Panel)
    //public Text dialogueText;       // 대사 텍스트 (UI Text/TMP_Text 가능, Text면 그대로)

    //private DialogueSO currentData;
    //private int index = 0;
    //private bool isActive = false;

    //void Start()
    //{
    //    if (dialogueUI != null) dialogueUI.SetActive(false);
    //}

    //// 라운드 시작 시 호출
   

    //void Update()
    //{
    //    if (!isActive) return;

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Next();
    //    }
    //}

    //public void StartDialogue(DialogueSO data)
    //{
    //    if (data == null || data.sentences == null || data.sentences.Length == 0)
    //    {
    //        Debug.LogWarning("DialogueSO가 비어있음");
    //        return;
    //    }

    //    currentData = data;
    //    index = 0;
    //    isActive = true;

    //    dialogueUI.SetActive(true);
    //    dialogueText.text = currentData.sentences[index];
    //}

    //private void Next()
    //{
    //    index++;

    //    if (currentData != null && index < currentData.sentences.Length)
    //    {
    //        dialogueText.text = currentData.sentences[index];
    //    }
    //    else
    //    {
    //        EndDialogue();
    //    }
    //}

    //private void EndDialogue()
    //{
    //    isActive = false;
    //    if (dialogueUI != null) dialogueUI.SetActive(false);
    //}

}
