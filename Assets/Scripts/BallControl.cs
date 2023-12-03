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
    public GameObject ball;
    [SerializeField] private float speed;
    Animator anim;

    private Vector2 direction = Vector2.zero;
    private Vector2 initPos;
    float mag;
    bool isStart = false;

    private void Awake()
    {
        controller = GetComponent<InputEvent>();
        ballRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initPos.x = paddle.transform.position.x;
        initPos.y = paddle.transform.position.y + 0.5f;
    }


    void Start()
    {
        ReSpawn();
    }

    private void FixedUpdate()
    {
        if (!isStart)
        {
            transform.position = paddle.transform.position + new Vector3(0, 0.5f, 0);
        }
        //MoveBall(direction);
        mag = ballRigidbody.velocity.magnitude;
        //print(mag);
        if (mag < 4f || mag > 5f)
        {
            Vector2 dir = ballRigidbody.velocity.normalized;
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.AddForce(dir * speed);
        }
    }
    public void ReSpawn()
    {
        controller.OnClickEvent += Click;
        transform.position = initPos;
        ballRigidbody.velocity = Vector2.zero;
        ball.SetActive(true);
    }

    private void Click()
    {
        if (!isStart)
            ballRigidbody.AddForce(Vector2.up * speed);
        isStart = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 패들에 부딪힐경우
        if (collision.collider.CompareTag("Paddle"))
        {
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.AddForce((transform.position - collision.transform.position).normalized * speed); // 공 - 패들 : 패들->공 벡터
        }
        else if (collision.collider.CompareTag("BottomWall"))
        {
            isStart = false;
            GameManager.I.isDead = true;
            GameManager.I.life -= 1;
            GameManager.I.LostLife();
            anim.SetBool("IsDead", true);
            ballRigidbody.velocity = Vector2.zero;
            ball.SetActive(false);
        }
    }
}
