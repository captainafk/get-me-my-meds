using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenVirus : MonoBehaviour
{
    public float speed = 2.0f;

    private void OnEnable()
    {
        LeanTween.rotateAround(gameObject, Vector3.forward, 360, 2.5f).setLoopClamp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameMng.health -= 1;
        }
    }
}
