using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject player;
    Vector3 _offset;
    Vector3 _velocity = Vector3.zero;
    public float smoothTime;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 _targetPosition = player.transform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _velocity, smoothTime);
    }
}
