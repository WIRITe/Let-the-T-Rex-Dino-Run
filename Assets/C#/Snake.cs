using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public List<Transform> Pices = new List<Transform>();

    public float rectSize;

    public float FPS;
    private float TimerForFPS;

    private void FixedUpdate()
    {
        TimerForFPS += Time.deltaTime;

        if(TimerForFPS >= FPS)
        {
            transform.position = new Vector2(transform.position.x + rectSize, transform.position.y);
            transform.Rotate(Input.GetAxis("Horizontal") * 90, 0, 0);

            for(int i = 1; i < Pices.Count; i++)
            {
                Transform thisPice = Pices[i];
                Transform lastPice = Pices[i - 1];

                thisPice.position = lastPice.position;
                thisPice.rotation = lastPice.rotation;
            }
        }
    }
}
