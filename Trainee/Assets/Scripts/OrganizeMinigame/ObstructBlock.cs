using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ObstructBlock : MonoBehaviour
{
    //Component References
    Rigidbody2D rb2_body;
    PolygonCollider2D _collider;
    SpriteRenderer _renderer;

    //External Refs
    Camera _myCam;

    //vars
    bool im_overlapped;

    public List<GameObject> currentCollissions = new List<GameObject>();

    void Awake()
    {
        //Population
        rb2_body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<PolygonCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _myCam = Camera.main;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ObstructBlock>() && !currentCollissions.Contains(other.gameObject))
        {
            currentCollissions.Add(other.gameObject);

            _renderer.color = Color.red;

            im_overlapped = true;
        }
    }
    private Vector2 RetrieveMousePos()
    {
        Vector2 Mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return _myCam.ScreenToWorldPoint(Mousepos);
    }

    private void Update()
    {
        if (grabbed)
        {
            Vector3 desired = RetrieveMousePos() - rb2_body.position;

            rb2_body.AddForce(desired.normalized * 80, ForceMode2D.Force);
        }
    }
    bool grabbed;

    void OnMouseDown()
    {
        grabbed = true;
    }

    private void OnMouseUp()
    {
        grabbed = false;

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<ObstructBlock>())
        {
            currentCollissions.Remove(other.gameObject);


            if (currentCollissions.Count == 0)
            {
                _renderer.color = Color.green;
                im_overlapped = false;
            }
        }
    }

}
