using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Image[] ShopItems;
    public Image[] EquipItems;
    void Start()
    {
        ShopItems = GetComponent<Image[]>();
        EquipItems = GetComponent<Image[]>();
    }

    void Update()
    {
        
    }
    public void SelectItem()
    {
        //PlayerPrefs.GetString(EquipItems[Image.name]);
    }
}
