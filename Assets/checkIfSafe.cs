using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfSafe : MonoBehaviour
{
    //[SerializeField]
    //private bool isSafe;

    public GameObject safeZone;
    
    public Behaviour destinationSetter;
    public Behaviour patrolSetter;
    
    // Update is called once per frame
    void Update()
    {
        if(safeZone.GetComponent<SafeZone>().isSafe == true)
        {
            destinationSetter.enabled = false;
            patrolSetter.enabled = true;
        }
        else
        {
            destinationSetter.enabled = true;
            patrolSetter.enabled = false;
        }
    }
}
