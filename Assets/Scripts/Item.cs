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
                // 공 갯수 증가
                case "Item_Print":
                    break;

                // 공 데미지 강화
                case "Item_Steel":
                    break;

                // 공 크기 증가
                case "Item_Zoom":
                    break;

                // 패들 크기 증가
                case "Item_Power":
                    paddle.IsPower(paddle.GetSize() * 2);
                    break;

                // 공 속도 증가
                case "Item_Fire":
                    break;

                // 공 속도 감소
                case "Item_Glue":
                    break;

                // 패들 속도 증가
                case "Item_Haste":
                    paddle.IsHaste(paddle.GetSpeed() * 2);
                    break;
            }

            //print("패들닿음");
            Destroy(transform.gameObject);
        }

        else if (collision.CompareTag("BottomWall"))
        {
            Destroy(transform.gameObject);
        }
    }
}
