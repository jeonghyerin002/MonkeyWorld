using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "New Item/Item")]
public class ItemSO : ScriptableObject
{
    [Header("아이템 정보")]
    public string itemName;         //아이템 이름
    public Sprite itemIcon;         //아이템 아이콘
    public itemtype type;


    public enum itemtype
    {
        screw,          //나사
        spring,         //스프링
        cogwheel        //톱니바퀴



    }
}
