using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private InputEvent controller;
    private int plusAmulet = 10;
    public int HP = 1;
    private void Awake()
    {
        controller = GetComponent<InputEvent>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Amulet")) plusAmulet = 10;
    }

    // Brick 이 Ball 과 만나서 파괴될 때의 함수 ( tag 를 사용한다는 가정 하에 )
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {

            int rand = Random.Range(0, 100);
            if(rand < 20 + plusAmulet)
            {
                controller.CallItemEvent(transform.position);
            }

            GameManager.I.score++;
            if (collision.gameObject.GetComponent<Ball>().itemname == ItemMaker.ItemName.Item_Steel)
                HP -= 2;
            else
                HP--;
            if(HP<=0)
                Destroy(gameObject);
            // 공과 벽돌이 만났을 때 공이 다시 튕겨나오게 해야하는데 hmmhmm.. 여기서 구현해야하는가 Ball 에서 구현해야하는가 ?
        }
    }

}
