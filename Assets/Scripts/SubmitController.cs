using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitController : MonoBehaviour 
{
    public GameObject submitButtonUI;                  //버튼 Ui
    private GameManager gameManager;

    //자동 제출로 바꿔야겠담 오브젝트에 닿았을 때 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();               //게임 매니저 찾기

        if (submitButtonUI != null) submitButtonUI.SetActive(false);           //버튼 비활성화
    }

    void OnTriggerEnter(Collider other)   // 플레이어가 제출 구역에 들어왔을 때
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.SubmitItem();   // 자동 제출 (포탈 열림 여부는 GameManager가 판단)
            }
        }
    }

    //  void OnTriggerExit(Collider other)                       //플레이어가 제출 구역을 벗어났을 때 비활성화
    //  {
    //     if (other.CompareTag("Player"))
    //    {
    //        if (submitButtonUI != null) submitButtonUI.SetActive(false);
    //   }
    //  }

    //  public void OnClickSumbit()
    //  {
    //     if (gameManager != null)
    //    {
    //        gameManager.SubmitItem();
    //    }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
