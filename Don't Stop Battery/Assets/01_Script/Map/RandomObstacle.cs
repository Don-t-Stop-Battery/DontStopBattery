using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacle;
    [SerializeField] private float _delayTime;
    private void Start() {
        StartCoroutine(Obstacle());
    }

    IEnumerator Obstacle(){
        while(true){
            int rand = Random.Range(0, 4);
            Instantiate(_obstacle[rand], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_delayTime);
        }
    }
}
