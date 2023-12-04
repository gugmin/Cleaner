using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    private PaddleControl paddle;

    private void Start()
    {
        paddle = GameManager.I.getPaddle();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            print(transform.name);
            switch (transform.name)
            {
                // �� ���� ����
                case "Item_Print":
                    break;

                // �� ������ ��ȭ
                case "Item_Steel":
                    break;

                // �� ũ�� ����
                case "Item_Zoom":
                    break;

                // �е� ũ�� ����
                case "Item_Power":
                    paddle.IsPower(paddle.GetSize() * 2);
                    break;

                // �� �ӵ� ����
                case "Item_Fire":
                    break;

                // �� �ӵ� ����
                case "Item_Glue":
                    break;

                // �е� �ӵ� ����
                case "Item_Haste":
                    paddle.IsHaste(paddle.GetSpeed() * 2);
                    break;
            }

            //print("�е����");
            Destroy(transform.gameObject);
        }

        else if (collision.CompareTag("BottomWall"))
        {
            Destroy(transform.gameObject);
        }
    }
}
