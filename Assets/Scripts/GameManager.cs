using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("������ ����")]
    public ItemSO[] itemData;             //public int itemCount = 0; ���� �ڵ� > �����͸� ����ߴµ� �Ŵ����� �� ���ڷ� ������ �ʿ� X
    public int collectionItem = 0;     //�����ؾ��ϴ� ������ ��

    [Header("UI")]
    public Text ItemText;        //������ ���� UI

    [Header("��Ż")]
    public GameObject Portal;         //���� ����� �Ѿ�� ��Ż     �������� ���� �� Ư�� ������Ʈ�� �����ϸ� ��Ż�� Ȱ��ȭ


    private int[] collectItems;         //�� ������ ������ ��



    // Start is called before the first frame update
    void Start()
    {
        // ������ ���� �迭 �ʱ�ȭ
        collectItems = new int[itemData.Length];

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectItem(int itemIndex)
    {
        // ������ �ε����� ��ȿ���� Ȯ��   ����� �ڵ�
        if (itemIndex < 0 || itemIndex >= collectItems.Length) return;

        collectionItem++;    //������ ������ �� ����

        UpdateUI();  //UI ������Ʈ
    }


    void UpdateUI()
    {
        //ItemText.text = "";          // ������ ���� UI �ʱ�ȭ
       // for (int  i = 0;  i < itemData.Length;  i++)
       // {
           // ItemText.text = $"{itemData[i].itemName} : {}"
       // }
    }
}
