using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public Rigidbody2D _rb2D;

    public enum Platform
    {
        Android,
        PC
    }

    public Platform _platform = Platform.Android;

    public KeyCode JumpKey;

    void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            _rb2D.velocity = new Vector2(0, JumpForce);
        }
    }
}
