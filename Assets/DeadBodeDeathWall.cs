using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodeDeathWall : MonoBehaviour
{

    BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "dead")
        {
            Destroy(col.gameObject);
        }
    }
}
