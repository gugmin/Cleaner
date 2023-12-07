using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using TMPro;
public class ShopItem : MonoBehaviour
{
    [SerializeField] int eq = 0;
    public string[] shopItem = { "Sand", "Angel", "Shield", "Amulet" };
    public GameObject[] EquipCheck;
    [SerializeField] int SandPoint=300;
    [SerializeField] int AngelPoint=500;
    [SerializeField] int ShieldPoint=700;
    [SerializeField] int AmuletPoint=900;
    [SerializeField] Button[] equipbtn;
    [SerializeField] Button[] unequipbtn;
    [SerializeField] TMP_Text StudyPointTxt;
    [SerializeField] GameObject WarningUI;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("StudyPoint"))
        {
            int CurPoint = PlayerPrefs.GetInt("StudyPoint");
            StudyPointTxt.text = "누적 공부시간 : "+CurPoint.ToString()+"시간";
            //CurPoint = 500;
            if (CurPoint > AmuletPoint)
            {
                equipbtn[3].interactable = true;
                unequipbtn[3].interactable = true;
            }

            if (CurPoint > ShieldPoint)
            {
                equipbtn[2].interactable = true;
                unequipbtn[2].interactable = true;
            }

            if (CurPoint > AngelPoint)
            {
                equipbtn[1].interactable = true;
                unequipbtn[1].interactable = true;
            }

            if (CurPoint > SandPoint)
            {
                equipbtn[0].interactable = true;
                unequipbtn[0].interactable = true;
            }
        }
        EquipChk();
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
            WarningUI.SetActive(true);
            EquipChk();
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
    public void EquipChk()
    {
        int equipcnt = 0;
        for (int i = 0; i < shopItem.Length; i++)
        {
            if (PlayerPrefs.HasKey(shopItem[i]))
            {
                EquipCheck[i].SetActive(true);
                equipcnt++;
            }
            else
            {
                EquipCheck[i].SetActive(false);
            }
        }
        eq = equipcnt;
    }
}
