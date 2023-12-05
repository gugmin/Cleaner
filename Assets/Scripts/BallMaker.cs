using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMaker : MonoBehaviour
{
    public Ball ball;

    void Start()
    {
        ReSpawn();
    }

    public void ReSpawn()
    {
        Ball newBall = Instantiate(ball);
        newBall.transform.parent = GameObject.Find("Balls").transform;
        newBall.ResetPos();
        newBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}