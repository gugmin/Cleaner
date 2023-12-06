using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    void Awake()
    {
        if (gameObject.name == "NoramlBtn" && PlayerPrefs.HasKey("EasyBoss")) //�������� Ŭ����
        {
            GetComponent<Button>().interactable = true;
        }
        else if (gameObject.name == "HardBtn" && PlayerPrefs.HasKey("NormalBoss")) //�븻���� Ŭ����
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void EazySceneLoad()
    {
        SceneManager.LoadScene("GugminScene");
    }

    public void NormalSceneLoad()
    {
        SceneManager.LoadScene("Lsc_NormalScene");
    }

    public void HardSceneLoad()
    {
        SceneManager.LoadScene("Lsc_HardScene");
    }
}
