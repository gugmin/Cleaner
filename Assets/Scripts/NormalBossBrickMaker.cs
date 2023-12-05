using UnityEngine;

public class NormalBossBrickMaker : MonoBehaviour
{

    public GameObject brick;

    public void RandomBrickSpawn(int bossMaxHP) // 매개변수로 boss 의 HP
    {
        if (bossMaxHP == 7)
        {
            for (int i = 0; i < 5; i++)
            {

                if (i % 2 == 1)
                {
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;
                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = 0.5f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
            }
        }
        else if (bossMaxHP == 5)
        {
            for (int i = 0; i < 5; i++)
            {

                if (!(i % 2 == 1))
                {
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;
                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = 0.5f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
            }
        } 
        else if (bossMaxHP == 3)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject newBrick = Instantiate(brick);
                newBrick.transform.parent = GameObject.Find("Bricks").transform;

                float x = (i % 5) * 1.2f - 2.4f;
                float y = 0.0f;
                newBrick.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}

