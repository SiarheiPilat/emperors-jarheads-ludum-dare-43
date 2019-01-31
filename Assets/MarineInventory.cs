using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 1. Equipping/unequipping items.
/// 2. Providing info for HUD.
/// </summary>

public class MarineInventory : MonoBehaviour
{

    public GameObject Helmet;
    public GameObject Torso;
    public GameObject HandL1, HandL2;
    public GameObject HandR1, HandR2;
    public GameObject LegL1, LegL2, LegL3;
    public GameObject LegR1, LegR2, LegR3;
    public GameObject Weapon;

    public GameObject HUDUI;

    private BoxCollider2D boxCollider2D;

    public TextMeshProUGUI marineName;
    public TextMeshProUGUI marineHealth;
    public TextMeshProUGUI weapon;
    public TextMeshProUGUI weaponStats;
    public TextMeshProUGUI helmet;
    public TextMeshProUGUI helmetStats;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI armorStats;
    public TextMeshProUGUI legs;
    public TextMeshProUGUI legsStats;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnMouseOver()
    {
        HUDUI.SetActive(true);
        UpdateHUD();
    }

    void OnMouseExit()
    {
        HUDUI.SetActive(false);
    }

    public void UpdateHUD()
    {
        // here I need to move the HUD
        marineName.text = GetComponent<ContainerMarine>().marine.MarineName;
        marineHealth.text = GetComponent<health>().HP + " HP";
        weapon.text = Weapon.GetComponent<ContainerWeapon>().weapon.WeaponName + ", " + Weapon.GetComponent<ContainerWeapon>().weapon.Damage.ToString() + " DMG";
        weaponStats.text = Weapon.GetComponent<ContainerWeapon>().weapon.WeaponDescription;
        helmet.text = Helmet.GetComponent<ContainerHelmet>().helmet.HelmetName;
        helmetStats.text = Helmet.GetComponent<ContainerHelmet>().helmet.HelmetDescription;
        armor.text = Torso.GetComponent<ContainerArmor>().armor.ArmorName;
        armorStats.text = Torso.GetComponent<ContainerArmor>().armor.ArmorDescription;
        legs.text = LegL1.GetComponent<ContainerLegs>().legs.LegsName;
        legsStats.text = LegL1.GetComponent<ContainerLegs>().legs.LegsDescription;

    }

    public void EquipNew(GameObject slot, GameObject replacement)
    {
        slot.GetComponent<SpriteRenderer>().sprite = replacement.GetComponent<SpriteRenderer>().sprite;
    }
}
