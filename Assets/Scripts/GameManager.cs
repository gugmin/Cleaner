using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임매니저 싱글톤
    public static GameManager I;

    public GameObject endPanel;
    public TMP_Text timeTxt;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;

    public float time;
    float score;
    public float maxScore;

    private void Awake()
    {
        I = this; //싱글톤
    }

    void Start()
    {
        Time.timeScale = 1.0f;
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
            GameEnd();
        }
        //공이 바닥에 떨어져서 1개도 안남았을때

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
}
