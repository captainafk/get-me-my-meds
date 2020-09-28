using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueVirus : MonoBehaviour
{
    public float speed = 5.0f;

    private void OnEnable()
    {
        LeanTween.moveY(gameObject, 5.0f, speed).setLoopPingPong();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameMng.health -= 1;
        }
    }
}
