using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaterStuff : MonoBehaviour
{
    public List<string> AbleToDelateTags = new List<string>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (InList(AbleToDelateTags, collision.tag)) 
        {
            Destroy(collision.gameObject);
        }
    }

    bool InList(List<string> listToDelate, string delatingString)
    {
        for(int i = 0; i < listToDelate.Count; i++)
        {
            if (listToDelate[i] == delatingString) 
            {
                return true;
            }
        }
        return false;
    }
}
