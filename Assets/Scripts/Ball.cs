using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private InputEvent controller;
    [SerializeField] private Rigidbody2D ballRigidbody;
    //[SerializeField] private float speed;
    [SerializeField] ParticleSystem ps;
    private PaddleControl paddle;
    private float speed { get; set; } = 300f;
    private float size { get; set; } = 0.2f;
    

    bool isStart = false;
    float mag;
    private void Awake()
    {
        controller = GetComponent<InputEvent>();
        controller.OnClickEvent += Click;
        paddle = GameManager.I.GetPaddle();
    }

    private void Start()
    {
        SetSize(size);
    }

    private void FixedUpdate()
    {
        if (!isStart)
        {
            transform.position = paddle.gameObject.transform.position + new Vector3(0, 0.5f, 0);
        }
        
        mag = ballRigidbody.velocity.magnitude;
        if (mag < 4f || mag > 5f)
        {
            Vector2 dir = ballRigidbody.velocity.normalized;
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.AddForce(dir * speed);
        }
        
    }
    public bool GetIsStart()
    {
        return isStart;
    }
    public void SetIsStart(bool type)
    {
        this.isStart = type;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
        if (this.speed > 600) this.speed = 600;
        if (this.speed < 150) this.speed = 150;
    }


    

    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, 0);
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
        transform.position = paddle.gameObject.transform.position + new Vector3(0, 0.8f, 0);
    }
    public ParticleSystem getParticle()
    {
        return ps;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BottomWall"))
        {
            SoundManager.I.PlayDieSound();
            ps.Play();

            GameManager.I.GetBalls().ballCount--;
            ballRigidbody.velocity = Vector2.zero;
            if (GameManager.I.GetBalls().ballCount == 0)
            {
                GameManager.I.GetItems().DestroyAllChild();
                if (GameManager.I.isAngel && GameManager.I.life == 1)
                {
                    GameManager.I.GetBalls().ballCount++;
                    GameManager.I.isAngel = false;
                    StartCoroutine(GameManager.I.AngelRespawn(gameObject));
                    return;
                }
                GameManager.I.isDead = true;
                GameManager.I.life -= 1;
                GameManager.I.LostLife();
            }
            Destroy(gameObject, 2f);
        }
        else
        {
            SoundManager.I.PlayBallSound();
            if (collision.collider.CompareTag("Paddle"))
            {
                ballRigidbody.velocity = Vector2.zero;
                ballRigidbody.AddForce((transform.position - collision.transform.position).normalized * speed);   
            }
            else if (collision.collider.CompareTag("Shield"))
            {
                ballRigidbody.velocity = Vector2.zero;
                ballRigidbody.AddForce((transform.position - collision.transform.position).normalized * speed);
                GameManager.I.Shield.SetActive(false);
            }

        }
    }
}
