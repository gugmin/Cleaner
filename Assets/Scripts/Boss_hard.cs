using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boss_hard : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Mirror;
    [SerializeField] private SpriteRenderer vport;
    public GameObject bricks;
    //bool firstPattern = false;
    //bool secondPattern = false;
    //bool thirdPattern = false;
    [SerializeField ]float ballDamage;

    private void Start()
    {
        vport.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag( "Ball"))
        {
            GameManager.I.score++;
        }
    }

    
}
