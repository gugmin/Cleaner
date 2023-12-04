using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{

    private InputEvent controller;
    private Rigidbody2D paddleRigidbody;
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float speed { get; set; } = 5f;
    [SerializeField] private float size { get; set; } = 1f;
    private bool isHaste = false;
    private bool isPower = false;


    private void Awake()
    {
        controller = GetComponent<InputEvent>();
        paddleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movement);
    }

    // ----------------------------------------------------

    private void Move(Vector2 dir)
    {
        movement = dir;
    }

    private void ApplyMovement(Vector2 dir)
    {
        dir = dir * speed;
        paddleRigidbody.velocity = dir;
    }
    public void ResetPos()
    {
        transform.position = new Vector3(0, -4, 0);
    }


    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void IsHaste(float speed)
    {
        if (isHaste == false)
        {
            SetSpeed(speed);
            isPower = true;
        }
    }


    public float GetSize()
    {
        return this.size;
    }
    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, 0.3f, 0);
    }
    public void IsPower(float size)
    {
        if (isPower == false)
        {
            SetSize(size);
            isPower = true;
        }
    }
}
