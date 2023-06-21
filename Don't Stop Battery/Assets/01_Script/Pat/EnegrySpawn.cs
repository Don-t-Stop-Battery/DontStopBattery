using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegrySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _ene;
    [SerializeField] private float _reSpawn;

    private void Start() {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn(){
        while(true){
            float rand = Random.Range(0.8f, 3f);
            rand *= 10;
            rand = (int)rand;
            rand /= 10;
            _reSpawn = rand;    
            Instantiate(_ene, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_reSpawn);
        }
    }
}
