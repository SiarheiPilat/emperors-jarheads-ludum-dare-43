using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Helmet", menuName = "Items/Helmet")]
public class Helmet : ScriptableObject
{
    public string HelmetName;
    public int DamageResistance;
    public string HelmetDescription;


    public enum ArmorType
    {
        Normal,
        Medium,
        Heavy
    };
    public ArmorType armorType;
}
