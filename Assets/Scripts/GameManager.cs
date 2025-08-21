using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("아이템 정보")]
    public ItemSO[] itemData;             //public int itemCount = 0; 이전 코드 > 데이터를 사용했는데 매니저에 또 숫자로 적용할 필요 X
    public int[] targetItemCounts;       //수집해야하는 아이템 수                   //public int targetItemCount = 0 < 이거도 숫자로 적용함.
    private int screw;          //나사
    private int spring;         //스프링
    private int cogwheel;        //톱니바퀴

    [Header("라운드")]
    public int currentRound = 0;                //현재 라운드 번호

    [Header("UI")]
    public Text ItemText;        //아이템 개수 UI

    [Header("포탈")]
    public GameObject Portal;         //다음 라운드로 넘어가는 포탈     아이템을 수집 후 특정 오브젝트에 제출하면 포탈이 활성화


    private int[] collectItems;         //총 수집한 아이템 수
    



    // Start is called before the first frame update
    void Start()
    {
        // 아이템 개수 배열 초기화
        collectItems = new int[itemData.Length];

        //포탑 비활성화
        if (Portal != null) Portal.SetActive(false);

        UpdateUI();
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

    public void SubmitItem()                //아이템 제출 기능 모두 제출시 포탈 생성
    {

        // 아이템이 목표 수량 이상인지 체크
        for (int i = 0;  i < itemData.Length; i++)
        {
            if (collectItems[i] < GetTargetCount(i))
            {
                return;
            }
        }

        //조건 충족시 포탈 활성화
        for (int i = 0; i < itemData.Length; i++)
        {
            collectItems[i] -= GetTargetCount(i);
        }

        if (Portal != null) Portal.SetActive(true);

        UpdateUI();
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
        SceneManager.LoadScene(sceneName);
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
