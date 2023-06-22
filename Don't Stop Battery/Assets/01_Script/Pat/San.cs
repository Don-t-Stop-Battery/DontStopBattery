using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class San : MonoBehaviour
{
    [SerializeField] float jumpPower = 8f;
    [SerializeField] private float _sanPower = 30f; //pat
    [SerializeField] Image bar;
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
    }

    //pat
    private void FixedUpdate() {
        GroundCheak();
        Sande();     
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            Debug.Log("???");
            isGround = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
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
        //_isJump = isGround;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstaccle")&&isHit == false)
        {
            Debug.Log("피격");
            bar.color = new Color(1, 0, 0, 1);
            StartCoroutine(Red());
            StartCoroutine(More());
            animator.SetBool("Hit", true);
            isHit = true;
            GameManager.instance.Energy -= 5f;
        }
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("코인");
            GameManager.instance.Coin += 1;
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

            // Pat
    private bool _coolTime = false;
    private void Sande(){
        if(Input.GetKey(KeyCode.E) && _coolTime == false){
            Debug.Log("산데비스탄!!!!!!!!");
            rigid.AddForce(Vector2.down * _sanPower, ForceMode2D.Impulse);
            StartCoroutine(Sandevistan());
        }   
    }

    IEnumerator Sandevistan(){
        _coolTime = true;   
        yield return new WaitForSeconds(0.3f);
        _coolTime = false;
    }

    IEnumerator More()
    {
        Time.timeScale = 0.25f;
        for(int i = 0; i < 3; i++){
            Time.timeScale += 0.25f;
            yield return new WaitForSeconds(0.25f);
        }
        Time.timeScale = 1f;
    }

    IEnumerator Red(){
        yield return new WaitForSeconds(0.3f);
        bar.color = new Color(0, 1, 0.3859544f, 1);
    }

}
