using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class RoundDialogueUI : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Button nextButton;
    public Button closeButton;
    public float typingSpeed = 0.05f;

    private int currentRound = 0;
    private int currentLine = 0;
    private string[][] roundMessages =
    {
        new string[] {"시계탑을 고치러가야해", "우선 기차를 고쳐야겠어", "건물을 타고 다니면 부품이 보일텐데..." },
        new string[] {"이런! 기차 노선이 여기서 끊기다니!", "무너진 기차들이 잔뜩 있네... 사고라도 난 걸까?", "우선 부서진 기차 속에서 부품을 찾아야겠어" },
        new string[] {"드디어 시계탑에 도착했어!", "마지막으로 시계탑을 고칠 부품을 찾자", "부서진 잔해들이 있으니까 여기서 찾아야겠어" }
    };

    private Coroutine typingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(NextLine);
        closeButton.onClick.AddListener(CloseDialogue);
        StartRound();
    }

    public void StartRound()
    {
        if (currentRound >= roundMessages.Length)
        {
            Debug.Log("모든 라운드 종료!");
            return;
        }

        dialoguePanel.SetActive(true);
        currentLine = 0;
        ShowLine();
        Time.timeScale = 0;

    }

    public void ShowLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = "";
        closeButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);

        typingCoroutine = StartCoroutine(TypeLine(roundMessages[currentRound][currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    void NextLine()
    {
        currentLine++;
        if (currentLine < roundMessages[currentRound].Length)
        {
            ShowLine();
        }
        else
        {
            nextButton.gameObject.SetActive(false);
            closeButton.gameObject.SetActive(true); // 마지막 문장에서만 닫기 버튼 보이게
        }
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1; // 게임 재개
        currentRound++;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
