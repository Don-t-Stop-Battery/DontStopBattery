using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float se;

    private void Start() {
        Destroy(gameObject, 2f);
    }
    private void Update() {
        transform.position += Vector3.right * se * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Umm");
        }
        else{
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
