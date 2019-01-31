using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * speed, Space.World);
    }
}
