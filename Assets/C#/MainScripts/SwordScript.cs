using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public bool canHit;
    public KeyCode KeyToHit;

    public float TimeToNextHit;
    public float Timer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyToHit))
        {
            if (canHit)
            {
                if(collision.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<EnemyScript>().enemyHP -= 1;
                    Debug.Log(collision.gameObject.GetComponent<EnemyScript>().enemyHP);

                    canHit = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if(Timer > TimeToNextHit)
        {
            Timer = 0;
            canHit = true;
        }
    }
}
