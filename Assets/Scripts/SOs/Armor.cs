using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="armor", menuName ="Items/Armor")]
public class Armor : ScriptableObject
{
    public string ArmorName;
    public int DamageResistance;
    public string ArmorDescription;

    public enum ArmorType
    {
        Normal,
        Medium,
        Heavy
    };
    public ArmorType armorType;

}
