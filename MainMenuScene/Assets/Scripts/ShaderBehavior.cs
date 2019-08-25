using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderBehavior : MonoBehaviour
{
    Material _shaderMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        _shaderMaterial = GetComponent<Image>().material;
        Debug.Log(_shaderMaterial);
    }


    public void OnPointerEnter()
    {
        _shaderMaterial.SetFloat("_shaderRunCheck",1f);
        Debug.Log("IN");
    }

    public void OnPointerExit()
    {
        _shaderMaterial.SetFloat("_shaderRunCheck", 0f);
        Debug.Log("OUT");
    }
}
