using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingLoot : MonoBehaviour
{
    public bool canFly;
    public float speed;

    Transform tgt;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Launch", 2.0f);
        tgt = Manager.PickRandomMarine().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFly && tgt)
        {
            Fly(tgt);

            if(Vector3.Distance(transform.position, tgt.position) < 0.1f)
            {
                EquipNewLoot();
            }

            speed += Time.deltaTime;
        }
    }

    private void EquipNewLoot()
    {
        tgt.gameObject.GetComponent<MarineInventory>().Weapon.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;

        tgt.gameObject.GetComponent<MarineInventory>().Weapon.GetComponent<ContainerWeapon>().weapon = GetComponent<ContainerWeapon>().weapon;

        tgt.gameObject.GetComponent<MarineInventory>().Weapon.GetComponent<Gun>().muzzle.GetComponent<MuzzleFlash>().Flash =
            GetComponent<Gun>().muzzle.GetComponent<MuzzleFlash>().Flash;

        Destroy(gameObject);
    }

    void Fly(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    void Launch()
    {
        canFly = true;
    }
}
