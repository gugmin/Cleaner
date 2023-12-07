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

    // Brick �� Ball �� ������ �ı��� ���� �Լ� ( tag �� ����Ѵٴ� ���� �Ͽ� )
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
            // ���� ������ ������ �� ���� �ٽ� ƨ�ܳ����� �ؾ��ϴµ� hmmhmm.. ���⼭ �����ؾ��ϴ°� Ball ���� �����ؾ��ϴ°� ?
        }
    }

}
