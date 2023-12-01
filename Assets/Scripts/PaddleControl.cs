using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{

    private InputEvent controller;
    private Rigidbody2D paddleRigidbody;
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float speed = 5f;

    [SerializeField] private float size = 1.5f;


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
}
