using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // 싱글톤

    [Header("아이템 정보")]
    public ItemSO[] itemData;             //public int itemCount = 0; 이전 코드 > 데이터를 사용했는데 매니저에 또 숫자로 적용할 필요 X
    public int[] targetItemCounts;       //수집해야하는 아이템 수                   //public int targetItemCount = 0 < 이거도 숫자로 적용함.
    private int screw;          //나사
    private int spring;         //스프링
    private int cogwheel;        //톱니바퀴

    [Header("라운드")]
    public int currentRound = 1;                //현재 라운드 번호

    [Header("UI")]
    public Text ItemText;        //아이템 개수 UI

    [Header("포탈")]
    public GameObject Portal;         //다음 라운드로 넘어가는 포탈     아이템을 수집 후 특정 오브젝트에 제출하면 포탈이 활성화

  

   

    private int[] collectItems;         //총 수집한 아이템 수 
    
    
    public int round = 1;



    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        //StartRound();

       

        // 아이템 개수 배열 초기화
        collectItems = new int[itemData.Length];

        
        collectItems = new int[itemData.Length];
        // 포탈은 항상 켜둬도 됨 → 이동은 조건 체크로만


        round++;

        UpdateUI();
    }

   


    public void NextRound()
    {
        currentRound++;
        
      
    }

    int GetTargetCount(int itemIndex)                       //아이템별목표 수량 가져오기
    {
        if (currentRound < itemData[itemIndex].roundTargetCounts.Length)
        {
            return itemData[itemIndex].roundTargetCounts[currentRound];
        }
        return 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectItem(int itemIndex)
    {
        // 아이템 인덱스가 유효한지 확인   배웠던 코드
        if (itemIndex < 0 || itemIndex >= collectItems.Length) return;

        collectItems[itemIndex]++;              //수집한 아이템 수 증가
        //collectionItem++; 이전 코드 <단일로만 카운트 하고 있음 별도로 저장해야해서 Index넣어야 함.

        UpdateUI();  //UI 업데이트
    }

    public bool CanGoNextRound()   // 포탈 통과 가능 여부 체크
    {
        for (int i = 0; i < itemData.Length; i++)
        {
            if (collectItems[i] < GetTargetCount(i))
            {
                return false; // 목표 미달 → 이동 불가
            }
        }
        return true; // 모든 아이템 목표 충족
    }

    void UpdateUI()
    {
        ItemText.text = ""; // 초기화

        for (int i = 0; i < itemData.Length; i++)
        {
            ItemText.text += $"{itemData[i].itemName} : {collectItems[i]} / {GetTargetCount(i)}\n";
        }

    }

    public void GoToNextround(string sceneName)
    {
        currentRound++;      //라운드 증가
        ResetItems();        //아이템 초기화
       // SceneManager.LoadScene(sceneName);
    }

    public void ResetItems()               //다음 씬 이동후
    {
        // 수집 아이템 초기화
        for (int i = 0; i < collectItems.Length; i++)
        {
            collectItems[i] = 0;
        }

        //포탈 비활성화
        if (Portal != null) Portal.SetActive(false);

        //UI 업데이트
        UpdateUI();
    }
}
