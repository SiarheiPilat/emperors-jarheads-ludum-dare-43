using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMarine : MonoBehaviour
{
    public Marine marine;

    void Start()
    {
        GetComponent<health>().HP = marine.Health;
    }
}
