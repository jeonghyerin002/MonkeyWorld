using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("아이템 정보")]
    public ItemSO[] itemData;             //public int itemCount = 0; 이전 코드 > 데이터를 사용했는데 매니저에 또 숫자로 적용할 필요 X
    public int collectionItem = 0;     //수집해야하는 아이템 수

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

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectItem(int itemIndex)
    {
        // 아이템 인덱스가 유효한지 확인   배웠던 코드
        if (itemIndex < 0 || itemIndex >= collectItems.Length) return;

        collectionItem++;    //수집한 아이템 수 증가

        UpdateUI();  //UI 업데이트
    }


    void UpdateUI()
    {
        //ItemText.text = "";          // 아이템 개수 UI 초기화
       // for (int  i = 0;  i < itemData.Length;  i++)
       // {
           // ItemText.text = $"{itemData[i].itemName} : {}"
       // }
    }
}
