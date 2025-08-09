using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main)
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0f, 180f, 0f); // flip if needed
        }
    }
}