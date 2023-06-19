using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _ObstacleSpeed;
    
    private void Start() {
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        while(true){
            if(transform.position.x < -17.89f){
                Destroy(gameObject, 1f);
            }
            transform.position += Vector3.left * _ObstacleSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
