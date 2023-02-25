using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public string playerTag;
    public List<string> TagsOfDestrouOnExitThings = new List<string>();
 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == playerTag)
        {
            OnDead();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(IsTagInList(TagsOfDestrouOnExitThings, collision.tag))
        {
            Destroy(collision.gameObject);
        }
    }

    void OnDead()
    {

    }

    bool IsTagInList(List<string> Tags, string Tag)
    {
        for(int i = 0; i < Tags.Count; i++)
        {
            if (Tags[i] == Tag) return true;
        }
        return false;
    }
}
