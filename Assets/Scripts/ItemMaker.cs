using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemMaker: MonoBehaviour
{
    enum ItemName
    {
        A=0 , B, C, D,E,F,G
    }

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
        print("¹¹°¡ ¹®Á¨µ¥");

        //int rand = Random.Range(0, 7);
        //string currentName = "";
        //switch (rand)
        //{
        //    case 0:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 0);
        //        break;
        //    case 1:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 1);
        //        break;
        //    case 2:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 2);
        //        break;
        //    case 3:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 3);
        //        break;
        //    case 4:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 4);
        //        break;
        //    case 5:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 5);
        //        break;
        //    case 6:
        //        currentName = "Item_" + Enum.GetName(typeof(ItemName), 6);
        //        break;
        //}

        //GameObject newItem = Instantiate(item);
        //item.transform.position = brickTr;
        //item.name = currentName;
        //item.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0.008f);
        item.transform.parent = GameObject.Find("Items").transform;
    }

    
}

