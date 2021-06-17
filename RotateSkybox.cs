using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public Material skybox;

    // Update is called once per frame
    void Update()
    {
        skybox.SetFloat("_Rotation", Time.time * 0.4f);
    }
}
