using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reparent : MonoBehaviour
{
    public GameObject newParent;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(newParent.transform);
    }
}
