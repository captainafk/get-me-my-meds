using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedVirus : MonoBehaviour
{
    public float speed = 2.0f;

    private void OnEnable()
    {
        LeanTween.moveX(gameObject, 5.0f, speed).setLoopPingPong();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameMng.health -= 1;
        }
    }
}
