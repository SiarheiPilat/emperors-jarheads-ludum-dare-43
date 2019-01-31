using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public float counter;
    public float TimeBeforeEvent;

    public GameObject eventUI, resupplyEventUI;

    public GameObject ResupplyMarine;

    public Transform[] MovePoints;

    public Marine[] extraMarineSOs;

    public Transform marineParent;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        //Debug.Log(Manager.CountMarines());
        if (counter > TimeBeforeEvent)
        {
            if (Manager.Instance.stageState == Manager.StageState.Delve)
            {

                if (Manager.CountMarines() > 4)
                    CallNegativeEvent();
                else
                {
                    Resupply();
                }
                //CallNegativeEvent();
            }
        }

        
    }

    private void Resupply()
    {
        Manager.Instance.stageState = Manager.StageState.Event;
        resupplyEventUI.SetActive(true);

        for (int i = 0; i < Manager.MaxMarinesAmount - Manager.CountMarines() - 1; i++)
        {
            SpawnSingleMarine();
        }
    }

    private void SpawnSingleMarine()
    {
        GameObject marineClone = Instantiate(

            ResupplyMarine,
            MovePoints[Random.Range(0, MovePoints.Length)].position,
                Quaternion.identity
            );

        marineClone.SetActive(true);

        marineClone.transform.parent = marineParent;

        marineClone.GetComponent<ContainerMarine>().marine = extraMarineSOs[Random.Range(0, extraMarineSOs.Length)];

        for (int i = 0; i < marineClone.GetComponent <HumanoidAI_1>().moveTargets.Length; i++)
        {
            marineClone.GetComponent<HumanoidAI_1>().moveTargets[i] = MovePoints[Random.Range(0, MovePoints.Length)];
        }
    }

    private void CallNegativeEvent()
    {
        Manager.Instance.stageState = Manager.StageState.Event;
        if (eventUI.activeSelf == false)
        {
            eventUI.SetActive(true);
        }
    }
}
