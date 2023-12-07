using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using System;

public class Item : MonoBehaviour
{
    private PaddleControl paddle;
    [SerializeField] private GameObject ball;
    private GameObject ballParent;
    Scene scene ;


    private void Start()
    {
        paddle = GameManager.I.GetPaddle();
        ballParent = GameObject.Find("Balls");
        scene = SceneManager.GetActiveScene();


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

                        print(scene.name);
                        newBall.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/" + scene.name);
                        

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
                    for (int i = 0; i < ballParent.transform.childCount; i++)
                    {
                        Ball newball = ballParent.transform.GetChild(i).GetComponent<Ball>();
                        newball.itemname = ItemMaker.ItemName.Item_Steel;
                        newball.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Item/SteelBall");
                        float damage = newball.GetDamage();
                        newball.SetDamage(damage * 2);
                    }
                    break;

                // 공 크기 증가
                case "Item_Zoom":
                    for (int i = 0; i < ballParent.transform.childCount; i++)
                    {
                        Ball newball = ballParent.transform.GetChild(i).GetComponent<Ball>();
                        newball.SetSize(0.4f);
                    }
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
