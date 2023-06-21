using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    [SerializeField] private GameObject[] _ground; 
    
    private void Awake() {
        int rand = Random.Range(0, 3);
        Instantiate(_ground[rand], transform.position, Quaternion.identity);
    }
}
