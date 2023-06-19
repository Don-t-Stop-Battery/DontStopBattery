using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private int _groundSpeed;
    
    private void Start() {
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        while(true){
            if(transform.position.x < -17.89f){
                transform.position = new Vector3(0, 0, 0);
                //Destroy(gameObject, 1f);
            }
            transform.position += Vector3.left * _groundSpeed * Time.deltaTime;
            yield return null;
        }
    }

}
