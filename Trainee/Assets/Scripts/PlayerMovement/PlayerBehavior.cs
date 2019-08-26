using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField] bool AlternativeMove = true;

    [SerializeField] float MaxSpeed = 500;
    private bool m_canMove = true;

    //ObjRefs
    Rigidbody2D m_body;

    //ObjVariables
    float x_input;

    private Vector3 m_Velocity = Vector3.zero;

    [Range(0, .3f)] [SerializeField] private float m_faSmoothing = .187f;



    public bool CanMove { get => m_canMove; set => m_canMove = value; }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        //Populate Our Rigidbody
        m_body = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!AlternativeMove)
        {
            Movement();
        }
        else
        {
            inputListener();
        }
    }


    void Movement()
    {
        float _hInput = Input.GetAxis("Horizontal");
        Vector3 _moveVector = new Vector3(_hInput, 0f, 0f);
        transform.Translate(_moveVector * moveSpeed * Time.deltaTime);
    }



    private void FixedUpdate()
    {
        if (AlternativeMove)
        {
            phMovement();
        }
    }

    /// Physics based movement author:6ilberM
    private void phMovement()
    {
        if (m_body.velocity.magnitude < MaxSpeed)
        {
            Vector3 v3_targetVel = new Vector2(x_input * 10f, m_body.velocity.y);
            m_body.velocity = Vector3.SmoothDamp(m_body.velocity, v3_targetVel, ref m_Velocity, m_faSmoothing);
        }
    }

    ///author:6ilberM
    private void inputListener()
    {
        //As long as we can move Allow input to be sent to physics
        if (m_canMove)
        {
            x_input = Input.GetAxis("Horizontal");
        }
    }
}
