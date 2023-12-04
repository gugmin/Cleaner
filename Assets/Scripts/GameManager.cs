using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    // 게임매니저 싱글톤
    public static GameManager I;
    [SerializeField] private CameraMove cm;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject rtan;
    [SerializeField] private GameObject LeftUI;
    [SerializeField] private GameObject RightUI;
    [SerializeField] private PaddleControl paddle;
    [SerializeField] private BallControl ball;
    [SerializeField] private BrickMaker brickmaker;
    public GameObject endPanel;
    public TMP_Text timeTxt;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;

    [SerializeField] Image TimeBar;
    public float maxTime;
    public float time;
    float score;
    public int currentRound;
    public float maxScore;

    Scene scene;

    private void Awake()
    {
        I = this; //싱글톤
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
    {
        //남은 시간을 보여주는 기능
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        //제한시간 기능
        if (time <= 0)
        {
            //시간 0으로 표기
            timeTxt.text = time.ToString("0 : 00");
            GameEnd();
        }
        //공이 바닥에 떨어져서 1개도 안남았을때
        if(TimeBar != null)
        {
            TimeBar.fillAmount = time / maxTime;
            rtan.GetComponent<RectTransform>().localPosition = new Vector3( TimeBar.fillAmount*(-70)+35, 0, 0);
        }

    }
    
    private void GameEnd()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);

        if (score > maxScore)
        {
            maxScore = score;
            maxScoreText.text = "최고점수 :" + score.ToString();
        }
        else if (score < maxScore)
        {
            thisScoreText.text = "현재점수 :" + score.ToString();
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
    public void RetryGame() //다시하기
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene.name);
    }
    public void GoHomeBtn()  //시작화면으로 돌아가기
    {
        //엔드 판넬 뜰때 시간 멈춰놓은거 다시 돌리기
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
    }
    public IEnumerator StartRound()
    {
        //TODO: 점수, 목숨 등 초기화할 정보 초기화하기

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
        //TODO:클리어 UI 추가
        Time.timeScale = 0.0f;
        print("호출됨");
        LeftUI.transform.DOMove(new Vector3(-10, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(10, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(2.0f);
        cm.RoundClear();
        yield return new WaitForSecondsRealtime(2.0f);
        paddle.ResetPos();
        ball.ResetPos();
        brickmaker.MakeBrick();
        brickmaker.isClear = false;
        StartCoroutine(StartRound());
    }
}
