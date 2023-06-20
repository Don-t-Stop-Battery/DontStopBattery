using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class San : MonoBehaviour
{
    [SerializeField] float jumpPower = 8f;
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    Rigidbody2D rig;    // pat
    bool isGround;
    bool isHit;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shotRaycast = GetComponent<ShotRaycast>();
        rig = GetComponent<Rigidbody2D>();  // pat
    }
    private void Update()
    {
        Jump();
        GroundCheak();
        Test();     //pat
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
        if(Input.GetKey(KeyCode.E) && _coolTime == false){
            Debug.Log("산데비스탄!!!!!!!!");
            rig.velocity = new Vector2(0, -30);
            StartCoroutine(Sandevistan());
        }
    }

    IEnumerator Sandevistan(){
        _coolTime = true;   
        yield return new WaitForSeconds(0.5f);
        _coolTime = false;
    }

}
