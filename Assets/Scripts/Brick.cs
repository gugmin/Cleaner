using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Brick �� Ball �� ������ �ı��� ���� �Լ� ( tag �� ����Ѵٴ� ���� �Ͽ� )
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameManager.I.score++;
            Destroy(gameObject);
            // ���� ������ ������ �� ���� �ٽ� ƨ�ܳ����� �ؾ��ϴµ� hmmhmm.. ���⼭ �����ؾ��ϴ°� Ball ���� �����ؾ��ϴ°� ?
        }
    }

}
