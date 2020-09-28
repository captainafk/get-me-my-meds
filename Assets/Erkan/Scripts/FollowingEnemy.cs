using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : Enemy
{
    public Vector3 direction;

    public float followDistance;

    public Rigidbody2D myRigidbody;

    public float speed;

    public int rotNumber;
    public int rot;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Turn();

        transform.Translate(speed * Time.deltaTime, 0, 0);//sürekli hareket
        direction = player.transform.position - transform.position;//karakterin pozisyonundan kendi pozisyonumu çıkartıyorum

        if (Mathf.Abs(direction.x) < followDistance)
        {
            speed = 1;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//eğer pozisyon takip aralığından düşükse yani player
            //takip edliebilir yakınlıkta ise yönümüzü ona dönüyor
            myRigidbody.rotation = angle;
        }

        if (Mathf.Abs(direction.x) < 1)
        {
            speed = 0;
        }

        else { speed = 1; }
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Cologne"))
        {/*kolonyanın alanına girersek hastalık iyileşiyor*/
            ill = false;
        }

        if (other.gameObject.CompareTag("Turn"))
        {/*turn objesine temas edince rastgele sayı üretilir*/
            rotNumber = Random.Range(0, 3);
        }

        if (other.gameObject.CompareTag("Map"))
        {/*haritaya temas edince direkt arkasına döner*/
            myRigidbody.rotation = 180;
        }

    }
}
