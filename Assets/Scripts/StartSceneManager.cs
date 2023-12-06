using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] GameObject SettingUI;
    [SerializeField] Button[] button;
    void Awake()
    {
        if (PlayerPrefs.HasKey("EasyBoss")) //�������� Ŭ����
        {
            print("ddddddddd");
            button[0].interactable = true;
        }
        else
        { button[0].interactable = false; }

        if (PlayerPrefs.HasKey("NormalBoss")) //�븻���� Ŭ����
        {
            button[1].interactable = true;
        }
        else
        { button[1].interactable = false; }
    }

    public void EasySceneLoad()
    {
        SceneManager.LoadScene("EasyScene");
    }

    public void NormalSceneLoad()
    {
        SceneManager.LoadScene("NormalScene");
    }

    public void HardSceneLoad()
    {
        SceneManager.LoadScene("HardScene");
    }
}
