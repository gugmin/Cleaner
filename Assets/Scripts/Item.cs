using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "paddle")
        {
            print("æ∆¿Ã≈€ ¥Í¿Ω");
        }
        // test
    }
}
