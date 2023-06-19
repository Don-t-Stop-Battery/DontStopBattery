using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMove : MonoBehaviour
{
    [SerializeField] private int _speed;

    void Start()
    {
        StartCoroutine(BackMove());
    }

    IEnumerator BackMove(){
        while(true){
            transform.position += Vector3.left * _speed * Time.deltaTime;
            yield return null;
        }
    }
}
