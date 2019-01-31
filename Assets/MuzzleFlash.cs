using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{

    public GameObject Flash;

    public enum FlashStyle
    {
        Normal,
        Variation
    };

    public FlashStyle flashStyle;

    void OnEnable()
    {
        switch (flashStyle)
        {
            case FlashStyle.Normal:
                Instantiate(Flash, gameObject.transform.position, Quaternion.identity);
                break;
            case FlashStyle.Variation:
                Instantiate(Flash, gameObject.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }



    //public float TurnOffAfter;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Invoke("TurnOff", TurnOffAfter);
    //}

    //void TurnOff()
    //{
    //    gameObject.SetActive(false);
    //}
}
