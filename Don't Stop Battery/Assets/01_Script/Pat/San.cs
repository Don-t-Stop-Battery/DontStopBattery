using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class San : MonoBehaviour
{
    [SerializeField] float jumpPower = 8f;
    [SerializeField] private float _sanPower = 30f; //pat
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    bool isGround;
    bool isHit;
    
    private bool _isJump;

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
        /* Jump();
        GroundCheak();
        Test();     //pat */
        Jump();
    }

    //pat
    private void FixedUpdate() {
        GroundCheak();
        Test();     
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstaccle")&&isHit == false)
        {
            Debug.Log("피격");
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
    private void Test(){
        if(isGround == false && _isJump == true){
            rigid.velocity = new Vector2(0, 0);
        }
        if(Input.GetKey(KeyCode.E) && _coolTime == false){
            Debug.Log("산데비스탄!!!!!!!!");
            rigid.AddForce(Vector2.down * _sanPower, ForceMode2D.Impulse);
            //rigid.velocity = new Vector2(0, -27);
            StartCoroutine(Sandevistan());
        }   
    }

    IEnumerator Sandevistan(){
        _coolTime = true;   
        yield return new WaitForSeconds(0.3f);
        _coolTime = false;
    }

}
