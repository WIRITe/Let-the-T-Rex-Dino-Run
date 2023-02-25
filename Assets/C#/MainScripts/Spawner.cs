using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();

    public List<GameObject> PlatfPrefs = new List<GameObject>();

    public float DistanceBetweenPlatforms;

    //Tags - strings
    public string LitePlatfTag;
    public string StartUpPlatfTag;
    public string UpPlatfTag;
    public string EndUpPlatfTag;


    public GameObject LastPlatform;

    public GameObject Scene;

    public Transform DelatePos;
    public Transform SpawnPos;

    public void Update()
    {
        if (!Player.isLive) return;

        if(Input.GetKeyDown(KeyCode.W))
        {
            AddPlatform();
        }

        for(int i = 0; i < platforms.Count; i++)
        {
            if(platforms[i].transform.position.x <= DelatePos.position.x)
            {
                Destroy(platforms[i]);
                platforms.Remove(platforms[i]);
            }
        }

        if (LastPlatform.transform.position.x <= SpawnPos.transform.position.x)
        {
            AddPlatform();
        }
    }

    public void AddPlatform()
    {
        int i = Random.Range(0, 3);

        GameObject H;

        if (LastPlatform.tag == LitePlatfTag)
        {
            if (i == 1) {
                H = Instantiate(PlatfPrefs[0], new Vector3(LastPlatform.transform.position.x + DistanceBetweenPlatforms, LastPlatform.transform.position.y, 0), Quaternion.identity) ;
            }
            else
            {
                H = Instantiate(PlatfPrefs[1], new Vector3(LastPlatform.transform.position.x + DistanceBetweenPlatforms, LastPlatform.transform.position.y, 0), Quaternion.identity);
            }
        }
        else if (LastPlatform.tag == StartUpPlatfTag || LastPlatform.tag == UpPlatfTag)
        {
            if (i == 1)
            {
                H = Instantiate(PlatfPrefs[2], new Vector3(LastPlatform.transform.position.x + DistanceBetweenPlatforms, LastPlatform.transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                H = Instantiate(PlatfPrefs[3], new Vector3(LastPlatform.transform.position.x + DistanceBetweenPlatforms, LastPlatform.transform.position.y, 0), Quaternion.identity);
            }
        }
        else
        {
            H = Instantiate(PlatfPrefs[0], new Vector3(LastPlatform.transform.position.x + DistanceBetweenPlatforms, LastPlatform.transform.position.y, 0), Quaternion.identity);
        }

        LastPlatform = H;
        H.transform.SetParent(Scene.transform);

        platforms.Add(LastPlatform);
    }

    
    public void DealatePlatform()
    {
        if(platforms.Count > 1)
        {
            Destroy(platforms[0]);
            platforms.Remove(platforms[0]);
        }
    }
}
