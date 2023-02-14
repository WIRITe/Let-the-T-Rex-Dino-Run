using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoover : MonoBehaviour
{
    public Rigidbody2D _rb2D;

    public float Speed;

    public Transform EndPos;
    public Transform StartPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(Speed * -1, 0);
    }

    void Update()
    {
        if(transform.position.x <= EndPos.transform.position.x)
        {
            gameObject.transform.position = new Vector2(StartPos.transform.position.x, transform.position.y);
        }
    }
}
