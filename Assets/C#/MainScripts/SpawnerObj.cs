using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObj : MonoBehaviour
{
    public GameObject Object;

    public float MaxTimeToSpawn;
    public float MinTimeToSpawn;

    public string TagOfDoublePlatf;

    public bool _changeTimeToSpawnOnDoublePlatf;
    public float MaxTimeToSpawnOnDoublePlatf;
    public float MinTimeToSpawnOnDoublePlatf;

    public bool onlyOnDoublePlatf;

    public float TimeToSpawn;
    public float Timer;
    public bool isOnDoublePlatf;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == TagOfDoublePlatf)
        {
            isOnDoublePlatf = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TagOfDoublePlatf)
        {
            isOnDoublePlatf = false;
        }
    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if (Timer >= TimeToSpawn)
        {
            
            if (onlyOnDoublePlatf)
            {
                
                if (isOnDoublePlatf)
                {
                    Debug.Log(onlyOnDoublePlatf);
                    Spawner();
                    Timer = 0;
                }
            }
            else
            {
                Spawner();
                Timer = 0;
            }
        }
    }

    void Spawner() 
    {
        GameObject H = Instantiate(Object, transform.position, Object.transform.rotation);
        TimeToSpawn = Random.Range(isOnDoublePlatf ? MinTimeToSpawnOnDoublePlatf : MinTimeToSpawn, isOnDoublePlatf ? MaxTimeToSpawnOnDoublePlatf : MaxTimeToSpawn);
    }
}
