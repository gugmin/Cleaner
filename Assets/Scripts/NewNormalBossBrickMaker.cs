using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewNormalBossBrickMaker : MonoBehaviour
{

    public GameObject brick;
    public ParticleSystem[] ps;

    bool firstPattern = false;
    bool secondPattern = false;
    bool thirdPattern = false;

    public void RandomBrickSpawn(float bossHP) // 매개변수로 boss 의 HP
    {
        if (bossHP < 0.8f && !firstPattern)
        {
            firstPattern = true;
            for (int i = 0; i < 5; i++)
            {

                if (i % 2 == 1)
                {
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;
                    newBrick.GetComponent<Brick>().HP = 2;
                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = 0.0f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
            }
        }
        else if (bossHP < 0.5f && !secondPattern)
        {
            secondPattern = true;
            for (int i = 0; i < ps.Length; i++)
                ps[i].Play();

            for (int i = 0; i < 5; i++)
            {
                if (!(i % 2 == 1))
                {
                    GameObject newBrick = Instantiate(brick);
                    newBrick.transform.parent = GameObject.Find("Bricks").transform;
                    newBrick.GetComponent<Brick>().HP = 2;
                    float x = (i % 5) * 1.2f - 2.4f;
                    float y = 0.0f;
                    newBrick.transform.position = new Vector3(x, y, 0);
                }
            }
        }
        else if (bossHP < 0.2f && !thirdPattern)
        {
            thirdPattern = true;
            for (int i = 0; i < 5; i++)
            {
                GameObject newBrick = Instantiate(brick);
                newBrick.transform.parent = GameObject.Find("Bricks").transform;
                newBrick.GetComponent<Brick>().HP = 2;
                float x = (i % 5) * 1.2f - 2.4f;
                float y = -0.5f;
                newBrick.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}

