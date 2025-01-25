using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;
    public Camera cameraViewer;

    void Update()
    {
        if (cameraViewer.enabled)
        {
            pos = Input.mousePosition;
            pos.z = offset;
            transform.position = cameraViewer.ScreenToWorldPoint(pos);
        }
    }
}
