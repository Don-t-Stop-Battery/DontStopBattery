using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacle;
    [SerializeField] private float _delayTime;
    [SerializeField] private Transform[] _spawnPos;
    private void Start() {
        StartCoroutine(Obstacle());
    }

    IEnumerator Obstacle(){
        while(true){
            int spawnRand = Random.Range(0, 3);
            int rand = Random.Range(0, 4);
            int de = Random.Range(0, 101);
            if(de < 30){
                _delayTime = 0.7f;
            }
            else if(de < 50){
                _delayTime = 1;
            }
            else if(de < 80){
                _delayTime = 1.5f;
            }
            else{
                _delayTime = 2.2f;
            }
            Instantiate(_obstacle[rand], _spawnPos[spawnRand].position, Quaternion.identity);
            yield return new WaitForSeconds(_delayTime);
        }
    }
}
