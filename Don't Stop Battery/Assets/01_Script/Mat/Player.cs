using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float jumpPower = 8f;
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    bool isGround;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shotRaycast = GetComponent<ShotRaycast>();
    }
    private void Update()
    {
        Jump();
        GroundCheak();
    }

    private void Jump() //최영현 메서드
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)//최영현 if문
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
        }
        if (isGround == true)
        {
            animator.SetBool("Jump", false);
        }
        else if(isGround == false)
        {
            animator.SetBool("Jump", true);
        }
    }
    private void GroundCheak()
    {
        isGround = shotRaycast.ShotRay();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstaccle"))
        {
            GameManager.instance.Energy -= 5f;
        }
    }
}
