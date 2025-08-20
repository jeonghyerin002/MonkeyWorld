using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitController : MonoBehaviour 
{
    public GameObject submitButtonUI;                  //��ư Ui
    private GameManager gameManager;

    //�ڵ� ����� �ٲ�߰ڴ� ������Ʈ�� ����� �� 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();               //���� �Ŵ��� ã��

        if (submitButtonUI != null) submitButtonUI.SetActive(false);           //��ư ��Ȱ��ȭ
    }

    void OnTriggerEnter(Collider other)                  //�÷��̾ ���� ������ ������ �� Ȱ��ȭ
    {
        if (other.CompareTag("Player"))
        {
            if (submitButtonUI != null) submitButtonUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)                       //�÷��̾ ���� ������ ����� �� ��Ȱ��ȭ
    {
        if (other.CompareTag("Player"))
        {
            if (submitButtonUI != null) submitButtonUI.SetActive(false);
        }
    }

    public void OnClickSumbit()
    {
        if (gameManager != null)
        {
            gameManager.SubmitItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
