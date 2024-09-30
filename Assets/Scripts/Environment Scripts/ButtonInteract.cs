using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/*
 * A script to allow a button to be interacted by the player.
 * In this case, this is the button to activate the decontamination room to trap the Stalker
 */
public class ButtonInteract : MonoBehaviour
{
    [SerializeField]
    private Transform buttonTransform;
    /* 
    [SerializeField]
    private DoorAnimated doorF;
    [SerializeField]
    private DoorAnimated doorS;
    */
    [SerializeField]
    private LayerMask checkForDoors;

    [SerializeField]
    private AudioSource doorSound;
    [SerializeField]
    private AudioSource alarmSound;

    [SerializeField]
    private GameObject lt;

    public bool startTrap = false;
    public bool onCooldown = false;

    private DeconDoorAnimated[] doorA;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (startTrap == false && onCooldown == false)
            {
                /*
                 * Once button is pressed, it checks if player is around the button's radius.
                 * This prevents the player from activating the button anywhere or from across the map.
                 */
                Debug.Log("E pressed");
                Collider2D[] list = Physics2D.OverlapCircleAll(buttonTransform.position, 1f);
                foreach (Collider2D col in list)
                {
                    //Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                    if (col.tag == "Player")
                    {
                        StartCoroutine(trapTimer()); 
                    }
                }
            }
            /* Code block below is simply for debugging purposes
             * This allows the developers to stop the trap by pressing the button again.
            else if (startTrap == true)
            {
                Debug.Log("E pressed");
                Collider2D[] list = Physics2D.OverlapCircleAll(buttonTransform.position, 20f);
                foreach (Collider2D col in list)
                {
                    Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                    if (rb.tag == "Player")
                    {
                        startTrap = false;
                        Debug.Log("Trap Stop");
                    }
                }
            }
            */
        }
    }
    /*
     * IEnumerator is used to delay certain functions or code from triggering.
     */ 
    IEnumerator trapTimer()
    {
        /*
         * A 3 second timer is given to the player
         * to leave the room before it closes
         */
        Collider2D[] listDoors = Physics2D.OverlapCircleAll(buttonTransform.position, 15f, checkForDoors);
        yield return new WaitForSeconds(4);

        foreach (Collider2D colD in listDoors)
        {
            if (colD.GetComponent<DeconDoorAnimated>())
            {
                doorSound.Play();
                colD.GetComponent<DeconDoorAnimated>().CloseDoor();
                lt.GetComponent<Light2D>().color = Color.red;
            }
        }
        alarmSound.Play();
        startTrap = true;

        Debug.Log("Trap Start");

        onCooldown = true;
        /*
         * Player must survive in the room for 15 seconds
         * before they can leave the room
         */
        yield return new WaitForSeconds(15);
        startTrap = false;
        alarmSound.Stop();
        foreach (Collider2D col in listDoors)
        {
            if (col.GetComponent<DeconDoorAnimated>())
            {
                doorSound.Play();
                col.GetComponent<DeconDoorAnimated>().OpenDoor();
            }
        }
        Debug.Log("Trap Stop");

        yield return new WaitForSeconds(30);
        onCooldown = false;
        lt.GetComponent<Light2D>().color = Color.green;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(buttonTransform.position, 15f);
    }

}
