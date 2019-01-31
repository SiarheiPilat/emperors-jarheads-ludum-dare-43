using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    public float DestroyAfter;

    void OnEnable()
    {
        Destroy(gameObject, DestroyAfter);
    }
}
