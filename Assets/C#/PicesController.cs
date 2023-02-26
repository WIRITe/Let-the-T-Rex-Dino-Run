using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PicesController : MonoBehaviour
{
    public string NameOfSavedTokens;
    public string NameOfSavedPices;

    public int Pices;
    public int Tokens;

    public List<GameObject> ActivePices = new List<GameObject>();
    public List<GameObject> notActivePices = new List<GameObject>();

    public TMP_Text text;

    private void Awake()
    {
        DrowPices();
    }

    public void ToZero()
    {
        PlayerPrefs.SetInt(NameOfSavedPices, 0);

        DrowPices();

        PlayerPrefs.SetInt(NameOfSavedTokens, 0);
    }

    private void Update()
    {
        text.text = PlayerPrefs.GetInt(NameOfSavedTokens).ToString();
    }

    public void OnAddButton()
    {
        PlayerPrefs.SetInt(NameOfSavedTokens, PlayerPrefs.GetInt(NameOfSavedTokens) + 1000);
    }

    public void OnChangeButton()
    {
        if (PlayerPrefs.GetInt(NameOfSavedTokens) <= 0) return;

        PlayerPrefs.SetInt(NameOfSavedPices, PlayerPrefs.GetInt(NameOfSavedPices) + 1);

        DrowPices();

        PlayerPrefs.SetInt(NameOfSavedTokens, PlayerPrefs.GetInt(NameOfSavedTokens) - 1000);
    }

    public void DrowPices()
    {
        Tokens = PlayerPrefs.GetInt(NameOfSavedTokens);
        Pices = PlayerPrefs.GetInt(NameOfSavedPices);

        for (int i = 1; i < 7; i++)
        {
            if (Pices >= i)
            {
                ActivePices[i - 1].SetActive(true);
                notActivePices[i - 1].SetActive(false);
            }
            else
            {
                ActivePices[i - 1].SetActive(false);
                notActivePices[i - 1].SetActive(true);
            }
        }
    }

    void CheckTockens()
    {
        if (Tokens >= 6000) Solve();
    }

    void Solve()
    {
        
    }
}
