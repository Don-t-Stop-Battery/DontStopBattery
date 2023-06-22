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
            float de = Random.Range(0.65f,1.5f);
            de *= 10;
            de = (int)de;
            de /= 10;
            _delayTime = de;
            Instantiate(_obstacle[rand], _spawnPos[spawnRand].position, Quaternion.identity);
            yield return new WaitForSeconds(_delayTime);
        }
    }
}
