using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool ill;

    public float contaminationDistance;
    public float distance;

    public GameObject player;
    void Start()
    {
        ill = true;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        distance = Mathf.Sqrt((Mathf.Pow(Mathf.Abs(player.transform.position.x - this.transform.position.x), 2)
            + Mathf.Pow(Mathf.Abs(player.transform.position.y - this.transform.position.y), 2)));
        if (ill && contaminationDistance > distance)
        {
            player.GetComponent<PlayerMovement>().health -= Time.deltaTime;//eğer hastalık lanına girdiysek zamanla canımız azalıyor
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Cologne"))
        {/*kolonyanın alanına girersek hastalık iyileşiyor*/
            ill = false;
        }
    }
}
