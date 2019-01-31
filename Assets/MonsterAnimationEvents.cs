using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationEvents : MonoBehaviour
{
    public GameObject RootGameobject;
    private bool isJumping;
    public float speed;


    public void JumpTowards()
    {
        isJumping = true;
    }

    public void StopJump()
    {
        isJumping = false;
        //Debug.Log("stop");
    }

    public void DamageMarine()
    {
        if (RootGameobject.GetComponent<MonsterAI>().target)
        {
            RootGameobject.GetComponent<MonsterAI>().target.GetComponent<health>().ReceiveDamage(RootGameobject.GetComponent<monsterStats>().damage);
            RootGameobject.GetComponent<MonsterAI>().target.GetComponent<MarineInventory>().UpdateHUD();
        }
    }

    void Update()
    {
        if (isJumping)
        {
            RootGameobject.transform.position = Vector3.MoveTowards(RootGameobject.transform.position, RootGameobject.GetComponent<MonsterAI>().target.transform.position, speed * Time.deltaTime);
        }

        //Debug.Log(isJumping);
    }
}
