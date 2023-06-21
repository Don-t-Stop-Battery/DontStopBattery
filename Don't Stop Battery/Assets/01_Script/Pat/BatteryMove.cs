using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMove : MonoBehaviour
{
    [SerializeField] private int _batterySpeed;
    
    private void Start() {
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        while(true){
            if(transform.position.x < -17.89f){
                Destroy(gameObject, 1f);
            }
            transform.position += Vector3.left * _batterySpeed * Time.deltaTime;
            yield return null;
        }
    }
}
