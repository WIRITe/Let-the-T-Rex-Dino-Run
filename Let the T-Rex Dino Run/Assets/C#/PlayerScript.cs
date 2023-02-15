using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    public bool grounded;
    public static bool isCanMoove = true;
    

    public Rigidbody2D _rb2D;

    public enum Platform {Android,PC}
    public Platform _platform = Platform.Android;

    //Keys
    public KeyCode JumpKey;
    public KeyCode Down;

    //Anim&&Shift
    public Animator _anim;

    //Tags
    public string GroundTag = "ground";
    public string BarierTag = "barier";
    public string BonusTag = "bonus";

    public GameObject DeadScreen;

    //Score 
    public static int Score;
    public TMP_Text _text;

    //triggers
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == GroundTag) grounded = true;

        else if(collision.tag == BarierTag)
        {
            OnDead();
        }
        else if (collision.tag == BonusTag)
        {
            Score += collision.gameObject.GetComponent<BonusScript>().Count;
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ground") grounded = false;
    }


    void Update()
    {
        if(_platform == Platform.PC)
        {
            if (Input.GetKeyDown(JumpKey)) Jump();

            if (Input.GetKeyDown(Down))
            {
                ShiftStart();
            }
            if (Input.GetKeyUp(Down))
            {
                ShiftEnd();
            }
        }

        //print score
        _text.text = Score.ToString();
    }

    void Jump()
    {
        if(grounded && isCanMoove) _rb2D.velocity = new Vector2(0, JumpForce);
    }

    void OnDead()
    {
        isCanMoove = false;
        DeadScreen.SetActive(true);
    }


    void ShiftStart()
    {
        _anim.SetBool("Shift", true);
    }
    void ShiftEnd()
    {
        _anim.SetBool("Shift", false);
    }
}
