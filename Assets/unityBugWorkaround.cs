using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityBugWorkaround : MonoBehaviour
{

    [Header("Crashes the inspector, do not show")]
    public AudioClip music;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().clip = music;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().volume = 0.5f;
    }
}
