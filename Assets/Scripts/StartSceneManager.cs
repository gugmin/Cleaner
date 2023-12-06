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
        if (PlayerPrefs.HasKey("EasyBoss")) //이지보스 클리어
        {
            print("ddddddddd");
            button[0].interactable = true;
        }
        else
        { button[0].interactable = false; }

        if (PlayerPrefs.HasKey("NormalBoss")) //노말보스 클리어
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
