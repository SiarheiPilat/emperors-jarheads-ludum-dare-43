using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLoot : MonoBehaviour
{
    public GameObject[] Loot;
    [Range(1, 100)]
    [Tooltip("Loot drops when random number == 1")]
    public int dropChance;

    public void TryDropLoot()
    {
        int rand = Random.Range(0, dropChance);
        Debug.Log(rand);
        if (rand == 1)
        {
            GameObject cloneLoot = Instantiate(

                Loot[Random.Range(0, Loot.Length)],
                transform.position + new Vector3(0.0f, 0.5f, 0.0f),
                Quaternion.identity

                );

            cloneLoot.GetComponent<homingLoot>().enabled = true;
        }
    }
}
