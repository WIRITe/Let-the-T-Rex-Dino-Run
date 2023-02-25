using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float Speed;

    public Transform _player;

    public float maxDisance;
    public float maxVertDistance;

    public List<GameObject> Spawners = new List<GameObject>();
    public List<float> distanses = new List<float>();

    void Awake()
    {
        foreach(GameObject Spawner in Spawners)
        {
            distanses.Add(Spawner.transform.position.x - transform.position.x);
        }
    }


    void FixedUpdate()
    {
        if (!Player.isLive) return;

        float _speed = Speed;

        if(_player.position.x >= transform.position.x + maxDisance) _speed = 4;
        

        gameObject.transform.Translate(_speed * Time.deltaTime, 0, 0);

        if(_player.position.y >= transform.position.y + maxVertDistance)
        {
            transform.position = new Vector3(transform.position.x, _player.position.y - maxVertDistance, transform.position.z);
        }
        else if(_player.position.y <= transform.position.y - maxVertDistance)
        {
            transform.position = new Vector3(transform.position.x, _player.position.y + maxVertDistance, transform.position.z);
        }

        for (int i = 0; i < Spawners.Count; i++) 
        {
            Spawners[i].transform.position = new Vector2(transform.position.x + distanses[i], Spawners[i].transform.position.y);
        }
    }
}
