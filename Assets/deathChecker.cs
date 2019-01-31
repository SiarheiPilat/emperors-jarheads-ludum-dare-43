using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathChecker : MonoBehaviour
{
    public GameObject defeatUI;
    public GameObject[] otherUItoTurnOff;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckForDefeat", 4.0f, 4.0f);
    }

    
    private void CheckForDefeat()
    {
        if (!GameObject.FindGameObjectWithTag("marine"))
        {
            foreach (var item in otherUItoTurnOff)
            {
                item.SetActive(false);
            }
            defeatUI.SetActive(true);
        }
    }
}
