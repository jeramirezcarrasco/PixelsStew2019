using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float orinialZoom;
    [SerializeField] float newZoom;
    [SerializeField] float smooth;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
       camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void StartOriginalZoom()
    {
        StartCoroutine("OriginalZoom");
    }

    public void StartNewZoom()
    {
        StartCoroutine("NewZoom");
    }

    IEnumerator OriginalZoom()
    {
        for (float i = newZoom; i < orinialZoom + 0.05f; i += 0.05f)
        {
            camera.orthographicSize = i;
            yield return new WaitForSeconds(smooth);
        }
    }

    IEnumerator NewZoom()
    {
        for (float i = orinialZoom; i > newZoom; i -= 0.05f)
        {
            camera.orthographicSize = i;
            yield return new WaitForSeconds(smooth);
        }
    }


}
