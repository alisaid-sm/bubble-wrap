using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum ModifierType { Percentage, Constant }

[Serializable]
public class UpgradeModifier
{
    public int modifier;
    public ModifierType modifierType;
}

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Data/Upgrade")]
public class UpgradeStats : ScriptableObject
{
    public string ID = Guid.NewGuid().ToString();
    public string upgradeName;

    public UpgradeModifier upgradeModifier;
    public List<int> prices;
}
