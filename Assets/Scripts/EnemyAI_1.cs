using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1 : MonoBehaviour {

    public Transform ApproachTarget;
    public float Speed, ApproachLimit;

    public bool IsApproaching;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsApproaching)
        {
            Approach();
        }
	}

    void Approach()
    {
        transform.position = Vector3.Lerp(transform.position, ApproachTarget.position, Time.deltaTime * Speed);

        if(Vector3.Distance(transform.position, ApproachTarget.position) < ApproachLimit)
        {
            IsApproaching = false;
        }
    }
}
