using UnityEngine;
using UnityEngine.UI;

public class NewNormalBoss : MonoBehaviour
{
    float bossMovementX = 0.05f; // Boss 의 x 축 움직임
    //public int bossMaxHP = 10; // Boss 의 Max HP

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
            //brickParent 의 child  이미지들 변경시켜주기
            SpriteRenderer newBrick = brickParent.transform.GetChild(i).GetComponent<SpriteRenderer>();
            newBrick.sprite = Resources.Load<Sprite>("NormalBoss/wafersBricks");
        }
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
            hpBar.fillAmount -= 0.05f;

            //TODO RandomBrickSpawn
            nbBrickMaker.RandomBrickSpawn(hpBar.fillAmount);

            if (hpBar.fillAmount <= 0.0f) // boss 가 죽었을 때 - 시간을 0 으로 세팅해서 HP bar 변화와 boss 움직임 일어나지 않도록 세팅.
            {
                BossDead();
            }
        }
    }

    void BossDead()
    {
        PlayerPrefs.SetString("NormalBoss", "Clear");
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

