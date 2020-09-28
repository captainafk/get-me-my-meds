using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private void OnEnable()
    {
        LeanTween.rotateAround(gameObject, Vector3.forward, 360, 2.5f).setLoopClamp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameMng.score += 1;
            Destroy(gameObject);
        }
    }
}
