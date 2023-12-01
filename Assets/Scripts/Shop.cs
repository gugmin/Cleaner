using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void GoShopBtn() // 상점? 인벤토리? 이동하기
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void GoHomeBtn() // 메인으로~
    {
        SceneManager.LoadScene("StartScene");
    }
}
