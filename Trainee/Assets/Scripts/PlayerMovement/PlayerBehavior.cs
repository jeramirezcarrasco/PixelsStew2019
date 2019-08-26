using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;
    private bool FacingRight;
    float Horizontal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        float Horizontal = Input.GetAxis("Horizontal");
        if (Horizontal > 0)
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x = -1;
            transform.localScale = characterScale;

        }
        else if (Horizontal < 0)
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x = 1;
            transform.localScale = characterScale;

        }
    }


    void Movement()
    {
        float _hInput = Input.GetAxis("Horizontal");
        Vector3 _moveVector = new Vector3(_hInput, 0f, 0f);
        transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }

    private void flip()
    {

    }

    
}
