using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesController : MonoBehaviour
{
    public TMP_Text Text;

    private int Trying = 0;

    public int TryingEveryDay;

    void Start()
    {
        DateTime dateTime = new DateTime();
        dateTime = DateTime.Now;

        if (PlayerPrefs.GetInt("Day") < dateTime.Day) 
        {
            Trying = TryingEveryDay;
        }
        else
        {
            if(PlayerPrefs.GetInt("Mounth") < dateTime.Month)
            {
                Trying = TryingEveryDay;
            }
            else
            {
                if(PlayerPrefs.GetInt("Year") < dateTime.Year)
                {
                    Trying = TryingEveryDay;
                }
                else
                {
                    Trying = PlayerPrefs.GetInt("Tryings");
                }
            }
        }


        PlayerPrefs.SetInt("Day", dateTime.Day);
        PlayerPrefs.SetInt("Mounth", dateTime.Month);
        PlayerPrefs.SetInt("Year", dateTime.Year);
        SaweTryings();

        Text.text = Trying.ToString();
    }

    void SaweTryings()
    {
        PlayerPrefs.SetInt("Tryings", Trying);
    }
}
