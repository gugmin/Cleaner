using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            print("∆–µÈ¥Í¿Ω");
            Destroy(transform.gameObject);
        }

        else if (collision.CompareTag("BottomWall"))
        {
            Destroy(transform.gameObject);
        }
    }
}
