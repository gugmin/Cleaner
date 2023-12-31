using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private Image HpBar;
    [SerializeField] private SpriteRenderer Mirror;
    [SerializeField] private SpriteRenderer vport;
    public GameObject bricks;
    bool firstPattern = false;
    bool secondPattern = false;
    bool thirdPattern = false;
    [SerializeField ]float ballDamage;

    private void Start()
    {
        vport.enabled = false;
    }

    private void Update()
    {
        if(HpBar.fillAmount == 0)
        {
            PlayerPrefs.SetString("EasyBoss", "Clear");
            GameManager.I.isStageClear = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag( "Ball")) 
        {
            // 투명도 줄이기
            Color Mirrorcolor = Mirror.color;
            // image길이 줄이기, 전체가 1이기 때문에 0.1씩 줄이게 되면 총 10대를 맞게 된다.
            if (collision.gameObject.GetComponent<Ball>().itemname == ItemMaker.ItemName.Item_Steel)
            {
                HpBar.fillAmount -= ballDamage * 2;
                Mirrorcolor.a -= ballDamage * 2;
            }
            else
            {
                HpBar.fillAmount -= ballDamage;
                Mirrorcolor.a -= ballDamage;
            }
            Selectpattern();
            // 강철공일 경우 0.2 데미지가 들어가도록 해야함.
            if (HpBar.fillAmount < 0f)
            {
                Mirrorcolor.a = 0f;
                HpBar.fillAmount = 0f;
            }
            Mirror.color = Mirrorcolor;
            print("Boss 충돌");
        }
    }

    private void Selectpattern()
    {
        float test = HpBar.fillAmount;
        if (test < 0.8f && !firstPattern)
        {
            firstPattern = true;
            for (int i = 0; i < 8; i++)
            {
                GameObject brick = Instantiate(bricks);
                brick.transform.parent = GameObject.Find("Pattern").transform;
                // 색 변경
                // newBrick.GetComponent<SpriteRenderer>().color = Color.blue;
                // 이미지 변경
                // newBrick.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Brick/Sprite-0011");

                // x = 갯수 * 가로 공백 - 초기위치
                // y = 갯수 * 세로 공백 - 초기위치
                float x = (i % 6) * 1.2f - 3f;
                float y =  -0.8f;

                brick.transform.position = new Vector3(x, y, 0);
            }
        }
        else if (test < 0.5f && !secondPattern)
        {
            secondPattern = true;
            for (int i = 0; i < 10; i++)
            { 
                vport.enabled = true;
                GameObject brick = Instantiate(bricks);
                brick.transform.parent = GameObject.Find("Pattern").transform;
                float x = (i % 6) * 1.2f - 3f;
                float y = -1.2f;
                brick.transform.position = new Vector3(x, y, 0);
            }
        }
        else if (test < 0.2f && !thirdPattern)
        {
            thirdPattern = true;
            for (int i = 0; i < 6; i++)
            {
                GameObject brick = Instantiate(bricks);
                brick.transform.parent = GameObject.Find("Pattern").transform;
                float x = (i / 3) * 5f - 3f;
                float y = (i % 3) * 0.5f - 0.8f;
                brick.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}
