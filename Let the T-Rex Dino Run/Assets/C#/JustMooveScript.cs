using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustMooveScript : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        if(PlayerScript.isCanMoove) transform.Translate(new Vector2(Speed * -1 * Time.deltaTime, 0));
    }
}
