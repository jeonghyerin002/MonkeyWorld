using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "New Item/Item")]
public class ItemSO : ScriptableObject
{
    [Header("������ ����")]
    public string itemName;         //������ �̸�
    public Sprite itemIcon;         //������ ������
    public itemtype type;


    public enum itemtype
    {
        screw,          //����
        spring,         //������
        cogwheel        //��Ϲ���



    }
}
