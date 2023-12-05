using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] private CameraMove cm;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject rtan;
    [SerializeField] private GameObject LeftUI;
    [SerializeField] private GameObject RightUI;
    [SerializeField] private SpriteRenderer angel;
    [SerializeField] private PaddleControl paddle;
    [SerializeField] private BallMaker ball;
    [SerializeField] private BrickMaker brickmaker;
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
    //item
    public GameObject Shield;
    //jw
    [SerializeField] Image TimeBar;
    public float maxTime;
    public float time;
    public int currentRound;
    public bool isDead = false;
    public bool isAngel = false;

    Scene scene;

    private void Awake()
    {
        I = this;
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 0.0f;
        currentRound = 1;
        if (PlayerPrefs.HasKey(shopItem[1])) isAngel = true;
    }

    void Start()
    {
        StartCoroutine(StartRound());
    }

    // Update is called once per frame
    void Update()
    {   //
        time -= Time.deltaTime;
        if(TimeBar != null)
        {
            TimeBar.fillAmount = time / maxTime;
            rtan.GetComponent<RectTransform>().localPosition = new Vector3( TimeBar.fillAmount*(-70)+35, 0, 0);
        }
        //
        scoreTxt.text = "스코어 : " + score.ToString("");
     
        if (isDead == true)
        {
            isDead = false;
            ball.Invoke("ReSpawn", 2f);
        }
        else if (life == 0)
        {
            GameEnd();
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

        if (score > maxScore)
        {
            maxScore = score;
            maxScoreText.text = "최고점수 : " + score.ToString();
        }
        else if (score < maxScore)
        {
            thisScoreText.text = "현재점수 : " + score.ToString();
        }
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
    public IEnumerator StartRound()
    {
        eqSprite();
        UseShield();
        brickmaker.MakeEasyBrick(currentRound);
        time = maxTime;
        cm.StartRound();
        yield return new WaitForSecondsRealtime(2.0f);
        LeftUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1.0f;
    }
    public IEnumerator RoundClear()
    {
        currentRound++;
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
        StartCoroutine(StartRound());
        Items.DestroyAllChild();
    }
    public IEnumerator AngelRespawn(GameObject ball)
    {
        Time.timeScale = 0.0f;
        angel.transform.position = ball.transform.position + new Vector3(0, 0.2f, 0);
        Color c = angel.color;
        while (c.a < 1)
        {
            c.a += Time.deltaTime * 2;
            angel.color = c;
            yield return new WaitForSeconds(Time.deltaTime);
        }
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
