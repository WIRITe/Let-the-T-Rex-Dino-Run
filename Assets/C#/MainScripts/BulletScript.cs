using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;

    public Rigidbody2D _rb2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.HP -= 1;
        }

        if(collision.tag != "Enemy" && collision.tag != "Sword") Destroy(gameObject);
    }

    void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(Speed * -1, 0);
    }
}
