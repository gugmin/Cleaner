using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Brick �� Ball �� ������ �ı��� ���� �Լ� ( tag �� ����Ѵٴ� ���� �Ͽ� )
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            // ���� ������ ������ �� ���� �ٽ� ƨ�ܳ����� �ؾ��ϴµ� hmmhmm.. ���⼭ �����ؾ��ϴ°� Ball ���� �����ؾ��ϴ°� ?
        }
    }

}
