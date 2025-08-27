using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRoundManager : MonoBehaviour
{
    [Header("라운드별 대사 SO (인덱스 = 라운드 번호)")]
    public DialogueSO[] roundDialogues;

    [Header("참조")]
    public DialogueManager dialogueManager;

    [Header("자동 시작")]
    public bool autoStartOnScene = true;    // 씬 시작 시 자동으로 현재 라운드 대사 보여주기

    void Start()
    {
        if (autoStartOnScene)
        {
            ShowCurrentRound();
        }
    }

  
    public void ShowCurrentRound()
    {
        int round = 0;
        if (GameManager.Instance != null)
            round = GameManager.Instance.currentRound;

        //ShowRoundDialogue(round);
    }

    //public void ShowRoundDialogue(int roundIndex)
    //{
    //    if (dialogueManager == null)
    //    {
    //        Debug.LogWarning("DialogueManager 참조가 없음");
    //        return;
    //    }

    //    if (roundDialogues == null || roundDialogues.Length == 0)
    //    {
    //        Debug.LogWarning("roundDialogues가 비어있음");
    //        return;
    //    }

    //    if (roundIndex < 0 || roundIndex >= roundDialogues.Length)
    //    {
    //        Debug.LogWarning($"roundDialogues 범위를 벗어남: {roundIndex}");
    //        return;
    //    }

    //    dialogueManager.StartDialogue(roundDialogues[roundIndex]);
    //}
}
