using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed;
    public float xMoveSpeed;
    public float ySpeed;
    public float yMoveSpeed;

    public bool cologneAttack;
    public bool maskAttack;

    public GameObject cologneAttackArea;
    public GameObject maskAttackArea;
    public GameObject CanvasController;

    public List<GameObject> enemies;

    public int breadCoolingTime;

    public bool death;

    public float health;

    public Animator animator;
    void Start()
    {
        cologneAttackArea.SetActive(false);
        maskAttackArea.SetActive(false);
    }

    void Update()
    {
        if (health < 0)
        {
            CanvasController.GetComponent<CanvasController>().Death();
        }
        
        Movement();
        Attack();
    }

    private void FixedUpdate()
    {
        // This is in FixedUpdate in order to prevent sprite from bouncing
        transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
    }

    public void Movement()
    {
        bool isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            ySpeed = yMoveSpeed;
            animator.SetFloat("Vertical", 1.0f);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ySpeed = -yMoveSpeed;
            animator.SetFloat("Vertical", -1.0f);
            isMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            ySpeed = 0;
            animator.SetFloat("Vertical", 0f);
        }
        
        
        if (Input.GetKey(KeyCode.D))
        {
            xSpeed = xMoveSpeed;
            animator.SetFloat("Horizontal", 1.0f);
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xSpeed = -xMoveSpeed;
            animator.SetFloat("Horizontal", -1.0f);
            isMoving = true;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            xSpeed = 0;
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Speed", 0f);
        }

        if (isMoving)
        {
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cologne"))
        {
            cologneAttack = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Mask"))
        {
            maskAttack = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Bread"))
        {
            InvokeRepeating("BreadTimer", 0,1);
            Destroy(other.gameObject);
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.C) && cologneAttack)
        {
            cologneAttackArea.SetActive(true);
            Invoke("CologneDeactiver", 3);
        }
        /*
        if (Input.GetKeyUp(KeyCode.C) || !cologneAttack)
        {
            cologneAttackArea.SetActive(false);
        }
        */

        if (Input.GetKeyDown(KeyCode.M) && maskAttack)
        {
            maskAttackArea.SetActive(true);
        }
        /*
        if (Input.GetKeyUp(KeyCode.C) || !maskAttack)
        {
            maskAttackArea.SetActive(false);
        }*/
    }

    public void BreadTimer()
    {
        breadCoolingTime -= 1;
        //Debug.Log(breadCoolingTime);
    }

    public void HealthDowner()
    {
        health -= 3;
    }

    public void CologneDeactiver()
    {
        cologneAttackArea.SetActive(false);
    }
}
