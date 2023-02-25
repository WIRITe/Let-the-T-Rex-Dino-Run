using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Speed;

    public Rigidbody2D _rb2D;

    public GameObject BulletPrefab;

    public float TimeToNextShoot;
    private float Timer;

    public int enemyHP = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.HP -= 2;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


    void FixedUpdate()
    {
        if (_rb2D != null) _rb2D.velocity = new Vector2(Speed * -1, 0);

        Timer += Time.deltaTime;

        if(Timer >= TimeToNextShoot)
        {
            if(BulletPrefab != null) EnemyShoot();
            Timer = 0;
        }
    }

    private void Update()
    {
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    void EnemyShoot()
    {
        GameObject H = Instantiate(BulletPrefab, transform.position, transform.rotation);

        H.transform.SetParent(gameObject.transform);
    }
}
