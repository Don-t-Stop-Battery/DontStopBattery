using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public int a = 17;

    private void Awake() {
        a = 17;
    }
    private void Start() {
        a = 17;
        StartCoroutine(ad());
    }

    IEnumerator ad(){
        yield return new WaitForSeconds(12.5f);
        a += 2;
    }
}
