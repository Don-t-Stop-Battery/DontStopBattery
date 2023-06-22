using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] public int _obstacleSpeed;
    private void Start() {
        _obstacleSpeed = GameManager.instance.up;
        StartCoroutine(Move());
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
