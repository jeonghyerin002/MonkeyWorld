using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [Header("UI")]
    public GameObject dialogueUI;
    public Text dialogueText;

    [Header("SO ¿¬°á")]
    public DialogueSO dialogueData;

    private int currentIndex = 0;
    private bool isDialogueActive = false;


    private void Start()
    {
        if (dialogueData != null)
            StartDialogue(dialogueData);
    }

    public void StartDialogue(DialogueSO data)
    {
        if (data == null || data.dialogues.Count == 0) return;

        dialogueData = data;
        currentIndex = 0;
        isDialogueActive = true;
        dialogueUI.SetActive(true);

        ShowDialogue();
    }

    private void Update()
    {
        if (!isDialogueActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex < dialogueData.dialogues.Count - 1)
            {
                currentIndex++;
                ShowDialogue();
            }
            else
            {
                EndDialogue();
            }
        }

    }

    void ShowDialogue()
    {
        dialogueText.text = dialogueData.dialogues[currentIndex];
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUI.SetActive(false);

      //  FindObjectOfType<GameManager>().OnDialogueEnd();
    }

}
