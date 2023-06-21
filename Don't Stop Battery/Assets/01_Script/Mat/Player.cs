using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpPower = 8f;
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    bool isGround;
    bool isHit;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shotRaycast = GetComponent<ShotRaycast>();
    }
    private void Update()
    {
        Jump();
        GroundCheak();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
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
        if (collision.CompareTag("Obstaccle")&&isHit == false)
        {
            animator.SetBool("Hit", true);
            isHit = true;
            GameManager.instance.Energy -= 5f;
        }
        if (collision.CompareTag("Coin"))
        {
            GameManager.instance.Coin += 1;
            Destroy(collision);
        }
    }

    public void Hit()
    {
        StartCoroutine("HitEnemy");
    }
    public void HitStop()
    {
        StopCoroutine("HitEnemy");
    }
    IEnumerator HitEnemy()
    {
        animator.SetBool("Hit", false);
        int count = 0;

        while (count < 3)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(0.25f);
            count++;
        }
        isHit = false;
        HitStop();
    }

}
