using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���ӸŴ��� �̱���
    public static GameManager I;
    public BallControl ballControl;
    public GameObject endPanel;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;
    public GameObject ball;
    public int life;
    public int maxLife;
    public SpriteRenderer[] lifeSprite;
    public int score;
    public float maxScore;
    public bool isDead = false;

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
        scoreTxt.text = "���ھ� : " + score.ToString("");
     
        if (isDead == true)
        {
            isDead = false;
            ballControl.ReSpawn();
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
            maxScoreText.text = "�ְ����� : " + score.ToString();
        }
        else if (score < maxScore)
        {
            thisScoreText.text = "�������� : " + score.ToString();
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
