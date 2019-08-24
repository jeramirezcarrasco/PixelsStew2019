using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        float _hInput = Input.GetAxis("Horizontal");
        Vector3 _moveVector = new Vector3(_hInput, 0f, 0f);
        transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }

    
}
