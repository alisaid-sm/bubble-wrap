using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PointName { Computer }
public class Point : MonoBehaviour
{
    public Transform cameraPosition;
    public bool canRotate = false;
    public PointName pointName;
}
