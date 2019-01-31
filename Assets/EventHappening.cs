using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventHappening : MonoBehaviour
{
    public GameObject coutner;

    public GameObject[] ThingsThatMustBeActive;

    public GameObject[] soldierChoices;
    public GameObject[] actualMarines;

    public GameObject continueButton, allChoicesButtons;

    public EventSO[] allPossibleEvents;

    private EventSO THEevent;

    public TextMeshProUGUI tagline, scenario, punishmentTxt;

    public GameObject eventManager;

    void OnEnable()
    {

        foreach (var item in ThingsThatMustBeActive)
        {
            item.SetActive(true);
        }

        THEevent = allPossibleEvents[Random.Range(0, allPossibleEvents.Length)];

        tagline.text = THEevent.tagLine;
        scenario.text = THEevent.scenario;

        punishmentTxt.gameObject.SetActive(false);
        tagline.gameObject.SetActive(true);
        scenario.gameObject.SetActive(true);

        actualMarines = GameObject.FindGameObjectsWithTag("marine");

        for (int i = 0; i < actualMarines.Length; i++)
        {
            soldierChoices[i].SetActive(true);
            soldierChoices[i].GetComponentInChildren<TextMeshProUGUI>().text = actualMarines[i].GetComponent<ContainerMarine>().marine.MarineName;
            soldierChoices[i].GetComponent<marineReference>().theMarine = actualMarines[i];
        }

        coutner.GetComponent<TimerCountdown>().seconds = THEevent.timeForDecision;
    }

    public void RunPunishment()
    {
        for (int i = 0; i < Random.Range(2, 4); i++)
        {
            Manager.PickRandomMarine().GetComponent<health>().Die();
        }
        foreach (var item in soldierChoices)
        {
            item.SetActive(false);
        }
        punishmentTxt.gameObject.SetActive(true);
        tagline.gameObject.SetActive(false);
        scenario.gameObject.SetActive(false);
        punishmentTxt.text = THEevent.punishmentText;

        continueButton.SetActive(true);
    }

    public void RunGoodOutcome()
    {
        punishmentTxt.gameObject.SetActive(true);
        tagline.gameObject.SetActive(false);
        scenario.gameObject.SetActive(false);
        punishmentTxt.text = THEevent.congratulatoryText;
        continueButton.SetActive(true);
    }

    void OnDisable()
    {
        foreach (var item in soldierChoices)
        {
            item.SetActive(false);
        }
        continueButton.SetActive(false);

        Manager.Instance.stageState = Manager.StageState.Delve;

        if(eventManager)
            eventManager.GetComponent<EventManager>().counter = 0;
    }

    public void SacrificeMarine()
    {

    }
}
