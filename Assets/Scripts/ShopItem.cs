using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class ShopItem : MonoBehaviour
{
    int eq = 0;
    public string[] shopItem = { "Sand", "Angel", "Shield", "Amulet" };
    public GameObject[] EquipCheck;

    private void Awake()
    {
        for (int i = 0; i < shopItem.Length; i++)
        {
            if (PlayerPrefs.HasKey(shopItem[i]))
            {
                EquipCheck[i].SetActive(true);
            }
            else
            {
                EquipCheck[i].SetActive(false);
            }
        }
    }

    public void Equip()
    {
        if (eq < 2)
        {
            GameObject gameObject = EventSystem.current.currentSelectedGameObject;
            PlayerPrefs.SetString(gameObject.name, gameObject.name);
            eq++;
        }
        else
        {
            //TODO ÆÇ³Ú
        }
    }
    public void Unequip()
    {
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;
        if (PlayerPrefs.HasKey(gameObject.name)) 
        {
            PlayerPrefs.DeleteKey(gameObject.name);
            eq--;
        }
    }
}
