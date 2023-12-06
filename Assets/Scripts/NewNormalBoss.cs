using UnityEngine;
using UnityEngine.UI;

public class NewNormalBoss : MonoBehaviour
{
    float bossMovementX = 0.05f; // Boss �� x �� ������
    //public int bossMaxHP = 10; // Boss �� Max HP

    public NewNormalBossBrickMaker nbBrickMaker;

    private GameObject ballParent;
    private GameObject brickParent;

    [SerializeField] private Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        ballParent = GameObject.Find("Balls");

        for (int i = 0; i < ballParent.transform.childCount; i++)
        {
            SpriteRenderer newBall = ballParent.transform.GetChild(i).GetComponent<SpriteRenderer>();
            newBall.sprite = Resources.Load<Sprite>("NormalBoss/handBall");
        }

        brickParent = GameObject.Find("Bricks");

        for (int i = 0; i <  brickParent.transform.childCount; i++)
        {
            //brickParent �� child  �̹����� ��������ֱ�
            SpriteRenderer newBrick = brickParent.transform.GetChild(i).GetComponent<SpriteRenderer>();
            newBrick.sprite = Resources.Load<Sprite>("NormalBoss/wafersBricks");
        }
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
            hpBar.fillAmount -= 0.05f;

            //TODO RandomBrickSpawn
            nbBrickMaker.RandomBrickSpawn(hpBar.fillAmount);

            if (hpBar.fillAmount <= 0.0f) // boss �� �׾��� �� - �ð��� 0 ���� �����ؼ� HP bar ��ȭ�� boss ������ �Ͼ�� �ʵ��� ����.
            {
                BossDead();
            }
        }
    }

    void BossDead()
    {
        PlayerPrefs.SetString("NormalBoss", "Clear");
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

