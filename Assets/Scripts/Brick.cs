using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private InputEvent controller;

    private void Awake()
    {
        controller = GetComponent<InputEvent>();
    }

    // Brick �� Ball �� ������ �ı��� ���� �Լ� ( tag �� ����Ѵٴ� ���� �Ͽ� )
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            int rand = Random.RandomRange(0, 100);
            if(rand < 100)
            {
                controller.CallItemEvent(transform.position);
            }

            Destroy(gameObject);
            // ���� ������ ������ �� ���� �ٽ� ƨ�ܳ����� �ؾ��ϴµ� hmmhmm.. ���⼭ �����ؾ��ϴ°� Ball ���� �����ؾ��ϴ°� ?
        }
    }

}