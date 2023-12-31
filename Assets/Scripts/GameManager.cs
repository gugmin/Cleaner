using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Microsoft.Win32.SafeHandles;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] private CameraMove cm;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject rtan;
    [SerializeField] private GameObject LeftUI;
    [SerializeField] private GameObject RightUI;

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossimg;
    [SerializeField] private PaddleControl paddle;
    [SerializeField] private BallMaker ball;
    [SerializeField] private BrickMaker brickmaker;
    [SerializeField] private SpriteRenderer flash;

    [SerializeField] private GameObject angel;
    [SerializeField] private ItemMaker Items;

    public GameObject endPanel;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;
    //gm
    public GameObject _ball;
    public int life;
    public int maxLife;
    public SpriteRenderer[] lifeSprite;
    public SpriteRenderer[] eqitem;
    public string[] shopItem = { "Sand", "Angel", "Shield", "Amulet" };
    public int score;
    public int maxScore;
    public int studyPoint;
    //item
    public GameObject Shield;
    //jw
    [SerializeField] Image TimeBar;
    public float maxTime;
    public float time;
    public int currentRound;
    public bool isDead = false;
    public bool isStageClear = false;
    public bool isAngel = false;
    public bool isGameOver = false;

    Scene scene;

    private void Awake()
    {
        time = maxTime;
        I = this;
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 0.0f;
        currentRound = 1;
        if (PlayerPrefs.HasKey(shopItem[1])) isAngel = true;

        if (PlayerPrefs.HasKey(scene.name))
        {
            maxScore = PlayerPrefs.GetInt(scene.name);
        }
    }

    void Start()
    {
        if (scene.name == "HardScene")
        {
            StartCoroutine(StartEasyBossRound());
        }
        else
            StartCoroutine(StartRound());
    }

    // Update is called once per frame
    void Update()
    {   //
        time -= Time.deltaTime;
        if (TimeBar != null)
        {
            TimeBar.fillAmount = time / maxTime;
            rtan.GetComponent<RectTransform>().localPosition = new Vector3(TimeBar.fillAmount * (-70) + 35, 0, 0);
        }
        //
        scoreTxt.text = "스코어 : " + score.ToString("");

        if (isDead == true)
        {
            isDead = false;
            ball.Invoke("ReSpawn", 2f);
        }
        else if (life == 0 && !isGameOver)
        {
            isGameOver = true;
            GameEnd();
        }
        if (isStageClear == true)
        {
            ball.DestroyAllChild();
            if(boss!=null)
                StartCoroutine(BossShake(1.0f, 0.1f));
            Invoke("GameEnd", 2f);
        }
    }

    public void eqSprite()
    {
        int i = 0;
        for (i = 0; i < shopItem.Length; i++)
        {
            if (PlayerPrefs.HasKey(shopItem[i]))
            {
                eqitem[0].sprite = Resources.Load<Sprite>("ShopItem/" + shopItem[i]); // 이미지 교체
                break;
            }
        }
        for (int j = 0; j < shopItem.Length; j++)
        {
            if (PlayerPrefs.HasKey(shopItem[j]) && (i != j))
            {
                eqitem[1].sprite = Resources.Load<Sprite>("ShopItem/" + shopItem[j]); // 이미지 교체
                break;
            }
        }
    }

    public void UseShield()
    {
        if (PlayerPrefs.HasKey("Shield"))
        {
            Shield.SetActive(true);
        }
    }

    public void LostLife()
    {

        for (int i = 0; i < maxLife; i++)
        {
            lifeSprite[i].color = new Color(1, 1, 1, 0.5f);
        }

        for (int i = 0; i < life; i++)
        {
            lifeSprite[i].color = new Color(1, 1, 1, 1);
        }
    }

    private void GameEnd()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);
        Destroy(boss);
        int star = 0;
        if (time >= 120)
        {
            star = 3;
        }
        else if (time >= 60)
        {
            star = 2;
        }
        else
        {
            star = 1;
        }
        if (life <= 0)
            star = 1;

        // score : 원래 점수, plus : 최종 점수
        int plus = score * star;
        if (PlayerPrefs.HasKey("Sand"))
            plus = plus + plus * 20 / 100;

        //누적공부시간 저장
        int curPoint = 0;
        if (PlayerPrefs.HasKey("StudyPoint"))
            curPoint = PlayerPrefs.GetInt("StudyPoint");
        PlayerPrefs.SetInt("StudyPoint", curPoint + plus);
        //최고점수 비교
        if (score > maxScore)
        {
            maxScore = score;
        }
        PlayerPrefs.SetInt(scene.name, maxScore);
        maxScoreText.text = "최고 점수 : " + maxScore.ToString();
        thisScoreText.text = "현재 점수 : " + score.ToString();
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void RetryGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene.name);
    }
    public void GoHomeBtn()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
    }
    public IEnumerator StartEasyBossRound()
    {
        eqSprite();
        cm.StartRound();
        brickmaker.isBoss = true;
        paddle.SetInit();
        yield return new WaitForSecondsRealtime(2.0f);
        LeftUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(1.0f);
        Color c = flash.color;
        while (c.a < 1)
        {
            c.a += 0.03f;
            flash.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        boss.SetActive(true);
        //TODO boss.GetComponent<Sprite
        while (c.a > 0)
        {
            c.a -= 0.03f;
            flash.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Time.timeScale = 1.0f;
    }
    public IEnumerator StartRound()
    {
        eqSprite();
        UseShield();
        brickmaker.MakeEasyBrick(currentRound);
        cm.StartRound();
        paddle.SetInit();
        yield return new WaitForSecondsRealtime(2.0f);
        LeftUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1.0f;
    }
    public IEnumerator RoundClear()
    {
        currentRound++;
        ball.ballCount = 0;
        ball.DestroyAllChild();
        Time.timeScale = 0.0f;
        LeftUI.transform.DOMove(new Vector3(-10, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(10, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(2.0f);
        cm.RoundClear();
        yield return new WaitForSecondsRealtime(2.0f);
        paddle.ResetPos();
        ball.ReSpawn();
        brickmaker.isClear = false;
        if (currentRound >= 3)
            StartCoroutine(StartEasyBossRound());
        else
            StartCoroutine(StartRound());
        Items.DestroyAllChild();
    }
    public IEnumerator AngelRespawn(GameObject ball)
    {
        Time.timeScale = 0.0f;
        angel.transform.position = ball.transform.position + new Vector3(0, 0.2f, 0);
        Color c = angel.GetComponent<SpriteRenderer>().color;
        while (c.a < 1)
        {
            c.a += Time.unscaledDeltaTime / 2;
            angel.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
        ball.GetComponent<Ball>().getParticle().Stop();
        ball.GetComponent<Collider2D>().enabled = false;
        ball.transform.DOMove(paddle.gameObject.transform.position + new Vector3(0, 0.5f, 0), 2).SetUpdate(true);
        angel.transform.DOMove(paddle.gameObject.transform.position + new Vector3(0, 0.8f, 0), 2).SetUpdate(true);
        yield return new WaitForSecondsRealtime(2.0f);
        ball.GetComponent<Ball>().SetIsStart(false);
        Time.timeScale = 1.0f;
        angel.SetActive(false);
        ball.GetComponent<Collider2D>().enabled = true;
        yield return null;
    }
    public IEnumerator BossShake(float time, float power)
    {
        float timer = 0;
        bossimg.transform.localPosition = UnityEngine.Random.insideUnitSphere * power + bossimg.transform.localPosition;
        timer += Time.unscaledDeltaTime;
        yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
    }
    public PaddleControl GetPaddle()
    {
        return paddle;
    }

    public BallMaker GetBalls()
    {
        return ball;
    }
    public ItemMaker GetItems()
    {
        return Items;
    }
}

