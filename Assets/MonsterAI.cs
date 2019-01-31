using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    public float approachLimit;
    int random, dam;

    void Start()
    {
        dam = GetComponent<monsterStats>().damage;

        if (!target && GameObject.FindGameObjectWithTag("marine"))
        {
            target = Manager.PickRandomMarine().transform;
        }
    }

    void Update()
    {
        if (target)
        {
            if(target.transform.position.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            } else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }

            if (Vector3.Distance(transform.position, target.position) > approachLimit)
            {
                animator.SetBool("IsMoving", true);
                animator.SetBool("isAttacking", false);
                animator.SetBool("isAttacking2", false);
            }
            else
            {
                animator.SetBool("IsMoving", false);
                random = Random.Range(0, 4);
                if (random == 0)
                    animator.SetBool("isAttacking", true);
                else if (random == 1)
                    animator.SetBool("isAttacking2", true);
                else
                {
                    animator.SetBool("isAttacking", false);
                    animator.SetBool("isAttacking2", false);
                }
                //target.gameObject.GetComponent<health>().ReceiveDamage(dam);
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("marine"))
                target = Manager.PickRandomMarine().transform;
        }
            

    }

    void JumpTowards()
    {
        animator.Play("monster-1-jump-1");
    }

    void Idle()
    {
        animator.Play("monster-1-idle-1");
    }

    void Slash()
    {
        animator.Play("monster-1-slash-1");
    }
}
