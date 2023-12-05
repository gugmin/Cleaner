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
    [SerializeField] private PaddleControl paddle;
    [SerializeField] private BallMaker ball;
    [SerializeField] private BrickMaker brickmaker;
    public GameObject Shield;
    public GameObject endPanel;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;
    //gm
    public GameObject _ball;
    public int life;
    public int maxLife;
    public SpriteRenderer[] lifeSprite;
    public int score;
    public int maxScore;
    //jw
    [SerializeField] Image TimeBar;
    public float maxTime;
    public float time;
    public int currentRound;
    public bool isDead = false;

    Scene scene;

    private void Awake()
    {
        I = this;
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 0.0f;
        currentRound = 1;
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
    }
    public PaddleControl getPaddle()
    {
        return paddle;
    }
}
