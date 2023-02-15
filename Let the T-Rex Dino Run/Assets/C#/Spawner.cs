using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prfab;

    public float TimeToNextSpawn;
    private float Timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Timer >= TimeToNextSpawn)
        {
            if (MainSpawner.AbleToSpawn)
            {
                Spawn();
                Timer = 0;
                MainSpawner.AbleToSpawn = false;
                MainSpawner.Timer = 2;
            }
        }

        Timer += Time.deltaTime;
    }

    void Spawn()
    {
        if (PlayerScript.isCanMoove) Instantiate(Prfab, transform.position, transform.rotation);
    }
}
