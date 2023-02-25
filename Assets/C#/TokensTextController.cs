using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TokensTextController : MonoBehaviour
{
    public TMP_Text Tocens;
    public string TokenSaveName;

    // Update is called once per frame
    void Update()
    {
        Tocens.text = PlayerPrefs.GetInt(TokenSaveName).ToString();
    }

    public void OnAgainButton()
    {
        SceneManager.LoadScene(0);
    }
}
