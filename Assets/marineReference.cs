using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marineReference : MonoBehaviour
{
    public GameObject theMarine;

    public void SacrificeMarine()
    {
        theMarine.GetComponent<health>().Die();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
