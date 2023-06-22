using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] AudioSource ele;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] PolygonCollider2D po;
    [SerializeField] private int _obstacleSpeed;

    private void Awake() {
        ele = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        po = GetComponent<PolygonCollider2D>();
    }
    private void Start() {
        _obstacleSpeed = GameManager.instance.up;
        StartCoroutine(Move());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            ele.enabled = true;
            sp.enabled = false;
            po.enabled = false;
            StartCoroutine(Die());
        }
    }
    
    IEnumerator Die(){
        GameManager.instance.Energy += 30f;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    IEnumerator Move(){
        while(true){
            if(transform.position.x < -17.89f){
                Destroy(gameObject, 1f);
            }
            transform.position += Vector3.left * _obstacleSpeed * Time.deltaTime;
            yield return null;
        }
    }

}
