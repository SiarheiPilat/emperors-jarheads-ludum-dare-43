using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Taken from https://answers.unity.com/questions/504933/countdown-timer-in-minutessecondsmilliseconds.html

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timer;
    [HideInInspector]
    public float minutes = 0;
    public float seconds = 0;
    public float miliseconds = 0;

    public GameObject evenController;

    void Update()
    {

        if (miliseconds <= 0)
        {
            if (seconds <= 0 && miliseconds <= 0)
            {
                timer.text = string.Format("{0}:{1}:{2}", 0.0f, 0.0f, 0);

                FireUpPunishment();

                timer.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            else if (seconds >= 0)
            {
                seconds--;
            }

            miliseconds = 100;
        }

        miliseconds -= Time.deltaTime * 100;

        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        timer.text = string.Format("{0}:{1}:{2}", 0.0f, seconds, (int)miliseconds);
    }

    private void FireUpPunishment()
    {
        evenController.GetComponent<EventHappening>().RunPunishment();
    }
}
