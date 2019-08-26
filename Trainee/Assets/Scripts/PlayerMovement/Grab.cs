﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grab : MonoBehaviour
{
    public bool b_holding = false;
    public a_pickupItem _item;
    private bool _locked;
    [SerializeField] Transform _holdspot;

    public LayerMask m_LayerMask;

    public string retrieveItemID()
    {
        if (_item != null)
        {
            return _item.ID;
        }
        else
        {
            return "Empty";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && b_holding == false)
        {
            Collider2D[] hitcolliders2d = Physics2D.OverlapBoxAll(gameObject.transform.position, transform.localScale * 2, 0.0f, m_LayerMask);

            float distance = 999;

            for (int i = 0; i < hitcolliders2d.Length; i++)
            {
                //so long as obj is contains a pickup item
                if (hitcolliders2d[i].GetComponent<a_pickupItem>())
                {
                    if (distance > Vector3.Magnitude(hitcolliders2d[i].gameObject.transform.position - gameObject.transform.position))
                    {
                        distance = Vector3.Magnitude(hitcolliders2d[i].gameObject.transform.position - gameObject.transform.position);
                        _item = hitcolliders2d[i].GetComponent<a_pickupItem>();
                    }
                }
            }
            if (_item != null)
            {
                _item.gameObject.transform.parent = gameObject.transform;

                _item.body.gravityScale = 0;
                b_holding = true;
                _locked = true;
            }

        }

        else if (b_holding == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && _item != null)
            {
                _item.body.gravityScale = 1;
                _item.gameObject.transform.parent = null;
                _item = null;
                b_holding = false;
                _locked = false;
            }
        }

    }
    private void FixedUpdate()
    {
        if (b_holding)
        {
            _item.gameObject.transform.position = _holdspot.position;
        }
    }
}
