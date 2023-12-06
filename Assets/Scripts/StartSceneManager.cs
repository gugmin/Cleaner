using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] GameObject SettingUI;
    void Awake()
    {
        if (gameObject.name == "NoramlBtn" && PlayerPrefs.HasKey("EasyBoss")) //이지보스 클리어
        {
            GetComponent<Button>().interactable = true;
        }
        else if (gameObject.name == "HardBtn" && PlayerPrefs.HasKey("NormalBoss")) //노말보스 클리어
        {
            GetComponent<Button>().interactable = true;
        }
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
        print("공사중");
        //SceneManager.LoadScene("HardScene");
    }
}
