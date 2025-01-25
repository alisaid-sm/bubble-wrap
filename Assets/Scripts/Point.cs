using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PointName { Computer, None }
public class Point : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform packagePosition;
    public bool canRotate = false;
    public PointName pointName;
}
