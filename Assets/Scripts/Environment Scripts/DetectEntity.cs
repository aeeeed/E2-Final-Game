using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEntity : MonoBehaviour
{
    public AIPath aiPath;
    public EnemyHealth eM;

    public ButtonInteract bI;

    public HealthManager hM;

    private List<GameObject> list = new List<GameObject>();
    private GameObject player;
    private bool isEnemyHit = false;

    //I'm going insane
    /*
        Idea is: If button is clicked, all objects inside collider starts taking damage
        How to do this? isTrigger
        Step 1. isTrigger Enter, add that object in a list
        Step 2. button is pressed
        Step 3. Check list if objects are still inside, deal damage
         */
    private void Update()
    {
        /*
        if (Input.GetKeyDown("space")){
            foreach (GameObject g in list)
            {
                Debug.Log(g.name);
            }
        }
        */
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (bI.startTrap)
        {
            if(collision.gameObject == GameObject.Find("Player")){  
                hM.TakeDamage(0.1f);
            }
            else if (collision.gameObject == GameObject.Find("Stalker"))
            {
                if(isEnemyHit == false)
                {
                    eM.EnemyHP--;
                    isEnemyHit = true;
                }
                aiPath.maxSpeed = 2;
            }
        }
        else
        {
            isEnemyHit = false;
            aiPath.maxSpeed = 4f;
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!list.Contains(collider.gameObject))
        {
            list.Add(collider.gameObject);
            Debug.Log("Added " + gameObject.name);
            Debug.Log("GameObjects in list: " + list.Count);
        }
    }
    
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (list.Contains(collider.gameObject))
        {
            list.Remove(collider.gameObject);
            Debug.Log("Removed " + gameObject.name);
            Debug.Log("GameObjects in list: " + list.Count);
        }
    }
    */
    /*
    void checkForPlayer()
    {
        Collider2D aoe = GetComponent<CompositeCollider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();

        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D c in collider)
            {
                if (c.GetComponent<PlayerMovement>() || c.GetComponent<AIPath>())
                {
                    Debug.Log("DAMAGE");
                }
            }
    }
    */
}
