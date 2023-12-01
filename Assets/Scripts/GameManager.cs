using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���ӸŴ��� �̱���
    public static GameManager I;

    public GameObject endPanel;
    public TMP_Text timeTxt;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;

    public float time;
    float score;
    public float maxScore;

    Scene scene;

    private void Awake()
    {
        I = this; //�̱���
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //���� �ð��� �����ִ� ���
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        //���ѽð� ���
        if (time <= 0)
        {
            //�ð� 0���� ǥ��
            timeTxt.text = time.ToString("0 : 00");
            GameEnd();
        }
        //���� �ٴڿ� �������� 1���� �ȳ�������

    }

    private void GameEnd()
    {
        Time.timeScale = 0f;
        endPanel.SetActive(true);

        if (score > maxScore)
        {
            maxScore = score;
            maxScoreText.text = "�ְ����� :" + score.ToString();
        }
        else if (score < maxScore)
        {
            thisScoreText.text = "�������� :" + score.ToString();
        }
    }
    public void RetryGame() //�ٽ��ϱ�
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene.name);
    }

    public void GoHomeBtn()  //����ȭ������ ���ư���
    {
        //���� �ǳ� �㶧 �ð� ��������� �ٽ� ������
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
    }
}
