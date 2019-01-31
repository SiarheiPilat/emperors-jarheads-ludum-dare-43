using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroller : MonoBehaviour
{
    public GameObject floor4tile1, floor4tile2;
    public float speed;

    public GameObject[] Props1, Props2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance.stageState == Manager.StageState.Delve)
        {
            floor4tile1.transform.position += Vector3.right * -speed;
            floor4tile2.transform.position += Vector3.right * -speed;

            if(floor4tile1.transform.position.x < -60.0f)
            {
                floor4tile1.transform.position += new Vector3(68.43f * 2, 0.0f, 0.0f);
                RandomizeProps(Props1);
            }
            if (floor4tile2.transform.position.x < -60.0f)
            {
                floor4tile2.transform.position += new Vector3(68.43f * 2, 0.0f, 0.0f);
                RandomizeProps(Props2);
            }
        }
    }

    void RandomizeProps(GameObject[] Props)
    {
        for (int i = 0; i < Props.Length; i++)
        {
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                Props[i].SetActive(true);
            } else Props[i].SetActive(false);
        }
    }
}
