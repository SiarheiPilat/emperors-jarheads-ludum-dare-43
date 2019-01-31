using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    public int Damage;
    public string WeaponDescription;

    public enum WeaponType
    {
        Standard,
        Laser,
    };

    public WeaponType weaponType;
}
