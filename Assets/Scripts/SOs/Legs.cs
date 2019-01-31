using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Legs", menuName = "Items/Legs")]
public class Legs : ScriptableObject
{
    public string LegsName;
    public int DamageResistance;
    public string LegsDescription;

    public enum ArmorType
    {
        Normal,
        Medium,
        Heavy
    };
    public ArmorType armorType;
}
