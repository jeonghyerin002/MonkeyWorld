using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCOntroller : MonoBehaviour
{
  public int itemIndex; // ������ �ε���

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))             // �÷��̾ �����ۿ� ����� ��
        {
            GameManager.Instance.CollectItem(itemIndex);
            Destroy(gameObject);  // ���� ������ ����
        }
    }
}
