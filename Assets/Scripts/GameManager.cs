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
    // ���ӸŴ��� �̱���
    public static GameManager I;
    [SerializeField] private CameraMove cm;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject rtan;
    [SerializeField] private GameObject LeftUI;
    [SerializeField] private GameObject RightUI;
    public GameObject endPanel;
    public TMP_Text timeTxt;
    public TMP_Text scoreTxt;
    public TMP_Text maxScoreText;
    public TMP_Text thisScoreText;

    [SerializeField] Image TimeBar;
    public float maxTime;
    public float time;
    float score;
    public float maxScore;

    Scene scene;

    private void Awake()
    {
        I = this; //�̱���
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 0.0f;
    }

    void Start()
    {
        StartCoroutine(StartRound());
        time = maxTime;
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
            maxScoreText.text = "�ְ����� :" + score.ToString();
        }
        else if (score < maxScore)
        {
            thisScoreText.text = "�������� :" + score.ToString();
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
    public void RetryGame() //�ٽ��ϱ�
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene.name);
    }
    public void GoHomeBtn()  //����ȭ������ ���ư���
    {
        //���� �ǳ� �㶧 �ð� ��������� �ٽ� ������
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
    }
    public IEnumerator StartRound()
    {
        cm.StartRound();
        yield return new WaitForSecondsRealtime(2.0f);
        LeftUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(0, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1.0f;
    }
    public IEnumerator RoundClear()
    {
        //TODO:Ŭ���� UI �߰�
        Time.timeScale = 0.0f;
        LeftUI.transform.DOMove(new Vector3(-90, 0, 0), 1).SetUpdate(true);
        RightUI.transform.DOMove(new Vector3(90, 0, 0), 1).SetUpdate(true);
        yield return new WaitForSecondsRealtime(2.0f);
        cm.RoundClear();
        yield return new WaitForSecondsRealtime(2.0f);
    }
}
