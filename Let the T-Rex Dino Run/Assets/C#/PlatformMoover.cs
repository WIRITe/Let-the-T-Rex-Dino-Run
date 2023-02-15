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
        if(PlayerScript.isCanMoove)gameObject.transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
    }

    void Update()
    {
        if(transform.position.x <= EndPos.transform.position.x)
        {
            gameObject.transform.position = new Vector2(StartPos.transform.position.x, transform.position.y);
        }
    }
}
