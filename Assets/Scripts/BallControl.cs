using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallControl : MonoBehaviour
{
    private InputEvent controller;
    private Rigidbody2D ballRigidbody;
    public GameObject paddle;
    [SerializeField] private float speed;

    private Vector2 direction = Vector2.zero;
    private Vector2 initPos;
    float mag;
    bool isStart = false;

    private void Awake()
    {
        controller = GetComponent<InputEvent>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        ResetPos();
    }


    void Start()
    {
        controller.OnClickEvent += Click;
    }

    private void FixedUpdate()
    {
        if (!isStart)
        {
            transform.position = paddle.transform.position + new Vector3(0, 0.5f, 0);
        }
        //MoveBall(direction);
        mag = ballRigidbody.velocity.magnitude;
        print(mag);
        if (mag < 4f || mag > 5f)
        {
            Vector2 dir = ballRigidbody.velocity.normalized;
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.AddForce(dir * speed);
        }
    }

    private void Click()
    {
        if (!isStart)
            ballRigidbody.AddForce(Vector2.up * speed);
        isStart = true;
    }
    private void ResetPos()
    {
        isStart = false;
        ballRigidbody.velocity = Vector2.zero;
        transform.position = paddle.transform.position + new Vector3(0, 0.5f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 패들에 부딪힐경우
        if (collision.collider.CompareTag("Paddle"))
        {
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.AddForce((transform.position - collision.transform.position).normalized * speed); // 공 - 패들 : 패들->공 벡터
        }
    }
}
