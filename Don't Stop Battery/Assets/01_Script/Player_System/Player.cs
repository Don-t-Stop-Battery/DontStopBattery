using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _myRigid;
    private Vector2 _dir;
    
    private void Awake() {
        _myRigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
    }


}
