using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class ItemMaker: MonoBehaviour
{
    #region 아이템 이름
    enum ItemName
    {
        Item_Print = 0,
        Item_Steel = 1,
        Item_Zoom = 2,
        Item_Power = 3,
        Item_Fire = 4,
        Item_Glue = 5,
        Item_Haste = 6
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
        int rand = Random.Range(0, 7);
        //int rand = 1;

        GameObject newItem = Instantiate(item);
        newItem.transform.position = position;
        newItem.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50f);

        string name = Enum.GetName(typeof(ItemName), rand);
        newItem.name = name;
        newItem.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + name);

        newItem.transform.parent = GameObject.Find("Items").transform;
    }

    public void DestroyAllChild()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == transform.name)
                continue;

            Destroy(child.gameObject);
        }
    }


}

