using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRigidbody;

    public int rot;
    public int rotNumber;


    public bool ill;

    public float contaminationDistance;
    public float distance;

    public GameObject player;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        ill = true;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        distance = Mathf.Sqrt((Mathf.Pow(Mathf.Abs(player.transform.position.x - this.transform.position.x), 2)
            + Mathf.Pow(Mathf.Abs(player.transform.position.y - this.transform.position.y), 2)));//karakterle aradaki mesafeyi ölçer
        if (ill && contaminationDistance > distance)
        {
            player.GetComponent<PlayerMovement>().health -= Time.deltaTime;//eğer hastalık lanına girdiysek zamanla canımız azalıyor
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);//sürekli hareket
        Turn();
    }

    public void Turn()
    {
        /*Oluşturulan sayıya göre yön belirlenir*/
        if (rotNumber == 0)
        {
            rot = 0;
        }
        if (rotNumber == 1)
        {
            rot = 90;
        }
        if (rotNumber == 2)
        {
            rot = 180;
        }
        if (rotNumber == 3)
        {
            rot = 270;
        }
        /*bizim yönümüz  o yöne eşitlenir*/
        myRigidbody.rotation = rot;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Turn"))
        {/*turn objesine temas edince rastgele sayı üretilir*/
            rotNumber = Random.Range(0, 3);
        }

        if (other.CompareTag("Cologne"))
        {/*kolonyanın alanına girersek hastalık iyileşiyor*/
            ill = false;
        }

        if (other.gameObject.CompareTag("Map"))
        {/*haritaya temas edince direkt arkasına döner*/
            myRigidbody.rotation = 180;
        }
    }

}
