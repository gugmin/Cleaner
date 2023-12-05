using UnityEngine;

public class NewNormalBoss : MonoBehaviour
{
    float bossMovementX = 0.05f; // Boss 의 x 축 움직임
    public int bossMaxHP = 10; // Boss 의 Max HP
    int damageFromBall = 0; // 공의 공격력

    public NewNormalBossBrickMaker nbBrickMaker;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 2.6f) // Boss 가 오른쪽 화면 끝까지 가면 왼쪽으로 방향 전환
        {
            bossMovementX = -0.05f;
        }

        if (transform.position.x < -2.6f) // Boss 가 왼쪽 화면 끝까지 가면 오른쪽으로 방향 전환
        {
            bossMovementX = 0.05f;
        }
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(bossMovementX, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball")) // boss 와 Ball 이 만나면 Boss 가 데미지 입음.
        {
            damageFromBall += 1;

            // HPfront 컴포넌트 찾기
            GameObject varOfHPfront = GameObject.Find("HPfront");

            varOfHPfront.transform.localScale = new Vector3(1 - ((float)damageFromBall / bossMaxHP), 1.0f, 1.0f); // 나눌 때 자료형 주의 !

            // RandomBrickSpawn
            nbBrickMaker.RandomBrickSpawn(bossMaxHP - damageFromBall);

            if (damageFromBall >= bossMaxHP) // boss 가 죽었을 때 - 시간을 0 으로 세팅해서 HP bar 변화와 boss 움직임 일어나지 않도록 세팅.
            {
                BossDead();
            }
        }
    }

    void BossDead()
    {
        // Boss 움직임 Stop 은 FixedUpdate() 에서 구현.

        // Boss 죽었을 때 dead(붉은 색) 으로 췌인지
        gameObject.transform.Find("alive").gameObject.SetActive(false);
        gameObject.transform.Find("dead").gameObject.SetActive(true);

        // 시간 0 으로 설정.
        //Time.timeScale = 0.0f;
        GameManager.I.isStageClear = true;
    }


    // TODO 특정 HP 마다 item 드랍하도록
}

