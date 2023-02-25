using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encrypt : MonoBehaviour
{
    string encr = "f";

    void encryptInt(int encInt, string nameToEnc)
    {

    }

    int dencryptInt(string nameOfEncrStr)
    {
        string encrStr = PlayerPrefs.GetString(nameOfEncrStr);
        int endInt = 0;

        for (int i = 0; i < encrStr.Length; i++)
        {
            endInt += encrStr[i] == encr[0] ? 1 : 2;
        }

        return endInt;
    }
}
