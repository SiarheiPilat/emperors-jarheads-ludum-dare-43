using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public GameObject replacement;

    public int HP;
    public Animator animator;

    void Start()
    {
    }

    public void ReceiveDamage(int amount)
    {
        HP -= amount;
        if (HP <= 0)
            Die();
    }

    public void Die()
    {
        if(gameObject.GetComponent<monsterHUD>())
        gameObject.GetComponent<monsterHUD>().HUDUI.SetActive(false);

        if (gameObject.GetComponent<MarineInventory>())
            gameObject.GetComponent<MarineInventory>().HUDUI.SetActive(false);

        if (gameObject.GetComponent<MonsterLoot>())
        {
            gameObject.GetComponent<MonsterLoot>().TryDropLoot();
        }

        GameObject replacementClone = Instantiate(replacement, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);

    }
}
