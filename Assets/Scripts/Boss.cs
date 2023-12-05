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

    private void Start()
    {
        vport.enabled = false;
    }

    private void Update()
    {
        if(HpBar.fillAmount == 0)
        {
            GameManager.I.isStageClear = true;
            // �������� �� �����ǳ� ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag( "Ball")) 
        {
            Color Mirrorcolor = Mirror.color;
            // ���� ���̱�
            Mirrorcolor.a -= 0.1f;
            Selectpattern();
            // image���� ���̱�, ��ü�� 1�̱� ������ 0.1�� ���̰� �Ǹ� �� 10�븦 �°� �ȴ�.
            HpBar.fillAmount -= 0.1f;
            if (HpBar.fillAmount < 0f)
            {
                Mirrorcolor.a = 0f;
                HpBar.fillAmount = 0f;
            }
            Mirror.color = Mirrorcolor;
            print("Boss �浹");
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
                // x = ���� * ���� ���� - �ʱ���ġ
                // y = ���� * ���� ���� - �ʱ���ġ
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
                float y = (i / 6) * 0.5f - 0.8f;
                brick.transform.position = new Vector3(x, y, 0);
            }
        }
        else if (test < 0.2f && !thirdPattern)
        {
            thirdPattern = true;
            for (int i = 0; i < 8; i++)
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
