using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private float what;

    void Start()
    {
        StartCoroutine(BackMove());
    }

    IEnumerator BackMove(){
        while(true){
            if(transform.position.x < what){
                transform.position = new Vector3(0, 0, 0);
            }
            transform.position += Vector3.left * _speed * Time.deltaTime;
            yield return null;
        }
    }
}
