using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgContorller : MonoBehaviour
{

    // References

    Material material;

    // Variables
    public int xVel;

    Vector2 v2_offset;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        v2_offset.x = xVel;
        Debug.Log(v2_offset);

        if (xVel != 0)
        {
            material.mainTextureOffset += v2_offset * Time.deltaTime;
        }

    }
    Vector2 loopremover = new Vector2(10, 0);

    private void LateUpdate()
    {
        if (material.mainTextureOffset.x > 10)
        {
            material.mainTextureOffset -= loopremover;
        }
        else if (material.mainTextureOffset.x < -10)
        {
            material.mainTextureOffset += loopremover;
        }
        else
        {
            //its all good m8
        }
    }
}