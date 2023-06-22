using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpPower = 8f;
    [SerializeField] private float _sanPower = 30f;
    [SerializeField] Image bar;
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    SpriteRenderer spriteRenderer;
    AudioSource[] audioSource;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Bullet12;
    bool isGround;
    bool isHit;
    bool powerOn = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shotRaycast = GetComponent<ShotRaycast>();
        audioSource = GetComponents<AudioSource>();
    }

    private void Update()
    {
        Jump();
        Dead();
        Q();
        Power();
    }

    private void Power()
    {
        if(Input.GetKeyDown(KeyCode.P) && powerOn == false && GameManager.instance.Coin >= 100){
            audioSource[3].Play();
            powerOn = true;
            animator.SetTrigger("Power");
            StartCoroutine("Boom");
            GameManager.instance.Coin -= 100;
            GameManager.instance.UpdateCoin();
            GameManager.instance.Goodpower();
            isHit = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && powerOn == true){
            powerOn = false;
            animator.SetTrigger("Powerdown");
            StopCoroutine("Boom");
            GameManager.instance.oldpower();
            isHit = false;
        }
    }

    IEnumerator Boom(){
        while(true){
            yield return new WaitUntil(() => Input.GetKey(KeyCode.Mouse0) && powerOn == true);
            animator.SetTrigger("BangOn");
            yield return new WaitForSeconds(0.27f);
        }
    }

    IEnumerator Boom12(){
        while(true){
            if(Input.GetKey(KeyCode.Mouse1)){
                animator.SetBool("abc", true);
                Instantiate(Bullet12, transform.position + new Vector3(0.4f, 0.7f, 0), Quaternion.identity);
                yield return new WaitForSeconds(0.27f);
            }
            else{
                animator.SetBool("abc", false);
            }
            yield return null;
        }
    }

    public void BangBOO(){
        Instantiate(Bullet, transform.position + new Vector3(0.4f, 0.7f, 0), Quaternion.identity);
    }

    private void Q()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            if(GameManager.instance.Coin > 0){
                GameManager.instance.Coin--;
                GameManager.instance.UpdateCoin();
                audioSource[2].Play();
            }
        }
    }

    private void FixedUpdate()
    {
        GroundCheak();
        Sande();
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
            bar.color = new Color(1, 0, 0, 1);
            StartCoroutine(Red());
            animator.SetBool("Hit", true);
            isHit = true;
            audioSource[1].Play();
            GameManager.instance.Energy -= 10f;
        }
        if (collision.CompareTag("Coin"))
        {
            GameManager.instance.Coin += 1;
            GameManager.instance.UpdateCoin();
            audioSource[0].Play();
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
    private void Sande()
    {
        if (Input.GetKey(KeyCode.E) && _coolTime == false)
        {
            Debug.Log("산데비스탄!!!");
            rigid.AddForce(Vector2.down * _sanPower, ForceMode2D.Impulse);
            StartCoroutine(Sandevistan());
        }
    }

    IEnumerator Sandevistan()
    {
        _coolTime = true;
        yield return new WaitForSeconds(0.17f);
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
    IEnumerator Red()
    {
        yield return new WaitForSeconds(0.3f);
        bar.color = new Color(0, 1, 0.3859544f, 1);
    }

}