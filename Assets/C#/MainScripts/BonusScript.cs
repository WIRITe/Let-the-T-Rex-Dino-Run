using UnityEngine;
using Thirdweb;
using System.Collections.Generic;
using UnityEngine.UI;

public class BonusScript : MonoBehaviour
{ 
    public int Count;

    public string TokenSaveName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnTakeBonus();
        }
    }

    public void OnTakeBonus()
    {
        PlayerPrefs.SetInt(TokenSaveName, PlayerPrefs.GetInt(TokenSaveName) + Count);
        Destroy(gameObject);
    }
}
