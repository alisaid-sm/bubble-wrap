using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New Package", menuName = "Data/Package")]
public class PackageDefinition : ScriptableObject
{
    public string ID = Guid.NewGuid().ToString();
    public string packageName;
    public int weight;
    public int length;
    public int width;
    public int height;
    public int price;
    public int totalDimension;

    public GameObject prefab;
}
