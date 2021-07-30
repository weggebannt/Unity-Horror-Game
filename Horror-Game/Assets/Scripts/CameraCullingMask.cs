using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCullingMask : MonoBehaviour
{
    public Camera cam;
    int normalMask;

    // Start is called before the first frame update
    void Start()
    {
        normalMask = cam.cullingMask;

        cam.cullingMask = 3 << 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
