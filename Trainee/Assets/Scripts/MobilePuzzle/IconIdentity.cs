using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconIdentity : MonoBehaviour
{
    
    public int id;
    private Color iniCol;
    [Header("Color Identity")]
    public Color col;
    public float speed;

    private void Start()
    {
        iniCol = GetComponent<SpriteRenderer>().color;
    }


    public void ChangeColor()
    {
        //GetComponent<SpriteRenderer>().color = Color.Lerp(iniCol, col, Mathf.PingPong(Time.time, 1));
        GetComponent<SpriteRenderer>().color = col;
        Debug.Log("Changing Color");
    }

    public void ResetColor()
    {
        //GetComponent<SpriteRenderer>().color = Color.Lerp(col,iniCol, Mathf.PingPong(Time.time, 1));
        GetComponent<SpriteRenderer>().color = iniCol;
    }

    
}
