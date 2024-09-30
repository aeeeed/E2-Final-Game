using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public bool isSafe = false;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            isSafe = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player"))
        {
            isSafe = false;
        }
    }
}
