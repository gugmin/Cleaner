using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    private PaddleControl paddle;
    [SerializeField] private GameObject ball;
    private GameObject ballParent;




    private void Start()
    {
        paddle = GameManager.I.GetPaddle();
        ballParent = GameObject.Find("Balls");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {

            switch (transform.name)
            {
                // 공 갯수 증가
                case "Item_Print":
                    if (ballParent.transform.childCount < 2)
                    {
                        if(GameManager.I.isDead == true || GameManager.I.GetBalls().ballCount == 0) break;
                        Ball originBall = ballParent.transform.GetChild(0).GetComponent<Ball>();
                        if (originBall.GetIsStart() == false) break;
                        GameObject newBall = Instantiate(ball);
                        GameManager.I.GetBalls().ballCount++;

                        newBall.transform.GetComponent<Ball>().SetIsStart(true);
                        newBall.transform.position = originBall.transform.position + new Vector3(0, 0.2f, 0);
                        newBall.transform.parent = ballParent.transform;
                        float speed = originBall.GetComponent<Ball>().GetSpeed();
                        newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1).normalized * speed);
                        //newBall.GetComponent<Ball>().SetSpeed(speed);
                    }
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
                    for(int i = 0; i < ballParent.transform.childCount; i++)
                    {
                        Ball newball = ballParent.transform.GetChild(i).GetComponent<Ball>();
                        float speed = newball.GetSpeed();
                        newball.SetSpeed(speed * 2);
                    }
                    break;

                // 공 속도 감소
                case "Item_Glue":
                    for (int i = 0; i < ballParent.transform.childCount; i++)
                    {
                        Ball newball = ballParent.transform.GetChild(i).GetComponent<Ball>();
                        float speed = newball.GetSpeed();
                        newball.SetSpeed(speed / 2);
                    }
                    break;

                // 패들 속도 증가
                case "Item_Haste":
                    paddle.IsHaste(paddle.GetSpeed() * 2);
                    break;
            }

            Destroy(transform.gameObject);
        }

        else if (collision.CompareTag("BottomWall"))
        {
            Destroy(transform.gameObject);
        }
    }

    

}
