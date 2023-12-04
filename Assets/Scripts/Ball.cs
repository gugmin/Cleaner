using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private InputEvent controller;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private float speed;
    private PaddleControl paddle;
    bool isStart = false;
    float mag;
    Animator anim;
    private void Awake()
    {
        controller = GetComponent<InputEvent>();
        controller.OnClickEvent += Click;
        paddle = GameManager.I.getPaddle();
    }
    void Start()
    {
    }
    private void FixedUpdate()
    {
        if (!isStart)
        {
            transform.position = paddle.gameObject.transform.position + new Vector3(0, 0.5f, 0);
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
    private void Click()
    {
        if (!isStart)
            ballRigidbody.AddForce(Vector2.up * speed);
        isStart = true;
    }
    public void ResetPos()
    {
        isStart = false;
        ballRigidbody.velocity = Vector2.zero;
        transform.position = paddle.gameObject.transform.position + new Vector3(0, 0.5f, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ?¬Ö? ?¥å??????
        if (collision.collider.CompareTag("Paddle"))
        {
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.AddForce((transform.position - collision.transform.position).normalized * speed); // ?? - ?¬Ö? : ?¬Ö?->?? ????
        }
        else if (collision.collider.CompareTag("BottomWall"))
        {
            isStart = false;
            GameManager.I.isDead = true;
            GameManager.I.life -= 1;
            GameManager.I.LostLife();
            //anim.SetBool("IsDead", true);
            ballRigidbody.velocity = Vector2.zero;
            Destroy(gameObject);
            //ball.SetActive(false);
        }
    }
}
