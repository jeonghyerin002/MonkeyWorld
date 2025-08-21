using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("������ ����")]
    public ItemSO[] itemData;             //public int itemCount = 0; ���� �ڵ� > �����͸� ����ߴµ� �Ŵ����� �� ���ڷ� ������ �ʿ� X
    public int[] targetItemCounts;       //�����ؾ��ϴ� ������ ��                   //public int targetItemCount = 0 < �̰ŵ� ���ڷ� ������.
    private int screw;          //����
    private int spring;         //������
    private int cogwheel;        //��Ϲ���

    [Header("����")]
    public int currentRound = 0;                //���� ���� ��ȣ

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

        //��ž ��Ȱ��ȭ
        if (Portal != null) Portal.SetActive(false);

        UpdateUI();
    }

    int GetTargetCount(int itemIndex)                       //�����ۺ���ǥ ���� ��������
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
        // ������ �ε����� ��ȿ���� Ȯ��   ����� �ڵ�
        if (itemIndex < 0 || itemIndex >= collectItems.Length) return;

        collectItems[itemIndex]++;              //������ ������ �� ����
        //collectionItem++; ���� �ڵ� <���Ϸθ� ī��Ʈ �ϰ� ���� ������ �����ؾ��ؼ� Index�־�� ��.

        UpdateUI();  //UI ������Ʈ
    }

    public void SubmitItem()                //������ ���� ��� ��� ����� ��Ż ����
    {

        // �������� ��ǥ ���� �̻����� üũ
        for (int i = 0;  i < itemData.Length; i++)
        {
            if (collectItems[i] < GetTargetCount(i))
            {
                return;
            }
        }

        //���� ������ ��Ż Ȱ��ȭ
        for (int i = 0; i < itemData.Length; i++)
        {
            collectItems[i] -= GetTargetCount(i);
        }

        if (Portal != null) Portal.SetActive(true);

        UpdateUI();
    }

    void UpdateUI()
    {
        ItemText.text = ""; // �ʱ�ȭ

        for (int i = 0; i < itemData.Length; i++)
        {
            ItemText.text += $"{itemData[i].itemName} : {collectItems[i]} / {GetTargetCount(i)}\n";
        }

    }

    public void GoToNextround(string sceneName)
    {
        currentRound++;      //���� ����
        ResetItems();        //������ �ʱ�ȭ
        SceneManager.LoadScene(sceneName);
    }

    public void ResetItems()               //���� �� �̵���
    {
        // ���� ������ �ʱ�ȭ
        for (int i = 0; i < collectItems.Length; i++)
        {
            collectItems[i] = 0;
        }

        //��Ż ��Ȱ��ȭ
        if (Portal != null) Portal.SetActive(false);

        //UI ������Ʈ
        UpdateUI();
    }
}
