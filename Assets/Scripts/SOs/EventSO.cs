using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "event-")]
public class EventSO : ScriptableObject
{
    public string tagLine, scenario, punishmentText, congratulatoryText;
    public float timeForDecision;

}
