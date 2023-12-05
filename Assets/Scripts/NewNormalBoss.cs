using UnityEngine;

public class NewNormalBoss : MonoBehaviour
{
    float bossMovementX = 0.05f; // Boss �� x �� ������
    public int bossMaxHP = 10; // Boss �� Max HP
    int damageFromBall = 0; // ���� ���ݷ�

    public NewNormalBossBrickMaker nbBrickMaker;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 2.6f) // Boss �� ������ ȭ�� ������ ���� �������� ���� ��ȯ
        {
            bossMovementX = -0.05f;
        }

        if (transform.position.x < -2.6f) // Boss �� ���� ȭ�� ������ ���� ���������� ���� ��ȯ
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
        if (collision.collider.CompareTag("Ball")) // boss �� Ball �� ������ Boss �� ������ ����.
        {
            damageFromBall += 1;

            // HPfront ������Ʈ ã��
            GameObject varOfHPfront = GameObject.Find("HPfront");

            varOfHPfront.transform.localScale = new Vector3(1 - ((float)damageFromBall / bossMaxHP), 1.0f, 1.0f); // ���� �� �ڷ��� ���� !

            // RandomBrickSpawn
            nbBrickMaker.RandomBrickSpawn(bossMaxHP - damageFromBall);

            if (damageFromBall >= bossMaxHP) // boss �� �׾��� �� - �ð��� 0 ���� �����ؼ� HP bar ��ȭ�� boss ������ �Ͼ�� �ʵ��� ����.
            {
                BossDead();
            }
        }
    }

    void BossDead()
    {
        // Boss ������ Stop �� FixedUpdate() ���� ����.

        // Boss �׾��� �� dead(���� ��) ���� ������
        gameObject.transform.Find("alive").gameObject.SetActive(false);
        gameObject.transform.Find("dead").gameObject.SetActive(true);

        // �ð� 0 ���� ����.
        //Time.timeScale = 0.0f;
        GameManager.I.isStageClear = true;
    }


    // TODO Ư�� HP ���� item ����ϵ���
}

