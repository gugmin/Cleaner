using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class ItemMaker: MonoBehaviour
{
    #region æ∆¿Ã≈€ ¿Ã∏ß
    enum ItemName
    {
        Item_Print = 0,
        Item_Steel,
        Item_Zoom,
        Item_Power,
        Item_Fire,
        Item_Glue,
        Item_Haste
    }
    #endregion

    public GameObject item;
    private InputEvent controller;
    //[SerializeField] private Texture2D[] items;
    

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
        print("ππ∞° πÆ¡®µ•");

        int rand = Random.Range(0, 7);
        //int rand = 0;

        GameObject newItem = Instantiate(item);
        newItem.transform.position = position;
        newItem.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50f);

        string name = Enum.GetName(typeof(ItemName), rand);
        newItem.name = name;
        newItem.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + name);

        newItem.transform.parent = GameObject.Find("Items").transform;
    }




}

