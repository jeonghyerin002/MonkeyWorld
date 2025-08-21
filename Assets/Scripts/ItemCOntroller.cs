using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCOntroller : MonoBehaviour
{
  public int itemIndex; // 아이템 인덱스

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))             // 플레이어가 아이템에 닿았을 때
        {
            GameManager.Instance.CollectItem(itemIndex);
            Destroy(gameObject);  // 먹은 아이템 제거
        }
    }
}
