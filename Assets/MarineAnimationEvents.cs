using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineAnimationEvents : MonoBehaviour
{
    public GameObject muzzleFlash, gun;

    public void ActivateMuzzleFlash()
    {
        muzzleFlash.SetActive(true);
    }

    public void DeactivateMuzzleFlash()
    {
        muzzleFlash.SetActive(false);
    }

    public void DoDamageToRandomMonster()
    {
        if (GameObject.FindGameObjectWithTag("monster"))
        {
            Manager.PickRandomMonsters().GetComponent<health>().ReceiveDamage(gun.GetComponent<ContainerWeapon>().weapon.Damage);
        }
    }
}
