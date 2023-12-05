using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMaker : MonoBehaviour
{
    // Brick 의 total 수로 난이도 조절 ? 
    //[SerializeField] private int totalBrickCnt = 35;

    public GameObject brick;
    public bool isClear = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0&&!isClear)
        {
            isClear = true;
            StartCoroutine(GameManager.I.RoundClear());
        }
    }

    public void MakeEasyBrick(int round)
    {
        switch (round)
        {
            case 1:
                for (int i = 0; i < 25; i++)
                {
                    if (i % 2 == 1)
                        continue;
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;

                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = (i / 5) * 0.5f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
                break;
            case 2:
                for (int i = 0; i < 25; i++)
                {
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;

                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = (i / 5) * 0.5f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
                break;
            default:
                for (int i = 0; i < 25; i++)
                {
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;

                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = (i / 5) * 0.5f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
                break;

        }
    }
}
