using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpPower = 8f;
    [SerializeField] private float _sanPower = 30f;
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    bool isGround;
    bool isHit;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shotRaycast = GetComponent<ShotRaycast>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Jump();
        Dead();
    }
    private void FixedUpdate()
    {
        GroundCheak();
        Test();
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
            StartCoroutine(More());
            animator.SetBool("Hit", true);
            isHit = true;
            GameManager.instance.Energy -= 10f;
        }
        if (collision.CompareTag("Coin"))
        {
            GameManager.instance.Coin += 1;
            GameManager.instance.UpdateCoin();
            audioSource.Play();
            Destroy(collision.gameObject);
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

    void Dead()
    {
        if (GameManager.instance.IsDead == true)
        {
            animator.SetTrigger("Dead");
        }
    }
    private bool _coolTime = false;
    private void Test()
    {
        if (Input.GetKey(KeyCode.E) && _coolTime == false)
        {
            Debug.Log("»êµ¥ºñ½ºÅº!!!!!!!!");
            rigid.AddForce(Vector2.down * _sanPower, ForceMode2D.Impulse);
            //rigid.velocity = new Vector2(0, -27);
            StartCoroutine(Sandevistan());
        }
    }

    IEnumerator Sandevistan()
    {
        _coolTime = true;
        yield return new WaitForSeconds(0.3f);
        _coolTime = false;
    }

    IEnumerator More()
    {
        Time.timeScale = 0.25f;
        for (int i = 0; i < 3; i++)
        {
            Time.timeScale += 0.25f;
            yield return new WaitForSeconds(0.25f);
        }
        Time.timeScale = 1f;
    }
}
