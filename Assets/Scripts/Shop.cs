using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void GoShopBtn() // ����? �κ��丮? �̵��ϱ�
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void GoHomeBtn() // ��������~
    {
        SceneManager.LoadScene("StartScene");
    }
}
