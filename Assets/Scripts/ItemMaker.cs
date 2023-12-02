using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMaker: MonoBehaviour
{
    #region 아이템 이름
    enum ItemName
    {
        Item_A = 0,
        Item_B,
        Item_C,
        Item_D,
        Item_E,
        Item_F,
        Item_G
    }
    #endregion

    public GameObject item;
    private InputEvent controller;

    private void Awake()
    {
        controller = GetComponent<InputEvent>();
    }

    private void Start()
    {
        controller.OnItemEvent += ItemMake;
    }

    private void ItemMake(Vector2 position)
    {
        print("뭐가 문젠데");

        int rand = Random.Range(0, 7);
        string currentName = "";
        #region 아이템별 속성
        switch (rand)
        {
            case 0:
                currentName = Enum.GetName(typeof(ItemName), 0);
                break;
            case 1:
                currentName = Enum.GetName(typeof(ItemName), 1);
                break;
            case 2:
                currentName = Enum.GetName(typeof(ItemName), 2);
                break;
            case 3:
                currentName = Enum.GetName(typeof(ItemName), 3);
                break;
            case 4:
                currentName = Enum.GetName(typeof(ItemName), 4);
                break;
            case 5:
                currentName = Enum.GetName(typeof(ItemName), 5);
                break;
            case 6:
                currentName = Enum.GetName(typeof(ItemName), 6);
                break;
        }
        #endregion

        GameObject newItem = Instantiate(item);
        newItem.transform.position = position;
        newItem.name = currentName;
        newItem.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50f);
        newItem = GameObject.Find("Items");
        //Instantiate(item, position,Quaternion.identity);
    }

    


}

