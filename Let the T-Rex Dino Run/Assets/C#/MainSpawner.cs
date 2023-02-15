using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    public static bool AbleToSpawn = true;

    public static float Timer;

    void FixedUpdate()
    {
        if(Timer <= 0)
        {
            AbleToSpawn = true;
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
}
