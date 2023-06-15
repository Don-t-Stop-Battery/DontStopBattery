using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float jumpPower = 10f;
    Animator animator;
    Rigidbody2D rigid;
    ShotRaycast shotRaycast;
    bool ground;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shotRaycast = GetComponent<ShotRaycast>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground == false)
        {
            StartCoroutine("Jump");
        }
        GroundCheak();
    }

    IEnumerator Jump()
    {
        animator.SetBool("Jump", true);
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        yield return null;
    }
    private void GroundCheak()
    {
        ground = shotRaycast.Shotray();
        animator.SetBool("Jump", false);
    }
}
