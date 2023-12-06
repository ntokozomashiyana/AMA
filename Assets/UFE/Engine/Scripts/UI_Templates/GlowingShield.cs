using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingShield : MonoBehaviour
{
    public DefaultBattleGUI battleGUIreference;
    public GameObject p1GlowingShield;
    public GameObject p2GlowingShield;

    public void Start()
    {
       // Debug.Log(battleGUIreference.player1GUI.gauges[0].fillAmount);
    }

    public void Update()
    {
        //Activate p1 glowing shield
        if (battleGUIreference.player1GUI.gauges[0].fillAmount == 1)
        {
            p1GlowingShield.SetActive(true);
        }
        else
        {
            p1GlowingShield.SetActive(false);
        }
        //Activate p2 glowing shield
        if (battleGUIreference.player2GUI.gauges[0].fillAmount == 1)
        {
            p2GlowingShield.SetActive(true);
        }
        else
        {
            p2GlowingShield.SetActive(false);
        }
    }
}