using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class monsterHUD : MonoBehaviour
{

    public GameObject HUDUI;
    public TextMeshProUGUI MonsterLevel;
    public TextMeshProUGUI MonsterStats;

    void OnMouseOver()
    {
        HUDUI.SetActive(true);
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        if(gameObject.GetComponent<health>().HP <= 0)
        {
            MonsterStats.text = "DEAD";
        } else
        {
            MonsterStats.text = "HP:" + gameObject.GetComponent<health>().HP + " DMG:" + gameObject.GetComponent<monsterStats>().damage;
        }
    }

    void OnMouseExit()
    {
        HUDUI.SetActive(false);
    }
}
