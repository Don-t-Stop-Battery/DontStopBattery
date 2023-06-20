using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegrySpawn : MonoBehaviour
{
    [SerializeField] GameObject ene;

    private void Start() {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn(){
        while(true){
            yield return new WaitForSeconds(1);
        }
    }
}
