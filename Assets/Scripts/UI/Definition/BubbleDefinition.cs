using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bubble", menuName = "Data/Bubble")]
public class BubbleDefinition : ScriptableObject
{
    public string type;
    public int maxStretch;
    public int maxWeight;
    public int price;
}
